using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToysWebAPI.Models
{//  This class represent the Table Toy in DB
    public class Toy
    {
        // Creating Identity Field
        [Key]
        public int ToyId { get; set; }
        // name of the toy
        public string ToyName { get; set; }
        // manufacturer company of the toy
        public string ToyManufacturer { get; set; }
        // toy color
        public string ToyColor { get; set; }
        // toy retial price
        public double ToyPrice { get; set; }
        // Age group for which toy is made
        public string AgeGroup { get; set; }
    }
}