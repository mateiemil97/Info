using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.LocationService;
using Services.TollBoothService;
using Models.ToolboothModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers
{
    [Route("api/toolbooths")]
    public class ToolboothController: Controller
    {
        private ILocationService _locationService;
        private IToolboothService _tollboothService;
        private IMapper _mapper;

        public ToolboothController(ILocationService locationService, IToolboothService toolboothService, IMapper mapper)
        {
            _locationService = locationService;
            _tollboothService = toolboothService;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetFreeToolbooths([FromQuery(Name ="location")] int locationId)
        {
            var location = _locationService.GetLocationById(locationId);

            if (location == null)
                return NotFound("Location not found");

            var toolbooths = _tollboothService.GetFreeToolbooths(location.Id);

            if (toolbooths == null)
                return Ok("No tollbooth available");

            var toolboothMap = _mapper.Map<IEnumerable<GetToolboothModel>>(toolbooths);

            return Ok(toolboothMap);
        }
    }
}
