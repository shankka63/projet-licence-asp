using ClassLibrary1;
using ClassLibrary1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Commands
{
    public class AbsenceQuery
    {
        private readonly MonProjetDbContext _context;

        public AbsenceQuery(MonProjetDbContext context)
        {
            _context = context;
        }

        public IQueryable<Absence> GetAll()
        {
            return _context.Absences;
        }

        public IQueryable<Absence> GetById(int id)
        {
            return _context.Absences.Where(a => a.AbsenceId == id);
        }
    }
}
