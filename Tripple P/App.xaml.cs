using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Media;

namespace Tripple_P
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            PrimaryColor primary = PrimaryColor.Teal;
            Color primaryColor = SwatchHelper.Lookup[(MaterialDesignColor)primary];

            SecondaryColor secondary = SecondaryColor.Orange;
            Color secondaryColor = SwatchHelper.Lookup[(MaterialDesignColor)secondary];

            IBaseTheme baseTheme = Theme.Dark;

            ITheme theme = Theme.Create(baseTheme, primaryColor, secondaryColor);
            ResourceDictionaryExtensions.SetTheme(this.Resources, theme);
        }
    }
}
