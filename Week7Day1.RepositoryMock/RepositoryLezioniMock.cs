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
            throw new NotImplementedException();
        }

        public bool Delete(Lezione item)
        {
            throw new NotImplementedException();
        }

        public List<Lezione> Fetch()
        {
            throw new NotImplementedException();
        }

        public Lezione GetByLezioneId(int id)
        {
            throw new NotImplementedException();
        }

        public Lezione Update(Lezione item)
        {
            throw new NotImplementedException();
        }
    }
}
