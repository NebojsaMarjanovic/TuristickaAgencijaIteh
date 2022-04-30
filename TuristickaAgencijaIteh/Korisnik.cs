using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Korisnik:IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public List<Rezervacija> Rezervacije { get; set; } = new List<Rezervacija>();


    }
}
