using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TuristickaAgencijaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public KorisnikController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

       
        [HttpGet("{id}")]
        public IActionResult GetRezervacijeKorisnika(string id)
        {
            var temp = new Korisnik { Id = id };
            var korisnik = unitOfWork.KorisnikRepository.SearchById(temp);

            var rezervacije = korisnik.Rezervacije;

            return Ok(rezervacije);
        }
    }
}
