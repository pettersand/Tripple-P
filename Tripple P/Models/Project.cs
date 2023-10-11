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
        public PlanningTab PlanningData { get; set; }

        public Project()
        {
            PlanningData = new PlanningTab();
        }

        public class PlanningTab
        {
            public BrainstormTab BrainstormData { get; set; }

            public PlanningTab()
            {
                BrainstormData = new BrainstormTab();
            }
        }
    }
}
