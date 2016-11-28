using System;
using System.Collections.Generic;

namespace Test_1.Models.ViewModels
{
    public class DetailsViewModel
    {
        public DetailsViewModel()
        {
            Details = new List<Detail>();
        }
        public List<Detail> Details { get; set; }
    }

    public class Detail
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public bool? Special { get; set; }

        public DateTime DateAdded { get; set; }
        public string StoreKeeperName { get; set; }

    }
}