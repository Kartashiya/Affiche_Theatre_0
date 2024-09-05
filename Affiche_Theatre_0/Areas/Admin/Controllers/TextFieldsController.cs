using Affiche_Theatre_0.Domain;
using Affiche_Theatre_0.Domain.Entities;
using Affiche_Theatre_0.Service;
using Microsoft.AspNetCore.Mvc;

namespace Affiche_Theatre_0.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;
        public TextFieldsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Edit(string codeWord) //ищем кодовое слово и передаём его в представление
        {
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid) //если модель валидная, то сохраняем в БД и перенаправляем на homecontroller
            {
                dataManager.TextFields.SaveTextFields(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
    }
}
