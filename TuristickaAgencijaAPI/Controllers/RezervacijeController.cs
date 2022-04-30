using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TuristickaAgencijaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervacijeController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public RezervacijeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetRezervacije()
        {
            return Ok(unitOfWork.RezervacijeRepository.GetAll());
        }
        [HttpPost]
        public IActionResult AddRezervacija(Rezervacija rezervacija)
        {
            
            unitOfWork.RezervacijeRepository.Add(rezervacija);
            unitOfWork.Save();

            return Ok();
        }
        
       
    }
}
