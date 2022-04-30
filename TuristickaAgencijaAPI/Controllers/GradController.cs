using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace TuristickaAgencijaAPI.Controllers
{
    [Route("[controller]")]             
    [ApiController]
    public class GradController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public GradController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [SwaggerOperation(Summary = "Prikaz svih gradove")]
        //[Authorize(Roles ="Admin")]
        [HttpGet]
        public List<Grad> GetGradovi()
        {
            return unitOfWork.GradRepository.GetAll();
        }


        [SwaggerOperation(Summary = "Dodavanje novog grada")]
        [HttpPost]
        public IActionResult AddGrad(Grad grad)
        {
            unitOfWork.GradRepository.Add(grad);
            unitOfWork.Save();

            return Ok();
        }

        [SwaggerOperation(Summary = "Prikaz grada sa datim identifikatorom")]
        [HttpGet("{id}")]
        public IActionResult GetGrad(int id)
        {

            var grad = new Grad { GradId = id };
            return Ok(unitOfWork.GradRepository.SearchById(grad));
        }

        [SwaggerOperation(Summary = "Azuriranje grada")]
        [HttpPut]
        public IActionResult UpdateGrad(Grad grad)
        {
            unitOfWork.GradRepository.Update(grad);
            unitOfWork.Save();
            return Ok();
        }

        [SwaggerOperation(Summary = "Brisanje grada")]
        [HttpDelete("{id}")]
        public IActionResult DeleteGrad(int id)
        {
            var grad = new Grad { GradId = id };
            unitOfWork.GradRepository.Delete(grad);
            unitOfWork.Save();

            return Ok();
        }

    }
}
