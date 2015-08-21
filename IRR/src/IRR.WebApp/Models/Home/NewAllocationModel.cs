using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRRCalulation.WebApp.Models.Home
{
    public class NewAllocationModel
    {
        [HiddenInput(DisplayValue = false)]
        public string IRRDefinitionId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}