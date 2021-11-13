using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp5
{
    class CargadorJson
    {
        public static void Guardar(string path, Objeto3D objeto)
        {
            string output = JsonConvert.SerializeObject(objeto);
            File.WriteAllText(path, output);
        }
        public static Objeto3D Cargar(string path)
        {
            string output = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Objeto3D>(output);
        }
    }
}
