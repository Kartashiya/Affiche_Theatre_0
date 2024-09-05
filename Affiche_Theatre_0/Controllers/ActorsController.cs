using Microsoft.AspNetCore.Mvc;
using Affiche_Theatre_0.Domain;

namespace Affiche_Theatre_0.Controllers
{
    public class ActorsController : Controller
    {
        private readonly DataManager dataManager;

        public ActorsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index()
        {
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageActors");
            return View(dataManager.Actors.GetAllActors());
        }
    }
}
