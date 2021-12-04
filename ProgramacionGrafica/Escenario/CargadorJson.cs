using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using OpenTK;


namespace ConsoleApp5
{
    class CargadorJson
    {
        public static void Guardar(string path, Objeto3D objeto)
        {
               

            string output = JsonConvert.SerializeObject(objeto, new MatrizConversor());
            File.WriteAllText(path, output);
        }
        public static Objeto3D Cargar(string path)
        {
            string output = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Objeto3D>(output);
        }
    }

    class MatrizConversor : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            Matrix3 matriz = new Matrix3();
            return objectType == matriz.GetType();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Dictionary<string, float> matrizCargada = new Dictionary<string,float>();
            if (reader.TokenType != JsonToken.StartObject)
            {
                throw new JsonException();
            }
            
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    return new Matrix3(matrizCargada["M11"], matrizCargada["M12"], matrizCargada["M13"],
                          matrizCargada["M21"], matrizCargada["M22"], matrizCargada["M23"],
                          matrizCargada["M31"], matrizCargada["M32"], matrizCargada["M33"]);
                }
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    string propiedad = (string)reader.Value;
                    reader.Read();
                    if (reader.TokenType == JsonToken.Float)
                    {
                        matrizCargada.Add(propiedad, (float)reader.Value);
                    }
                }
               
            }
            throw new JsonException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Matrix3 matriz = (Matrix3)value;
            writer.WriteStartObject();
            writer.WritePropertyName("M11");
            writer.WriteValue(matriz.M11);
            writer.WritePropertyName("M12");
            writer.WriteValue(matriz.M12);
            writer.WritePropertyName("M13");
            writer.WriteValue(matriz.M13);
            writer.WritePropertyName("M21");
            writer.WriteValue(matriz.M21);
            writer.WritePropertyName("M22");
            writer.WriteValue(matriz.M22);
            writer.WritePropertyName("M23");
            writer.WriteValue(matriz.M23);
            writer.WritePropertyName("M31");
            writer.WriteValue(matriz.M31);
            writer.WritePropertyName("M32");
            writer.WriteValue(matriz.M32);
            writer.WritePropertyName("M33");
            writer.WriteValue(matriz.M33);
            writer.WriteEndObject();
        }
    }
}
