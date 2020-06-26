using ClassLibrary1;
using ClassLibrary1.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Queries
{
    public class EleveQuery
    {
        private readonly MonProjetDbContext _context;

        public EleveQuery(MonProjetDbContext context)
        {
            _context = context;
        }

        public IQueryable<Eleve> GetAll()
        {
            return _context.Eleves.Include(eleve => eleve.notes);
        }

        public IQueryable<Eleve> GetById(int id)
        {
            return _context.Eleves.Where(a => a.EleveId == id);
        }
    }
}
