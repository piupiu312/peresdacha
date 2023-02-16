using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.IO;

namespace N8
{
    internal class Tabl
    {
        public void save(Info users)
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText("score.json", json);
            Console.ReadKey();
        }
    }
}
