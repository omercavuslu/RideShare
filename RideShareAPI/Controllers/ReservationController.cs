using Microsoft.AspNetCore.Mvc;
using RideShare.Business.Managers.Ride;
using RideShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RideShareAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        private readonly IReservationManager _reservationManager;

        public ReservationController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddReservationAsync(ReservationCreateViewModel reservation)
        {
            var id = await _reservationManager.AddAsync(reservation);
            if(id != 0)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest("Yolcu sayısı dolmuştur");
            }
           
        }

        [HttpGet]
        [Route("Find")]
        public async Task<ActionResult<List<ReservationViewModel>>> GetAll()
        {
            return  await _reservationManager.GetAll();
        }
    }
}
