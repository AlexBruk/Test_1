using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_1.Models.OtherModels
{
    public class RezInfo
    {

        public RezInfo()
        {
            Messages = new List<string>();
        }
        public IEnumerable<string> Messages { get; set; }

        public bool Success { get; set; }

        public string Info { get; set; }

    }
}