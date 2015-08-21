using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRRCalulation.WebApp.Models.Home
{

    public class NewFlowModel
    {
        
        [Required]
        [DataType(DataType.Text)]
        public string Type { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Direction { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public String Allocation { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public Double Value { get; set; }

        
    }
}