using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common
{
    public static class GetAllQueryDtoExtensions
    {
        public static int CalcSkippedItems(this GetAllQueryDto dto)
        {
            return (dto.Page - 1) * dto.PageSize;
        }
    }
}
