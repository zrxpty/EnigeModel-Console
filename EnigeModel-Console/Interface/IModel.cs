using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigeModel_Console.Interface
{
    public interface IModel
    {
        public void RunTest(IEngine Engine, params double[] ps);
        public void Update(IEngine Engine);
    }
}
