using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Affiche_Theatre_0.Domain;
using Affiche_Theatre_0.Domain.Entities;
using Affiche_Theatre_0.Service;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;
using System.IO;

namespace Affiche_Theatre_0.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddActorsController : Controller
    {
        private readonly AppDbContext context;
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment; //для сохр картинок

        public AddActorsController(AppDbContext context, DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }
        //страница для редактирования актёров (удалить, добавить, изменить данные)
        public IActionResult Index()
        {
            return View(dataManager.Actors.GetAllActors());
        }

        //если улуга не найдена, то добавить её. если есть - выбрать из БД
        public IActionResult Edit(Guid id)
        {
            //если нет id, то дефолтный
            var entity = id == default ? new Actor() : dataManager.Actors.GetActorById(id);
            return View(entity);
        }

        [HttpPost]

        //public async Task<IActionResult> Edit(Actor model, IFormFile ActorPhotoPath)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //если не равно 0, то для названия картинки модели берем название из файла
        //        if (ActorPhotoPath != null)
        //        {
        //            //путь к папке images
        //            string path = "/images/" + ActorPhotoPath.FileName;
        //            //сохраняем файл в папку images в каталоге wwwroot
        //            using (var fileStream = new FileStream(hostEnvironment.WebRootPath + path, FileMode.Create))
        //            {
        //                await ActorPhotoPath.CopyToAsync(fileStream);
        //            }
        //            FileModel file = new FileModel { Name = ActorPhotoPath.FileName, Path = path };
        //            context.Files.Add(file);
        //            context.SaveChanges();
        //        }
        //        dataManager.Actors.SaveActor(model);
        //        return RedirectToAction(nameof(AddActorsController.Index), nameof(AddActorsController).CutController());
        //    }
        //    return View(model);
        //}
        public IActionResult Edit(Actor model, IFormFile ActorPhotoPath)
        {
            //if (ModelState.IsValid)
            //{


                if (ActorPhotoPath != null)
                {
                    model.ActorPhotoPath = ActorPhotoPath.FileName;
                    //создаём картинку в нашу папку
                    using var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/", ActorPhotoPath.FileName), FileMode.Create);
                    ActorPhotoPath.CopyTo(stream);
                }
                dataManager.Actors.SaveActor(model);
                return RedirectToAction(nameof(AddActorsController.Index), nameof(AddActorsController).CutController());
            //}
            //return View(model);

        }


        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Actors.DeleteActor(id);
            return RedirectToAction(nameof(AddActorsController.Index), nameof(AddActorsController).CutController());
        }
    }
}
