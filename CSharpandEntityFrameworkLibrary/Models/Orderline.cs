using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CSharpandEntityFrameworkLibrary.Models {
    public class Orderline {

        public int ID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

        public Orderline() {

        }

        public override string ToString() => $"{ID}. {Product.Code} | {Order.Description} | {Quantity}";

    }
}
