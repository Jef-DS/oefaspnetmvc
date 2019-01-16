using Microsoft.AspNetCore.Mvc;
using oef6.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef6.ViewComponents
{
    [ViewComponent]
    public class PersoonVC:ViewComponent
    {
        private PersoonRepository _repo;
        public PersoonVC(PersoonRepository repo)
        {
            this._repo = repo;
        }
        public IViewComponentResult Invoke()
        {
            int aantal = _repo.Aantal;
            String resultaat = aantal == 1? $"Er is {aantal} persoon geregistreerd":
                      $"Er zijn {aantal} personen geregistreerd";
            return View((Object)resultaat);
        }
    }
}
