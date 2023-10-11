using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Tripple_P.Services
{
    public static class Utilities
    {
        public static IEnumerable<DependencyObject> FindVisualChildren(DependencyObject depObj)
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is IMyDataControl)
                    {
                        yield return child;
                    }

                    foreach (DependencyObject childOfChild in FindVisualChildren(child))
                    {
                        if (childOfChild is IMyDataControl)
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }
    }
}
