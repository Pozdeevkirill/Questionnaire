using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Models
{
    public class AnswerViewModel
    {
        //Блок А
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Activity { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public int AVGIncome { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string BestResult { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Difficulty { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Questions { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Instagram { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string  Site { get; set; }

        //Блок А-Б
        [Required(ErrorMessage = "Обязательное поле!")]
        public string PointA { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string PointB { get; set; }
        public string? Hypothesis1 { get; set; }
        public string? Hypothesis2 { get; set; }
        public string? Hypothesis3 { get; set; }
        public string? Hypothesis4 { get; set; }
        public string? Hypothesis5 { get; set; }

        //Package
        [Required(ErrorMessage = "Обязательное поле!")]
        public string First { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Second { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Thrid { get; set; }
    }
}
