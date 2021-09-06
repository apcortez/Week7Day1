using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Day1.Core.Entities
{
    public class Studente  : Persona
    {
        public DateTime DataNascita { get; set; }
        public string TitoloStudio { get; set; }

        //FK
        public string CodiceCorso { get; set; }
        public Corso Corso { get; set; }

        public override string ToString()
        {
            return $"Id: {ID}\t{Nome}\t{Cognome}\t{Email}\t{DataNascita.ToLongDateString()}\t{TitoloStudio}\t{Corso.ToString()}";
        }
    }
}
