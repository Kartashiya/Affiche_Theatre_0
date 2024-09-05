using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Affiche_Theatre_0.Domain;
using Affiche_Theatre_0.Domain.Entities;
using Affiche_Theatre_0.Service;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace Affiche_Theatre_0.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddAffichesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment; //для сохр картинок
        public AddAffichesController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }
        //если афиша не найдена, то добавить её. если есть - выбрать из БД
        public IActionResult Edit(Guid id)
        {
            //если нет id, то дефолтный
            var entity = id == default ? new Affiche() : dataManager.Affiches.GetAfficheById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Affiche model, IFormFile titleImageFile)
        {
            //if (ModelState.IsValid)
            //{
                //если не равно 0, то для названия картинки модели берем название из файла
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    //создаём картинку в нашу папку
                    using var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create);
                    titleImageFile.CopyTo(stream);
                }
                dataManager.Affiches.SaveAffiches(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            //}
            //return View(model);
            
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Affiches.DeleteAffiches(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
