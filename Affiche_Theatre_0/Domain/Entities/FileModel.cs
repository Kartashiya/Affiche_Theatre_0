using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affiche_Theatre_0.Domain.Entities
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }    //имя файла
        public string Path { get; set; }    //путь в ФС
    }
}
