using EnigeModel_Console.Interface;
using EnigeModel_Console.Interface.Enum;
using System;
using System.Collections.Generic;

namespace EnigeModel_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateEnige createEnige = new CreateEnige();
            IEngine engine = null;
            double _temp = 0;
            bool flag = true;

            do
            {
                try
                {
                    Console.Write("Введите температуру: ");
                    _temp = Convert.ToDouble(Console.ReadLine());
                    flag = false;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }

            } while (flag);

            try
            {
                engine = createEnige.GetEngine("../../../Data/Enige.json", TypeEnige.ICEngine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Stand stand = new Stand(new List<TypeTest>() { TypeTest.defaultTest });
            engine.Attach(stand);
            stand.RunTest(engine, _temp);
        }
    }
}
