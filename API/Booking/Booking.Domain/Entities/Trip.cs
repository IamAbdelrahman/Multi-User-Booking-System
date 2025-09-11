using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Trip:BaseEntity<string>
    {
        public string Name { get; set; }
        public string CityName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; } // Accepts HTML content
        public DateTime Created { get; set; }
        public bool IsActive { get; set; } = true;
        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
        public virtual ICollection<TripAvailability> TripAvailabilities { get; set; } = new HashSet<TripAvailability>();

    }
}

