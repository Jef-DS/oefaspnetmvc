using oef7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef7.Services
{
    public interface ISchoolRepository
    {
        void AddCursist(Cursist c);
        void UpdateCursist(Cursist c);
        void DeleteCursist(Cursist c);
        IList<Cursist> GetCursisten();
        void AddCursus(Cursus c);
        void UpdateCursus(Cursus c);
        void DeleteCursus(Cursus c);
        IList<Cursus> GetCursussen();
        void AddInschrijving(Inschrijving i);
        void UpdateInschrijving(Inschrijving i);
        void DeleteInschrijving(Inschrijving i);


    }
    public class SchoolRepository
    {
    }
}
