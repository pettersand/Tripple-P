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
using System.Diagnostics;

namespace Tripple_P.Views.Planning
{
    /// <summary>
    /// Interaction logic for PlanningView.xaml
    /// </summary>
    public partial class PlanningView : UserControl
    {
        public PlanningView()
        {
            InitializeComponent();
        }

        public void ResetData(Project project)
        {
            if (this.FindName("brainstormControl") is BrainstormView brainstormView)
            {
                brainstormView.ResetData(project);
            }

            // TODO: Reset data for other child controls...
        }

        public PlanningTab CollectPlanningData()
        {
            Debug.WriteLine("Entering CollectPlanningData");
            PlanningTab planningData = new PlanningTab();

            Debug.WriteLine($"Bfter Getting Data CollectPlanningData - ProjectDescription: {planningData.BrainstormData.ProjectDescription}, Features Count: {planningData.BrainstormData.Features.Count}");

            if (this.FindName("brainstormControl") is BrainstormView brainstormView)
            {
                Debug.WriteLine("Found brainstormControl. Getting data.");
                planningData.BrainstormData = brainstormView.GetData();
            }
            Debug.WriteLine($"After Getting Data - ProjectDescription: {planningData.BrainstormData.ProjectDescription}, Features Count: {planningData.BrainstormData.Features.Count}");

            // TODO: Collect data from other child controls
            Debug.WriteLine("Exiting CollectPlanningData");
            return planningData;
        }

        public void LoadPlanningData(PlanningTab planningData)
        {
            if (planningData == null) return;

            if (this.FindName("brainstormControl") is BrainstormView brainstormView && planningData.BrainstormData != null)
            {
                brainstormView.LoadData(planningData.BrainstormData);
            }
        }

    }
}
