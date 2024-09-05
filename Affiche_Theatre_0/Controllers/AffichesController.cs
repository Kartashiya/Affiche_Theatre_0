using Affiche_Theatre_0.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Affiche_Theatre_0.Controllers
{
    public class AffichesController : Controller
    {
        private readonly DataManager dataManager;

        public AffichesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Affiches.GetAfficheById(id));
            }
            //если посмотреть все услуги
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageIndex");
            return View(dataManager.Affiches.GetInfAffiche());
        }
    }
}