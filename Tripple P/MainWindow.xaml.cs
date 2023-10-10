﻿using Microsoft.Win32;
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

                brainstormControl.SetDataContext(currentProject);
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

                brainstormControl.SetDataContext(currentProject);    
            }
        }

        private void SaveProject_Click(object sender, RoutedEventArgs e)
        {
            var brainstormData = brainstormControl.GetData();

            if (currentProject == null)
            {
                currentProject.PlanningData = new Project.Planning();
            }

            currentProject.PlanningData.BrainstormData = brainstormData;

            ProjectManager.SaveProject(currentProject, currentProjectFolder);
            MessageBox.Show("Project saved successfully!");
        }
    }
}
