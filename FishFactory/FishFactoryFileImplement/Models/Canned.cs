using System;
using System.Collections.Generic;
using System.Text;

namespace FishFactoryFileImplement.Models
{
    public class Canned
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, int> ProductComponents { get; set; }
    }
}
