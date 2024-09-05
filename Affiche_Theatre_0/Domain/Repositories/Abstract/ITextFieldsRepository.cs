using Affiche_Theatre_0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affiche_Theatre_0.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields();              //выборка всех текстовых полей
        TextField GetTextFieldById(Guid id);                //выборка по id
        TextField GetTextFieldByCodeWord(string codeWord);  //выборка по кодовому слову
        void SaveTextFields(TextField entity);              //сохранить измнения в БД
    }
}
