using AutoMapper;
using Booking.Application.Common;
using Booking.Application.Common.Interfaces;
using Booking.Application.Reservations.DTOs;
using Booking.Application.Trips.DTOs;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Booking.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TripController : BaseController
    {
        private readonly IMapper _mapper;
        public TripController(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork) 
        {
            _mapper = mapper;
        }

        private string GetCurrentUserId() =>
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

        /// <summary>
        /// EndPoint Description: Retrieves a paginated list of reservations.
        /// </summary>
        [HttpGet]
        [EndpointSummary("Get paginated list of trips.")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PaginatedResult<TripDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllQueryDto dto)
        {
            Func<IQueryable<Trip>, IOrderedQueryable<Trip>> orderBy =
                q => q.OrderByDescending(r => r.Created);

            // Pass the filter to your repository method
            var trips = await _unitOfWork.TripRepo.GetAllAsync(dto, orderBy, t => t.Owner);

            // Map the results
            var mapped = new PaginatedResult<TripDTO>
            {
                Items = _mapper.Map<List<TripDTO>>(trips.Items),
                MetaData = trips.MetaData
            };
            

            return Ok(mapped);
        }
    }
}
