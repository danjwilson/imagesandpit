using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace BookEngine
{
    public static class BookTemplateHelper
    {
        public static void Serialize(BookTemplate bookTemplate)
        {
            FileStream stream = new FileStream(bookTemplate.OutputFolder + "BookTemplate.json", FileMode.OpenOrCreate);
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BookTemplate));
                ser.WriteObject(stream, bookTemplate);
            }
            finally
            {
                stream.Close();
            }
        }

        public static void Deserialize(string fileName)
        {
            // TO DO //
        }
    }
}
