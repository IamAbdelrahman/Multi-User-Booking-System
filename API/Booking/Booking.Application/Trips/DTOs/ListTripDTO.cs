using Booking.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Trips.DTOs
{
    public class ListTripDTO: GetAllQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TripOwnerDTO Owner { get; set; }
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
        public bool? isFree => Price == 0;

    }
}


