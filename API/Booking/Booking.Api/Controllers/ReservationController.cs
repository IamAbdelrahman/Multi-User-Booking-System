using AutoMapper;
using Booking.Application.Common;
using Booking.Application.Common.Interfaces;
using Booking.Application.Reservations.DTOs;
using Booking.Domain.Entities;
using Booking.Infrastructure.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Booking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IReservationService _reservationService;
        public ReservationsController(IUnitOfWork unitOfWork, IMapper mapper, 
            IReservationService reservationService) : base(unitOfWork)
        {
            _mapper = mapper;
            _reservationService=reservationService;
        }
        private string GetCurrentUserId() =>
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

        /// <summary>
        /// EndPoint Description: Retrieves a paginated list of reservations.
        /// </summary>
        [HttpGet]
        [EndpointSummary("Get paginated list of reservations.")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PaginatedResult<ReservationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllQueryDto dto)
        {
            Func<IQueryable<Reservation>, IOrderedQueryable<Reservation>> orderBy = 
                q => q.OrderByDescending(r => r.CreatedAt);

            var reservations = await _unitOfWork.ReservationRepo.GetAllAsync(dto, orderBy, null);
            var mapped = new PaginatedResult<ReservationDTO>
            {
                Items = _mapper.Map<List<ReservationDTO>>(reservations.Items),
                MetaData = reservations.MetaData
            };
            return Ok(mapped);
        }

        [Authorize(Roles = "Admin")]
        /// <summary>
        /// EndPoint Description: Retrieves reservations filtered by customer name and sorted by a specified field.
        /// </summary>
        [HttpGet("search")]
        [EndpointSummary("Get reservations filtered by all its properties and sorted by specified field.")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ListReservationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<List<ListReservationDTO>>> GetReservationsSortedFiltered(
            [FromQuery] GetAllReservationsQueryParamsDto dto)
        {
            Expression<Func<Reservation, bool>>? filter = r =>
                (string.IsNullOrEmpty(dto.CustomerName) || r.CustomerName.Contains(dto.CustomerName)) &&
                (!dto.CheckIn.HasValue || r.CheckIn >= dto.CheckIn.Value) &&
                (!dto.CheckOut.HasValue || r.CheckOut <= dto.CheckOut.Value) &&
                (string.IsNullOrEmpty(dto.Status) || r.Status == dto.Status) && 
                (dto.Price == default || r.Trip.Price == dto.Price); 

            Func<IQueryable<Reservation>, IOrderedQueryable<Reservation>>? orderBy = q =>
                q.OrderByDescending(r => r.CreatedAt);

            // Pass the filter and include to the repository
            var reservations = await _unitOfWork.ReservationRepo.
                GetSortedFiltered<ListReservationDTO>(filter, orderBy, t => t.Trip);

            return Ok(reservations);
        }

        /// <summary>
        /// EndPoint Description: Retrieves a single reservation by its identifier.
        /// </summary>
        [HttpGet("{id}")]
        [EndpointSummary("Get a reservation by its id.")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ReservationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> GetById(string id)
        {
            var reservation = await _unitOfWork.ReservationRepo.GetByIdAsync(id);
            if (reservation == null) return NotFound();
            return Ok(_mapper.Map<ReservationDTO>(reservation));
        }


        /// <summary>
        /// EndPoint Description: Creates a new reservation.
        /// </summary>
        [Authorize(Roles = "Guest")]
        [HttpPost("Reserve")]
        [EndpointSummary("Create a new reservation.")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CreateReservationDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> Create([FromBody] CreateReservationDTO dto)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return Unauthorized();

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createBook = await _reservationService.CreateBookingAsync(userId, dto);

            var result = _mapper.Map<CreateReservationDTO>(createBook);
            return Ok(result);
        }

        /// <summary>
        /// EndPoint Description: Updates an existing reservation identified by id.
        /// </summary>
        [HttpPut("{id}")]
        [EndpointSummary("Update an existing reservation by id.")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateReservationDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var reservation = await _unitOfWork.ReservationRepo.GetByIdAsync(id);
            if (reservation == null) return NotFound();

            _mapper.Map(dto, reservation);
            await _unitOfWork.ReservationRepo.UpdateAsync(reservation);

            return NoContent();
        }


        /// <summary>
        /// EndPoint Description: Deletes a reservation by identifier.
        /// </summary>
        [HttpDelete("{id}")]
        [EndpointSummary("Delete a reservation by id.")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> Delete(string id)
        {
            var reservation = await _unitOfWork.ReservationRepo.GetByIdAsync(id);
            if (reservation == null) return NotFound();
            reservation.Status = "Deleted";
            await _unitOfWork.ReservationRepo.UpdateAsync(reservation);

            return NoContent();
        }
    }
}
