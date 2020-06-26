using ClassLibrary1;
using ClassLibrary1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Queries
{
    public class NoteQuery
    {
        private readonly MonProjetDbContext _context;

        public NoteQuery(MonProjetDbContext context)
        {
            _context = context;
        }

        public IQueryable<Note> GetAll()
        {
            return _context.Notes;
        }

        public IQueryable<Note> GetById(int id)
        {
            return _context.Notes.Where(a => a.NoteId == id);
        }
    }
}
