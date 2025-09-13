using Booking.Application.Common.Interfaces;
using Booking.Application.Users.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected UserDto CurrentUser
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return null;

                return new UserDto
                {
                    Id = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    UserName = User.FindFirstValue(ClaimTypes.Name),
                    Roles = User.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value)
                        .ToList()
                };
            }
        }

        protected virtual NotFoundObjectResult NotFoundResponse(string? message = null)
        {
            return new NotFoundObjectResult(new List<string>
            {
                message ?? "Resource not found!"
            });
        }

        protected virtual ObjectResult NotImplementedResponse(string? message = null)
        {
            return new ObjectResult(new List<string>
            {
                 message ?? "This endpoint is not implemented yet."
            })
            { StatusCode = StatusCodes.Status501NotImplemented };
        }
    }
}
