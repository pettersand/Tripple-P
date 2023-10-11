using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripple_P.Models
{
    public class BrainstormTab
    {
        public string ProjectDescription { get; set; }
        public List<Feature> Features { get; set; }

        public BrainstormTab() 
        {
            ProjectDescription = "";
            Features = new List<Feature>();
        }


    }
    public class Feature
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }

        public Feature()
        {
            Name = "";
            Category = "";
            Priority = "";
            Description = "";
        }
    }

}
