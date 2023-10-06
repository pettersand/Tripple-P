using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tripple_P.Views.Planning.Brainstorm.Brainstorm;

namespace Tripple_P.Models
{
    public class Project
    {
        public string ProjectName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public List<Feature> Features { get; set; }
    }
}
