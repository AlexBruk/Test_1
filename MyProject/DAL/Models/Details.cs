using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test_1.DAL.Models
{
    [Table("Details")]
    public class Details
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        [Display(Name = "Особоучитываемая")]
        public bool? Special { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата добавления")]
        public DateTime DateAdded { get; set; }

        public int StoreKeeperId { get; set; }

        [ForeignKey("StoreKeeperId")]
        public virtual StoreKeeper StoreKeeper { get; set; }
    }
}