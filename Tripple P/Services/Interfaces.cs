using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tripple_P.Services
{
    public interface IMyDataControl
    {
        void LoadData(object data);
        object GetData();
    }
}
