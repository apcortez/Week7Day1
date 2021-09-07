using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day1.Core.Entities;
using Week7Day1.Core.InterfaceRepositories;

namespace Week7Day1.RepositoryMock
{
    public class RepositoryStudentiMock : IStudenteRepository
    {
        public static List<Studente> studenti = new List<Studente>();
        public Studente Add(Studente item)
        {
            if (studenti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                item.ID = studenti.Max(s => s.ID) + 1;
            }

            var corso = RepositoryCorsiMock.corsi.FirstOrDefault(c => c.CodiceCorso == item.CodiceCorso);
            item.Corso = corso;
            corso.Studenti.Add(item);

            studenti.Add(item);
            return item;
        }

        public bool Delete(Studente item)
        {
            studenti.Remove(item);
            return true;
        }

        public List<Studente> Fetch()
        {
            return studenti;
        }

        public List<Studente> GetByCorso(string codicecorso)
        {
            return studenti.Where(s => s.CodiceCorso == codicecorso).ToList();

        }

        public Studente GetById(int id)
        {
            return studenti.Find(s => s.ID == id);
        }

        public Studente Update(Studente item)
        {
            var old = studenti.FirstOrDefault(s => s.ID == item.ID);
            old.Email = item.Email;
            return item;
        }
    }
}
