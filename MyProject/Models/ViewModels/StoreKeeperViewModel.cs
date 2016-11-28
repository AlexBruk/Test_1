using System.Collections.Generic;

namespace Test_1.Models.ViewModels
{
    public class StorekeeperViewModel
    {
        public StorekeeperViewModel()
        {
            Storekeepers = new List<Storekeeper>();
        }
        public List<Storekeeper> Storekeepers { get; set; }
    }

    public class Storekeeper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DetailsCount { get; set; }
    }
}