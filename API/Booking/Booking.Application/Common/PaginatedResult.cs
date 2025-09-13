using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common
{
    public class PaginatedResult<TEntity>
    {
        public List<TEntity> Items { get; set; }
        public PaginationMetaData MetaData { get; set; }
    }

}
