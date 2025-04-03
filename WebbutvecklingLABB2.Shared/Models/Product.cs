using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbutvecklingLABB2.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool IsDiscontinued { get; set; }


    }
}