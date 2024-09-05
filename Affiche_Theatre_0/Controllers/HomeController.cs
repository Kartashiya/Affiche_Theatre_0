using Microsoft.AspNetCore.Mvc;
using Affiche_Theatre_0.Domain;

namespace Affiche_Theatre_0.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
