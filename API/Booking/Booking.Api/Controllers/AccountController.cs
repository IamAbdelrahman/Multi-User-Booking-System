using AutoMapper;
using Booking.Application.Common;
using Booking.Application.Common.Interfaces;
using Booking.Application.Users.DTOs;
using Booking.Domain.Entities;
using Booking.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IIdentityFactory _identityFactory;
        private readonly IAuthService _authService;
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, 
            IIdentityFactory identityFactory, IAuthService authService) : base(unitOfWork)
        {
            _mapper = mapper;
            _identityFactory = identityFactory;
            _authService=authService;
        }

        [HttpPost("register")]
        [EndpointSummary("Register new user.")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var userName = _authService.ExtractUsernameFromEmail(dto.Email);

            // Map DTO to domain/user entity
            var appUser = _mapper.Map<User>(dto);
            appUser.UserName = userName;
            appUser.NormalizedUserName = userName?.ToUpperInvariant();

            var createdUser = await _identityFactory.UserManager.CreateAsync(appUser, dto.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _identityFactory.UserManager.AddToRoleAsync(appUser, "Customer");

                if (roleResult.Succeeded)
                {
                    var user = await _identityFactory.UserManager.Users.Include(x => x.Roles)
                        .FirstAsync(x => x.Id == appUser.Id);
                    var token = _authService.CreateToken(user);
                    _authService.SetAccessTokenCookie(HttpContext, token);

                    var roles = await _identityFactory.UserManager.GetRolesAsync(appUser);
                    return StatusCode(201, new UserDto
                    {
                        Id = appUser.Id,
                        UserName = appUser.UserName,
                        Roles = roles.ToList(),
                        Token = token,
                    });
                }
                else
                {
                    return StatusCode(500, roleResult.ToErrorList());
                }
            }

            return StatusCode(500, createdUser.ToErrorList());
        }

        [HttpPost("login")]
        [EndpointSummary("Login user.")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var userName = _authService.ExtractUsernameFromEmail(dto.Email);

            var user = await _identityFactory.UserManager.Users
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.UserName == userName);

            if (user is not null)
            {
                var passCheckResult = await _identityFactory.SignInManager.CheckPasswordSignInAsync(user, dto.Password, false);

                if (passCheckResult.Succeeded)
                {
                    var token = _authService.CreateToken(user);
                    // Set secure HTTP-only cookie
                    _authService.SetAccessTokenCookie(HttpContext, token);

                    var roles = await _identityFactory.UserManager.GetRolesAsync(user);


                    return Ok(new UserDto
                    {
                        Id = user.Id,
                        UserName = user.UserName?? "None",
                        Roles = roles.ToList(),
                        Token = token
                    });
                }
            }

            return Unauthorized("Invalid creditionals.");
        }
    }
}
