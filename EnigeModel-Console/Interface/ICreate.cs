using EnigeModel_Console.Interface.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigeModel_Console.Interface
{
    public interface ICreate
    {
        public abstract IEngine GetEngine(string _pathJson, TypeEnige _type);
    }
}
