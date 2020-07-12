using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.PriceService
{
    public interface IPriceService
    {
        object GetPricesByLocation(int locationId, int categoryId);
    }
}
