using Microsoft.AspNetCore.Mvc;
using RideShare.Business.Managers.Ride;
using RideShare.ViewModel;
using RideShare.ViewModel.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RideShareAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {

        private readonly IRideManager _rideManager;

        public RideController(IRideManager rideManager)
        {
            _rideManager = rideManager;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddRide(RideCreateViewModel data)
        {
            var success = _rideManager.AddAsync(data);
            return Ok(success);
        }

        //[HttpGet]
        //[Route("Find/{id}")]
        //public ActionResult<RideCreateViewModel> GetById(int id)
        //{
        //    var ride = _context.Ride.Find(id);
        //    if (ride != null)
        //    {
        //        return ride;
        //    }
        //    else
        //        return NotFound();

        //}

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<List<RideViewModel>>> GetAllAsync()
        {
            return await _rideManager.GetAll();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<RideViewModel>> Update(RideUpdateViewModel model)
        {
            var success = _rideManager.Update(model);
            if (success)
                return Ok();
            else
                return BadRequest();
        }


        [HttpPost]
        [Route("Find")]
        public async Task<ActionResult<List<RideViewModel>>> Find(RideQueryModel query)
        {
            var rides = _rideManager.Find(query);

            return Ok(rides);
        }



    }
}
