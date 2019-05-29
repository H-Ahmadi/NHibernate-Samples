using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject.Model
{
    public class Airport
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Coordinate Coordinate { get; set; }
    }
}
