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
            foreach (var control in Utilities.FindVisualChildren<IMyDataControl>(this))
            {
                var data = control.GetData();
                planningData.Add(control.GetType().Name, data);
            }
            return planningData;
        }
    }
}
