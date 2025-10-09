using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ
{
    internal class Product
    {
        public required int Id { get; set; }
        public string? Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }
    }
}


