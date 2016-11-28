using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Test_1.Models.ViewModels
{
    public class AddDetailViewModel
    {
        public AddDetailViewModel()
        {
            StoreKeepers = new SelectList(Enumerable.Empty<int>(), "Id", "Name");
        }
        public int SelectedStoreKeeperId { get; set; }

        [Display(Name = "Кладовщики")]
        public SelectList StoreKeepers { get; set; }
        [Required(ErrorMessage = "не указан номенклатурный код")]
        [RegularExpression("[A-Za-zА-Яа-яЁё]{3}-[0-9]{6}", ErrorMessage = "Шаблон для ввода номенклатурного кода: ХХХ-111111")]
        public string Code { get; set; }
        [Required(ErrorMessage = "не указано название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "не указано количество")]
        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "Нельзя добавить деталей меньше чем 1")]
        public int Count { get; set; }
        [Required(ErrorMessage = "не указано особоучитываемое поле")]
        public bool Special { get; set; }
        [Required(ErrorMessage = "не указана дата")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата добавления")]
        public DateTime DateAdded { get; set; }
    }
}