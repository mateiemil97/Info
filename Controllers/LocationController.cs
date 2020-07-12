using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.LocationModels;
using Services.LocationService;
using SqlDatabase;
using System;

namespace Controllers
{
    [Route("api/locations")]
    public class LocationController: Controller
    {
        private ILocationService _service;
        private IMapper _mapper;

        public LocationController(ILocationService service)
        {
            _service = service;
        }

        public LocationController(ILocationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        
        [HttpGet("{id}")]
        public IActionResult GetLocationById(int id)
        {
            try
            {
                var location = _service.GetLocationById(id);

                if (location == null)
                    return NotFound();

                //var mappedLocation = _mapper.Map<GetLocationModel>(location);

                return Ok(location);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
