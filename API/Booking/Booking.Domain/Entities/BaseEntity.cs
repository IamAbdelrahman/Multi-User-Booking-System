using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    /// <summary>
    /// Base Entity for Entities in our system 
    /// </summary>
    /// <typeparam name="TKey">Represents type of entity Id (`string` or `int`)</typeparam>
    public abstract class BaseEntity<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
