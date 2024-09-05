using Affiche_Theatre_0.Domain.Entities;
using Affiche_Theatre_0.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Affiche_Theatre_0.Domain.Repositories.EntityFramework
{
    public class EFAffichesRepository : IAffichesRepository
    {
        //связь объектов в БД
        private readonly AppDbContext context;
        public EFAffichesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteAffiches(Guid id) //удаление
        {
            context.Affiches.Remove(new Affiche() { Id = id }); //удаляем по конкретному id
            context.SaveChanges();
        }

        public Affiche GetAfficheById(Guid id) //конкретная запись
        {
            return context.Affiches.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Affiche> GetInfAffiche() //все записи
        {
            return context.Affiches;
        }

        public void SaveAffiches(Affiche entity) //сохранение
        {
            if (entity.Id == default) //новая запись есть, но без ID
                context.Entry(entity).State = EntityState.Added; //помечаем, что она новая
            else //если есть ID
                context.Entry(entity).State = EntityState.Modified; //помечаем, что изменён
            context.SaveChanges(); //сохранили изменения
        }
    }
}
