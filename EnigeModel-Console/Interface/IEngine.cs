using EnigeModel_Console.Interface.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigeModel_Console.Interface
{
    public interface IEngine
    {
        public bool Run { get; set; }
        public TypeEnige Type { get; set; }
        public void Simulation(double tAir);
       
        void Attach(IModel observer);
        void Detach();

        void Notify();
       
    }
}
