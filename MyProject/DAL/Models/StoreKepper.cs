using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_1.DAL.Models
{
    public class StoreKeeper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Details> Details { get; set; }
    }
}