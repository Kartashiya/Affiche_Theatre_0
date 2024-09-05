using Affiche_Theatre_0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affiche_Theatre_0.Domain.Repositories.Abstract
{
    public interface IAffichesRepository
    {
        IQueryable<Affiche> GetInfAffiche();                                //выборка всех спектаклей
        Affiche GetAfficheById(Guid id);                                    //выборка одного конкретного
        void SaveAffiches(Affiche entity);                                  //сохранить изменения в БД или
                                                                            //создать новый спектакль
        void DeleteAffiches(Guid id);                                       //удалить
    }
}
