/*using System;
using System.IO;
using System.Text;
using UnityEngine;

public class Data : MonoBehaviour 
{
    void CreateText()
    {
        //Path of the file 
        string timeStamp = Time.time.ToString().Replace(".", "").Replace(":", "");
        string filename = string.Format("Data.txt");
        string path = System.IO.Path.Combine(Application.persistentDataPath, filename);

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Start Recording Data \n\n");
        }
        string content = "Login date: " + timeStamp + "\n";

        File.AppendAllText(path, content);

    }
    void Start()
    {
        CreateText();
    }

}*/