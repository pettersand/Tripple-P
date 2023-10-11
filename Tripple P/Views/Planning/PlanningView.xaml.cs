using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tripple_P.Services;
using Tripple_P.Views.Planning.Brainstorm;

namespace Tripple_P.Views.Planning
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PlanningView : UserControl
    {
        public PlanningView()
        {
            InitializeComponent();
        }

        public CollectPlanningData()
        {
            Dictionary<string, object> planningData = new Dictionary<string, object>();
            foreach (var depObj in Utilities.FindVisualChildren(this))
            {
                var control = depObj as IMyDataControl;
                if (control != null)
                {
                    var data = control.GetData();
                    planningData.Add(control.GetType().Name, data);
                }
            }
                return planningData;
        }

        public void LoadPlanningData(Planning planningData)
        {
            if (planningData == null) return;


            foreach (var depObj in Utilities.FindVisualChildren(this))
            {
                var control = depObj as IMyDataControl;
                if (control != null)
                {
                    var controlType = control.GetType().Name;
                    if (planningData.BrainstormData != null && controlType == "BrainstormView")
                    {
                        control.LoadData(planningData.BrainstormData);
                    }
                }
            }
        }

    }
}
