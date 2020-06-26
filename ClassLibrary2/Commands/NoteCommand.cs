using ClassLibrary1;
using ClassLibrary1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Commands
{
    public class NoteCommand
    {
        private readonly MonProjetDbContext _context;

        public NoteCommand(MonProjetDbContext context)
        {
            _context = context;
        }

        public int Ajouter(Note a)
        {
            _context.Notes.Add(a);
            return _context.SaveChanges();
        }

        public void Modifier(Note a)
        {
            Note updNot = _context.Notes.Where(ele => ele.NoteId == a.NoteId).FirstOrDefault();

            if (updNot != null)
            {
                updNot.Notation = a.Notation;
                updNot.Matiere = a.Matiere;
                updNot.Appreciation = a.Appreciation;
                updNot.Eleve = a.Eleve;
                updNot.DateNote = a.DateNote;
                                
            }

            _context.SaveChanges();
        }

        public void Supprimer(int NoteId)
        {
            Note delnot = _context.Notes.Where(not => not.NoteId == NoteId).FirstOrDefault();

            if (delnot != null)
            {
                _context.Notes.Remove(delnot);

                _context.SaveChanges();
            }
        }
    }
}
