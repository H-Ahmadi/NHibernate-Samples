using System;
using System.Collections.Generic;
using System.Text;

namespace OptimisticConcurrency.Model
{
    public class Person
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
