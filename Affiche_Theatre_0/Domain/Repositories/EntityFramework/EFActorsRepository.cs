using Affiche_Theatre_0.Domain.Entities;
using Affiche_Theatre_0.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Affiche_Theatre_0.Domain.Repositories.EntityFramework
{
    public class EFActorsRepository : IActorsRepository
    {
        //связь объектов в БД
        private readonly AppDbContext context;
        public EFActorsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Actor> GetAllActors() //все актеры
        {
            return context.Actors;
        }

        public Actor GetActorById(Guid id) //конкретный актер
        {
            return context.Actors.FirstOrDefault(x => x.Id == id);
        }

       

        public void SaveActor(Actor entity) //сохранение
        {
            if (entity.Id == default) //новая запись есть, но без ID
                context.Entry(entity).State = EntityState.Added; //помечаем, что она новая
            else //если есть ID
                context.Entry(entity).State = EntityState.Modified; //помечаем, что изменён
            context.SaveChanges(); //сохранили изменения
        }
        public void DeleteActor(Guid id) //удаление
        {
            context.Actors.Remove(new Actor() { Id = id }); //удаляем по конкретному id
            context.SaveChanges();
        }
    }
}
