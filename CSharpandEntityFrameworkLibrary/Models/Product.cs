using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharpandEntityFrameworkLibrary.Models {
    public class Product {
        public int ID { get; set; }
        [StringLength(10)]
        [Required]
        public string Code { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }

        public Product() { }
        public override string ToString() => $"{ID}. {Code} | {Name} | {Price}";


    }
   

}
