using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripple_P.Services
{
    internal class Interfaces
    {
        public interface IMyDataControl
        {
            void LoadData();
            object GetData();
        }
    }
}
