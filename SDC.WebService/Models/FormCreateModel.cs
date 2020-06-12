using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDC.WebService.Models
{
    public class FormCreateModel
    {
        public bool AddHeader { get; set; }

        public bool AddFooter { get; set; }

        public string FormId { get; set; }

        public string Lineage { get; set; }

        public string FullUri { get; set; }

    }
}
