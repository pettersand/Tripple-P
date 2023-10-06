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

namespace Tripple_P.Views.Planning.Brainstorm
{
    /// <summary>
    /// Interaction logic for Brainstorms.xaml
    /// </summary>
    public partial class Brainstorm : UserControl, INotifyPropertyChanged

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

        public Brainstorm()
        {
            InitializeComponent();
            this.DataContext = this;

            Features.Add(new Feature { Name = "Login", Category = "Authentication", Priority = "High", Description = "Create user login feature" });
        }

        public void LoadProjectDescription(string description)
        {
            ProjectDescription = description;
            ProjectDescriptionTextBox.Text = description;
        }

        public string SaveProjectDescription()
        {
            ProjectDescription = ProjectDescriptionTextBox.Text;
            return ProjectDescription;
        }

        private void FeaturesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
