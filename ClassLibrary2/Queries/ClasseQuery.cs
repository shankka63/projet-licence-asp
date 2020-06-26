using ClassLibrary1;
using ClassLibrary1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Queries
{
    public class ClasseQuery
    {
        private readonly MonProjetDbContext _context;

        public ClasseQuery(MonProjetDbContext context)
        {
            _context = context;
        }

        public IQueryable<Classe> GetAll()
        {
            return _context.Classes;
        }

        public IQueryable<Classe> GetById(int id)
        {
            return _context.Classes.Where(a => a.ClasseId == id);
        }
    }
}
