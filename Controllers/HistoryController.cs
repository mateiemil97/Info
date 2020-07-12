using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models.HistoryModels;
using Services.HistoryService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers
{
    [Route("api/history")]
    public class HistoryController: Controller
    {
        private IHistoryService _historyService;
        private IMapper _mapper;

        public HistoryController(IHistoryService service, IMapper mapper)
        {
            _historyService = service;
            _mapper = mapper;
        }
        [HttpPost(Name ="payment")]
        public IActionResult MakePayment([FromBody]CreateHistoryModel model)
        {
            var historyMapped = _mapper.Map<History>(model);

            var created =  _historyService.Create(historyMapped);

            if(!created)
            {
                return StatusCode(500, "Not created");
            }

            return Created("payment", historyMapped);
        }

        [HttpGet("monthly")]
        public IActionResult GetMonthlyAverage()
        {
            try
            {
                var avg = _historyService.GetMonthlyAverage();
                if (avg != null)
                    return Ok(avg);
                return NotFound();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

    }
}
