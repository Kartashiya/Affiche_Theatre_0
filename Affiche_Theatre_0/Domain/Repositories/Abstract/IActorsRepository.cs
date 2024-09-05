using Affiche_Theatre_0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affiche_Theatre_0.Domain.Repositories.Abstract
{
    public interface IActorsRepository
    {
        IQueryable<Actor> GetAllActors();   //вывод всех актёров театра
        Actor GetActorById(Guid id);        //выборка одного конкретного
        void SaveActor(Actor entity);       //сохранить изменения в БД
        void DeleteActor(Guid id);          //удалить
    }
}
