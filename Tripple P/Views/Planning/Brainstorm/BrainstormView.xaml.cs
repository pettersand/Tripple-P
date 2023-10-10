using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Tripple_P.Models;
using static Tripple_P.Services.Interfaces;

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
            get { return _projectDescription; }
        set 
        {
            if (_projectDescription != value)
                {
                    _projectDescription = value;
                    OnPropertyChanged("ProjectDescription");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Feature> Features { get; set; } = new ObservableCollection<Feature>();
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BrainstormView()
        {
            InitializeComponent();
            Features = new ObservableCollection<Feature>();
            Features.Add(new Feature());
            this.DataContext = new Models.Brainstorm();

        }

        public void SetDataContext(Project project)
        {
            this.DataContext = project;
        }

        public void LoadData(Models.Brainstorm brainstormData)
        {
            if (brainstormData != null)
            {
                ProjectDescription = brainstormData.ProjectDescription;
                ProjectDescriptionTextBox.Text = brainstormData.ProjectDescription;
                Features.Clear();
                foreach (var feature in brainstormData.Features)
                {
                    Features.Add(feature);
                }
            }
        }

        public Models.Brainstorm GetData()
        {
            var brainstormData = new Models.Brainstorm
            {
                ProjectDescription = SaveProjectDescription(),
                Features = new List<Feature>(Features)
            };
            return brainstormData;
        }

        public string SaveProjectDescription()
        {
            ProjectDescription = ProjectDescriptionTextBox.Text;
            return ProjectDescription;
        }
    }
}
