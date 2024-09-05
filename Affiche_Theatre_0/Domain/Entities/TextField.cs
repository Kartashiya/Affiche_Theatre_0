﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affiche_Theatre_0.Domain.Entities
{
    public class TextField : EntityBase //для редактирования "о нас", "контакты"
    {
        public string CodeWord { get; set; } //ключевое слово, по которому будем обращаться

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = "Содержание страницы")]
        public override string Text { get; set; } = "Содержание заполняется администратором";
    }
}
