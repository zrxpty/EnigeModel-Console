using EnigeModel_Console.Eniges;
using EnigeModel_Console.Interface;
using EnigeModel_Console.Interface.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigeModel_Console
{
    public class Stand: IModel
    {
       
        public double AbsoluteError { get; set; } = 10e-1;
        public int MaxTime { get; set; } = 10000;

        private List<TypeTest> _typesOfTests = new List<TypeTest>() { TypeTest.defaultTest };
       

        public Stand(List<TypeTest> typesOfTests)
        {
            _typesOfTests = typesOfTests;
        }
        public void RunTest(IEngine engine, params double[] vs)
        {
            engine.Attach(this);
            engine.Simulation(vs[0]);
        }

        
        private void CriticalTemp(IEngine engine)
        {
            switch (engine.Type)
            {
                case TypeEnige.ICEngine:
                    CriticalTemp(engine as InternalCombustionEngine);
                    break;
               
                default:
                    throw new ArgumentException("This type engine not support");
            }
        }
        private void CriticalTemp(InternalCombustionEngine engine)
        {
            double eps = engine.T - engine.TEngine;
            engine.Run = eps > AbsoluteError && engine.timeRun < MaxTime;
            if (!engine.Run)
            {
                Console.WriteLine("Test Critical temp results:\n" +
                    ((engine.timeRun < MaxTime) ?
                    "The engine did not pass the test, time = " + engine.timeRun + " sec"
                    : "The engine passed the test"));
            }
        }
        public void Update(IEngine engine)
        {
            foreach (var test in _typesOfTests)
            {
                switch (test)
                {
                    case TypeTest.defaultTest:
                        CriticalTemp(engine);
                        break;
                    default:
                        throw new Exception("Stand do not have tests");
                }
            }
        }
    }
}
