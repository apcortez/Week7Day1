using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day1.Core.Entities;
using Week7Day1.Core.InterfaceRepositories;

namespace Week7Day1.RepositoryMock
{
    public class RepositoryCorsiMock : ICorsoRepository
    {
        //Dati finti
        public static List<Corso> corsi = new List<Corso>()
        {
            new Corso{ CodiceCorso = "C-01", Nome = "Pre-Academy I", Descrizone = "Corso base c# livello1"},
            new Corso{ CodiceCorso = "C-02", Nome = "Academy I", Descrizone = "Corso base c# livello2"}
        };

        public Corso Add(Corso item)
        {
            corsi.Add(item);
            return item;
        }

        public bool Delete(Corso item)
        {
                corsi.Remove(item);
            return true;
        }

        public List<Corso> Fetch()
        {
            return corsi;
        }

        public Corso GetByCodice(string codice)
        {
            return corsi.Find(c => c.CodiceCorso == codice);
        }



        public Corso Update(Corso item)
        {
            var old = corsi.FirstOrDefault(c => c.CodiceCorso == item.CodiceCorso);
            old.Nome = item.Nome;
            old.Descrizone = item.Descrizone;
            return item;
        }
    }
}
