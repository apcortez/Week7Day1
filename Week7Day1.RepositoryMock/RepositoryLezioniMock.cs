using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day1.Core.Entities;
using Week7Day1.Core.InterfaceRepositories;

namespace Week7Day1.RepositoryMock
{
    public class RepositoryLezioniMock : ILezioneRepository
    {
        public static List<Lezione> lezioni = new List<Lezione>();
        public Lezione Add(Lezione item)
        {
            if (lezioni.Count == 0)
            {
                item.LezioneID = 1;
            }
            else
            {
                item.LezioneID = lezioni.Max(l => l.LezioneID) + 1;
            }

            var corso = RepositoryCorsiMock.corsi.FirstOrDefault(c => c.CodiceCorso == item.CodiceCorso);
            var docente = RepositoryDocentiMock.docenti.FirstOrDefault(d => d.ID == item.DocenteID);
            item.Corso = corso;
            item.Docente = docente;
            corso.Lezioni.Add(item);

            lezioni.Add(item);
            return item;
        }

        public bool Delete(Lezione item)
        {
            lezioni.Remove(item);
            return true;
        }

        public List<Lezione> Fetch()
        {
            return lezioni;
        }

        public Lezione GetByLezioneId(int id)
        {
            return lezioni.Find(l => l.LezioneID == id);
        }

        public List<Lezione> GetLezioniByCodice(string codice)
        {
            return lezioni.Where(l => l.CodiceCorso == codice).ToList();
        }

        public List<Lezione> GetLezioniByNome(string nome)
        {
            return lezioni.Where(l => l.Corso.Nome == nome).ToList();
        }

        public Lezione Update(Lezione item)
        {

            var old = lezioni.FirstOrDefault(l => l.LezioneID == item.LezioneID);
            old.Aula = item.Aula;
            return item;
        }
    }
}
