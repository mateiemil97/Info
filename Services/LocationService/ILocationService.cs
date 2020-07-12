using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.LocationService
{
    public interface ILocationService
    {
       Location GetLocationById(int id);
    }
}
