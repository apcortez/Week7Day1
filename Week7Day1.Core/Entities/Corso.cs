using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Day1.Core.Entities
{
    public class Corso
    {
        public string CodiceCorso { get; set; }
        public string Nome { get; set; }
        public string Descrizone { get; set; }

        public List<Studente> Studenti { get; set; }
        public List<Lezione> Lezioni { get; set; }

        public override string ToString()
        {
            return $"{CodiceCorso}\t{Nome}\t{Descrizone}";
        }
    }
}
