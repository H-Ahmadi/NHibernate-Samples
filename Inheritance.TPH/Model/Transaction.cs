using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance.TPH.Model
{
    public abstract class Transaction
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long Amount { get; set; }
    }
}
