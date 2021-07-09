using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhamacySystemRestructure.Model;
using PhamacySystemRestructure.Interfaces;

namespace PhamacySystemRestructure.Controllers
{
    [ApiController]
    public class MedicineController : ControllerBase
    {

        private IMedicineRepository _medicines;

        public MedicineController(IMedicineRepository medicines)
        {
            _medicines = medicines;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetMedicines()
        {
            return Ok(_medicines.GetMedicines());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetMedicine(int id)
        {
            var medicines = _medicines.GetMedicine(id);

            if (medicines != null)
            {
                return Ok(_medicines.GetMedicine(id));
            }
            return NotFound($"Medicine with ID: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddMedicine(Medicine medicines)
        {
            _medicines.AddMedicine(medicines);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
                medicines.MId, medicines);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteMedicine(int id)
        {
            var medicines = _medicines.GetMedicine(id);

            if (medicines != null)
            {
                _medicines.DeleteMedicine(medicines);
                return Ok();

            }
            return NotFound($"Medicine with ID: {id} was not found");

        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditMedicine(int id, Medicine medicines)
        {
            var exixtingMedicine = _medicines.GetMedicine(id);

            if (exixtingMedicine != null)
            {
                medicines.MId = exixtingMedicine.MId;
                _medicines.EditMedicine(medicines);

            }
            return Ok(medicines);

        }

    }
}
