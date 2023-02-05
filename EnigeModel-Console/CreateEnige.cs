using EnigeModel_Console.Eniges;
using EnigeModel_Console.Interface;
using EnigeModel_Console.Interface.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigeModel_Console
{
    public class CreateEnige : ICreate
    {
        public IEngine GetEngine(string _pathJson, TypeEnige _type)
        {
            IEngine engine;
            switch (_type)
            {
                case TypeEnige.ICEngine:
                    engine = JsonConvert.DeserializeObject<InternalCombustionEngine>(File.ReadAllText(_pathJson));
                    break;

                default:
                    throw new ArgumentException($"Not {_type.ToString()}");

            }

            engine.Type = _type;
            return engine;
        }
    }
}
