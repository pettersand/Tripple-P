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

        public Dictionary<string, object> CollectPlanningData()
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

        public void LoadPlanningData(object planningData)
        {
            if (planningData == null) return;

            // Cast the object back to the original type, e.g., Dictionary<string, object>
            var data = planningData as Dictionary<string, object>;

            // Load data into each sub-tab control
            foreach (var depObj in Utilities.FindVisualChildren(this))
            {
                var control = depObj as IMyDataControl;
                if (control != null && data.ContainsKey(control.GetType().Name))
                {
                    control.LoadData(data[control.GetType().Name]);
                }
            }
        }

    }
}
