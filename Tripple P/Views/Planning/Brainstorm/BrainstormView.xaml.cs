﻿using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tripple_P.Models;
using Tripple_P.Services;

namespace Tripple_P.Views.Planning.Brainstorm
{
    /// <summary>
    /// Interaction logic for Brainstorm.xaml
    /// </summary>
    public partial class BrainstormView : UserControl, INotifyPropertyChanged

    {
        private string _projectDescription;
        public string ProjectDescription
        {
            get => _projectDescription;
            set
            {
                if (_projectDescription != value)
                {
                    _projectDescription = value;
                    OnPropertyChanged(nameof(ProjectDescription));
                }
            }
        }

        public ObservableCollection<Feature> Features { get; } = new ObservableCollection<Feature>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BrainstormView()
        {
            InitializeComponent();
            Features = new ObservableCollection<Feature>
            {
                new Feature()
            };
        }

        public void LoadData(BrainstormTab data)
        {
            if (data != null)
            {
                this.DataContext = data;
                ProjectDescription = data.ProjectDescription;
                Features.Clear();
                foreach (var feature in data.Features)
                {
                    Features.Add(feature);
                }
            }
        }

        public BrainstormTab GetData()
        {
            Debug.WriteLine("Entering GetData");
            Debug.WriteLine($"Start of GetData - ProjectDescription: {ProjectDescription}, Features Count: {Features.Count}");

            var data = new BrainstormTab
            {
                ProjectDescription = ProjectDescription,
                Features = new List<Feature>(Features)
            };
            Debug.WriteLine($"Collected Data - ProjectDescription: {data.ProjectDescription}, Features Count: {data.Features.Count}");
            Debug.WriteLine("Exiting GetData");
            return data;
        }

        public void ResetData(Project project)
        {
            ProjectDescription = "";
            Features.Clear();
            this.DataContext = project.PlanningData.BrainstormData;
        }
    }
}
