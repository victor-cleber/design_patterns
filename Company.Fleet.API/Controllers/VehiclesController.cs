using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Company.Fleet.Domain;

namespace Company.Fleet.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RepositoryVehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleDetran _vehicleDetran;

        public RepositoryVehiclesController(IVehicleRepository  vehicleRepository, IVehicleDetran vehicleDetran)
        {
            this._vehicleRepository = vehicleRepository;
            this._vehicleDetran = vehicleDetran;
        }
        
        [HttpGet]
        public IActionResult Get() => Ok(_vehicleRepository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            _vehicleRepository.Add(vehicle);
            return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Vehicle vehicle){
            _vehicleRepository.Update(vehicle);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id){
            var vehicle = _vehicleRepository.GetById(id);

            if(vehicle == null)
                return NotFound();
            
            _vehicleRepository.Delete(vehicle);
            
            return NoContent();
        }

        [HttpPut("{id}/schedule")]
        public IActionResult Put(Guid id){
            _vehicleDetran.ScheduleInspection(id);

            return NoContent();
        }

    }
}
