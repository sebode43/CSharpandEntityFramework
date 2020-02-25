using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharpandEntityFrameworkLibrary.Models {
    public class Customer {

        [Key] //primary key
        public int ID { get; set; }
        //[StringLength(30)] attribute for Name
        //[Required] attribute that makes default items that can be null not null
        public string Name { get; set; }
        public double Sales { get; set; }
        public bool Active { get; set; } //if there is data you cannot make it not null immediately

        public override string ToString() => $"{ID}. {Name} | {Sales} | {Active}";

        public Customer() {

        }



    }
}
