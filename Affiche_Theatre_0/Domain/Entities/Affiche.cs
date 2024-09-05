using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affiche_Theatre_0.Domain.Entities
{
    public class Affiche : EntityBase
    {
        [Required(ErrorMessage = "Введите название спектакля")]
        [Display(Name = "Название спектакля")]
        public override string Title { get; set; }

        [Required(ErrorMessage = "Введите краткое описание")]
        [Display(Name = "Краткое описание")]
        public string Short_Text { get; set; }

        [Required(ErrorMessage = "Введите полное описание")]
        [Display(Name = "Полное описание")]
        public override string Text { get; set; }

        [Required(ErrorMessage = "Введите титульную картинку")]
        [Display(Name = "Титульная картинка")]
        public string TitleImagePath { get; set; }

        [Required(ErrorMessage = "Введите автора")]
        [Display(Name = "Автор")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Введите жанр")]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Введите рейтинг")]
        [Display(Name = "Рейтинг")]
        public uint Age_limit { get; set; }

        [Required(ErrorMessage = "Введите длительность спектакля")]
        [Display(Name = "Длительность")]
        public string Duration { get; set; }

        [Required(ErrorMessage = "Введите дату и время спектакля в формате дд.ММ.гггг")]
        [Display(Name = "Дата и время спектакля")]
        public DateTime Date_Spectacle { get; set; }

        [Display(Name = "Пушкинская карта")]
        public bool Pyshkin_Card { get; set; }
    }
}
