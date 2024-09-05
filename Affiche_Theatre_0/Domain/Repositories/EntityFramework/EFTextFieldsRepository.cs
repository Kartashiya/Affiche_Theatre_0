using Affiche_Theatre_0.Domain.Entities;
using Affiche_Theatre_0.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affiche_Theatre_0.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        //связь объектов в БД
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public TextField GetTextFieldByCodeWord(string codeWord) //запись по ключ. слову
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public TextField GetTextFieldById(Guid id) //конкретная запись
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<TextField> GetTextFields() //все записи
        {
            return context.TextFields;
        }

        public void SaveTextFields(TextField entity) //сохранение
        {
            if (entity.Id == default) //новая запись есть, но без ID
                context.Entry(entity).State = EntityState.Added; //помечаем, что она новая
            else //если есть ID
                context.Entry(entity).State = EntityState.Modified; //помечаем, что изменён
            context.SaveChanges(); //сохранили изменения
        }
    }
}
