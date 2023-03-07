using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Notes
{
    internal class Serializer
    {
        public static void Serialize(List<Note> notes)
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText("C:\\mpt\\2 курс 2 семест\\C#\\Notes2\\Notes2.0\\notes.json", json);
        }
        public static List<Note> Deserialize()
        {
            string json = File.ReadAllText("C:\\mpt\\2 курс 2 семест\\C#\\Notes2\\Notes2.0\\notes.json");
            List<Note> notes = JsonConvert.DeserializeObject<List<Note>>(json);
            return notes;
        }
    }
}
