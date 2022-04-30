using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Grad
    {
        public int GradId { get; set; }
        public string Naziv { get; set; }
        public string Drzava { get; set; }
        public int Naseljenost { get; set; }
        public string Valuta { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public List<Rezervacija> Rezervacije { get; set; } = new List<Rezervacija>();

    }
}
