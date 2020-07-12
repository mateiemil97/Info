using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repository;

namespace Services.LocationService
{
    public class LocationService : ILocationService
    {
        private IUnitOfWork _unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Location GetLocationById(int id)
        {
            var location = _unitOfWork.Location.Get(id);
            return location;
        }
    }
}
