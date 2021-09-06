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
            new Docente{ID=1, Nome="Mario", Cognome = "Rossi", Email = "m.rossi@ciao.com", Telefono = "32323232", Lezioni = new List<Lezione>()}
        };
        public Docente Add(Docente item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Docente item)
        {
            throw new NotImplementedException();
        }

        public List<Docente> Fetch()
        {
            throw new NotImplementedException();
        }

        public Docente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Docente Update(Docente item)
        {
            throw new NotImplementedException();
        }
    }
}
