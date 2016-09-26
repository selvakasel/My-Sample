using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intselva.Models
{
    public class Class1
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public Int32 Rating { get; set; }
        public Int16 Status { get; set; }

    }
    public class jQueryDataTableParamModel
    {
        public string sEcho { get; set; }
        public string sSearch { get; set; }
        public int iDisplayLength { get; set; }
        public int iDisplayStart { get; set; }
        public int iColumns { get; set; }
        public int iSortingCols { get; set; }
        public string sColumns { get; set; }

    }
}