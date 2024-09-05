using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Affiche_Theatre_0.Domain.Repositories.Abstract;

namespace Affiche_Theatre_0.Domain
{
    //класс помощник для управления репозиторием
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IAffichesRepository Affiches { get; set; }
        public IActorsRepository Actors { get; set; }

        //управление репозиториями
        public DataManager(ITextFieldsRepository textFieldsRepository, IAffichesRepository affichesRepository, IActorsRepository actorsRepository)
        {
            TextFields = textFieldsRepository;
            Affiches = affichesRepository;
            Actors = actorsRepository;
        }
    }
}
