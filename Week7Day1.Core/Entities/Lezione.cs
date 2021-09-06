using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Day1.Core.Entities
{
    public class Lezione
    {
        public int LezioneID { get; set; }
        public DateTime DataOraInizio { get; set; }
        public int Durata { get; set; }

        public string Aula { get; set; }

        //FK
        public int DocenteID { get; set; }
        public Docente Docente { get; set; }
        public string CodiceCorso { get; set; }
        public Corso Corso { get; set; }

        public override string ToString()
        {
            return $"{LezioneID}\t{DataOraInizio}\t{Aula}\t{Durata}\t{Docente.ToString()}\t{Corso.ToString()}";
        }
    }
}
