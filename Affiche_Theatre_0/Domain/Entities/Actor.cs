using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affiche_Theatre_0.Domain.Entities
{
    public class Actor
    {
        public Guid Id { get; set; } //первичный ключ

        [Required(ErrorMessage = "Введите ФИО актёра")]
        [Display(Name = "Фамилия Имя актёра")]
        public string FIO_Actor { get; set; }

        [Required(ErrorMessage = "Введите постановки")]
        [Display(Name = "Постановки")]
        public string Production { get; set; }

        [Required(ErrorMessage = "Введите краткое описание")]
        [Display(Name = "Краткое описание")]
        public string Short_Descript { get; set; }

        [Required(ErrorMessage = "Введите полное описание")]
        [Display(Name = "Полное описание")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Выберете фото актёра")]
        [Display(Name = "Фотография актёра")]
        public string ActorPhotoPath { get; set; }
    }
}
