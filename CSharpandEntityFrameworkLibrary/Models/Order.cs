﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharpandEntityFrameworkLibrary.Models {
    public class Order {

        public int ID { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } //virtual = don't make this part of the table; only retrieve data
        public virtual List<Orderline> Orderlines { get; set; }

        public override string ToString() => $"{ID}. {Description} | {Amount} | {Customer.Name}";

        public Order() {

        }

    }
}
