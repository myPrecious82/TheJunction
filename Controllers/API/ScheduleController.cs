using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheJunction.Models;
using TheJunction.Repositories;
using TheJunction.ViewModels;

namespace TheJunction.Controllers.API
{
    [Route("api/schedules")]
    public class ScheduleController : Controller
    {
        private IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var results = _scheduleRepository.GetAllSchedules();

            return Ok(Mapper.Map<IEnumerable<ScheduleViewModel>>(results));
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]ScheduleViewModel sched)
        {
            // save to the database
            var vmSched = Mapper.Map<Schedule>(sched);

            if (ModelState.IsValid)
            {
                return Created($"api/schedules/{sched.Id}", Mapper.Map<ScheduleViewModel>(vmSched));
            }

            return BadRequest(ModelState);

        }
    }
}
