using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day1.Core.Entities;
using Week7Day1.Core.InterfaceRepositories;

namespace Week7Day1.RepositoryMock
{
    public class RepositoryDocentiMock : IDocenteRepository
    {
        public static List<Docente> docenti = new List<Docente>()
        {
            new Docente{ID=1, Nome="Mario", Cognome="Rossi", Email="mario@mail.it", Telefono="3331234567"},
            new Docente{ID=2, Nome="Giuseppe", Cognome="Bianchi", Email="giuseppe@mail.it", Telefono="3331434567"}
        };
        public Docente Add(Docente item)
        {
            if (docenti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                item.ID = docenti.Max(s => s.ID) + 1;
            }

            
            docenti.Add(item);
            return item;
        }

        public bool Delete(Docente item)
        {
            docenti.Remove(item);
            return true;
        }

        public List<Docente> Fetch()
        {
            return docenti;
        }

        public Docente GetById(int id)
        {
            return docenti.Find(d => d.ID == id);
        }

        public Docente Update(Docente item)
        {
            var old = docenti.FirstOrDefault(s => s.ID == item.ID);
            old.Email = item.Email;
            old.Telefono = item.Telefono;
            return item;
        }

        public Docente VerificaDocente(Docente docente)
        {
            return docenti.FirstOrDefault(d => d.Nome == docente.Nome && d.Cognome == docente.Cognome && d.Email == docente.Email);
        }
    }
}
