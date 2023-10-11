using Microsoft.Win32;
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
using System.Xml.Serialization;
using System.IO;
using Tripple_P.Services;
using Tripple_P.Models;
using Tripple_P.Views.Planning;

namespace Tripple_P
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Project currentProject;
        private string currentProjectFolder;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResetUI()
        {
            foreach (var depObj in Utilities.FindVisualChildren(this))
            {
                var control = depObj as IMyDataControl;
                control?.ResetData();
            }
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Project Files|*.ppp";
            dialog.Title = "Create a New Project";

            if  (dialog.ShowDialog() == true)
            {
                string projectName = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName);
                string projectPath = System.IO.Path.GetDirectoryName(dialog.FileName);

                currentProject = ProjectManager.CreateNewProject(projectName, projectPath);
                currentProjectFolder = System.IO.Path.Combine(projectPath, projectName);

                ResetUI();
            }
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".ppp";
            openFileDialog.Filter = "Tripple P Project Files (*.ppp)|*.ppp";

            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string filename = openFileDialog.FileName;
                currentProject = ProjectManager.OpenExistingProject(filename);
                currentProjectFolder = System.IO.Path.GetDirectoryName(filename);

                var planningData = currentProject.PlanningData;  // Changed from PlanningData.AllData to AllData

                // Assuming you have references to your main tab views
                PlanningView planningView = new PlanningView();
                planningView.LoadPlanningData(planningData);

                // TODO: Do the same for other main tabs...
            }
        }

        private void SaveProject_Click(object sender, RoutedEventArgs e)
        {
            if (currentProject == null)
            {
                currentProject = new Project();
            }

            
            PlanningView planningView = this.planningControl;
            var planningData = planningView.CollectPlanningData();
            currentProject.PlanningData = planningData;

            // TODO: Do the same for other main tabs...

            ProjectManager.SaveProject(currentProject, currentProjectFolder);
            MessageBox.Show("Project saved successfully!");
        }
    }
}
