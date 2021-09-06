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
            throw new NotImplementedException();
        }

        public bool Delete(Studente item)
        {
            throw new NotImplementedException();
        }

        public List<Studente> Fetch()
        {
            return studenti;
        }

        public Studente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Studente Update(Studente item)
        {
            throw new NotImplementedException();
        }
    }
}
