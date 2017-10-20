using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class GameStorage {

    public static void Save<T>(T input, string filepath)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        FileStream file = new FileStream(filepath, FileMode.Create);
        xmlSerializer.Serialize(file, input);
        file.Close();
    }

    public static T Load<T>(string filepath)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        FileStream file = new FileStream(filepath, FileMode.Open);
        T output = (T) xmlSerializer.Deserialize(file);
        file.Close();
        return output;
    }

    public static bool Exists(string filename){
        return File.Exists(filename);
    }
}
