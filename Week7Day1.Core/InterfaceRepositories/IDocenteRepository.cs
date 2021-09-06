using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day1.Core.Entities;

namespace Week7Day1.Core.InterfaceRepositories
{
    public interface IDocenteRepository : IRepository<Docente>
    {
        public Docente GetById(int id);
    }
}
