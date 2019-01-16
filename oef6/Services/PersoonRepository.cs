using oef6.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef6.Services
{
    public class PersoonRepository:IEnumerable<Persoon>
    {
        private List<Persoon> _personen = new List<Persoon>();
        public void Add(Persoon p)
        {
            _personen.Add(p);
        }

        public IEnumerator<Persoon> GetEnumerator()
        {
            return _personen.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _personen.GetEnumerator();
        }

        public int Aantal { get
            {
                return _personen.Count();
            }
        }

    }
}
