using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRRCalulation.WebApp.Models.Home
{
    public class IRRDefinitionModel
    {
        public IRRDefinition IRRDefinition { get; set; }

        public NewAllocationModel NewAllocation { get; set; }

        public NewAncestorModel NewAncestor { get; set; }
    }
}