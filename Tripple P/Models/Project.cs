using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripple_P.Models
{
    public class Project
    {
        public string ProjectName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Planning PlanningData { get; set; }

        public class Planning
        {
            public Brainstorm BrainstormData { get; set; }
        }
    }

   
}
