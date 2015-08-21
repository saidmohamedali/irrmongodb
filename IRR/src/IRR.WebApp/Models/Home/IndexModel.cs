using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRRCalulation.WebApp.Models.Home
{
    public class IndexModel
    {
        public List<IRRDefinition> IRRDefinitions { get; set; }
    }
}