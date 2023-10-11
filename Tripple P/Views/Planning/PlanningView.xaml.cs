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
using Tripple_P.Models;
using Tripple_P.Views.Planning.Brainstorm;
using static Tripple_P.Models.Project;

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

        public PlanningTab CollectPlanningData()
        {
            PlanningTab planningData = new PlanningTab();

            BrainstormView brainstormView = this.FindName("brainstormControl") as BrainstormView;
            if (brainstormView != null)
            {
                planningData.BrainstormData = brainstormView.GetData();
            }

            // TODO: Collect data from other child controls

            return planningData;
        }

        public void LoadPlanningData(PlanningTab planningData)
        {
            if (planningData == null) return;

            BrainstormView brainstormView = this.FindName("brainstormControl") as BrainstormView;
            if (brainstormView != null && planningData.BrainstormData != null)
            {
                brainstormView.LoadData(planningData.BrainstormData);
            }
        }

    }
}
