using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Test_1.Models.ViewModels
{
    public class AddStoreKeeperViewModel
    {

        public AddStoreKeeperViewModel()
        {
            
        }

        [Display(Name = "Кладовщики")]
        [Required(ErrorMessage = "не указано поле")]
        public string Name { get; set; }
    }
}