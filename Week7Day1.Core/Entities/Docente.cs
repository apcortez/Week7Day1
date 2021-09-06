using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Day1.Core.Entities
{
    public class Docente :Persona
    {
        public string Telefono { get; set; }

        public List<Lezione> Lezioni { get; set; }

        public override string ToString()
        {
            return $"Id: {ID}\t{Nome}\t{Cognome}\t{Email}\t{Telefono}";
        }
    }
}
