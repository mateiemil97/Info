using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.PriceModels;
using Services.LocationService;
using Services.PriceService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers
{
    [Route("api/prices")]
    public class PriceController: Controller
    {
        private IPriceService _priceService;
        private ILocationService _locationService;
        private IMapper _mapper;

        public PriceController(IPriceService priceService, ILocationService locationService, IMapper mapper)
        {
            _priceService = priceService;
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetPricesByLocationAndCategory([FromQuery(Name ="locationid")] int locationId, [FromQuery(Name ="categoryId")] int categoryId)
        {
            var location = _locationService.GetLocationById(locationId);
            if (location == null)
                return NotFound("Location not found");

            var price = _priceService.GetPricesByLocation(location.Id, categoryId);
            if (price == null)
                return NotFound("Price not found");
            //var priceMapped = _mapper.Map<GetPriceModel>(price);

            return Ok(price);
        }

    }
}
