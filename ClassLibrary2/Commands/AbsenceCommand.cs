using ClassLibrary1;
using ClassLibrary1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Commands
{
    public class AbsenceCommand
    {
        private readonly MonProjetDbContext _context;

        public AbsenceCommand(MonProjetDbContext context)
        {
            _context = context;
        }

        public int Ajouter(Absence a)
        {
            _context.Absences.Add(a);
            return _context.SaveChanges();
        }

        public void Modifier(Absence a)
        {
            Absence updAbs = _context.Absences.Where(abs => abs.AbsenceId == a.AbsenceId).FirstOrDefault();

            if (updAbs != null)
            {
                updAbs.Motif = a.Motif;
                updAbs.DateAbsence = a.DateAbsence;
                updAbs.Eleve = a.Eleve;
            }

            _context.SaveChanges();
        }

        public void Supprimer(int AbsenceId)
        {
            Absence delAbs = _context.Absences.Where(abs => abs.AbsenceId == AbsenceId).FirstOrDefault();

            if (delAbs != null)
            {
                _context.Absences.Remove(delAbs);

                _context.SaveChanges();
            }
        }
    }
}
