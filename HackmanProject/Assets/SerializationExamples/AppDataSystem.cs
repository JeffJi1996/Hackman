using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class AppDataSystem 
{
    //Plugins Folder:每次改了项目里的代码，Unity都要reload all the assemblies, But Unity will not check the files in this folder, which can make Unity Compile faster.

    //private static AppDataSystem AppDataSystemInstance;
    //public static AppDataSystem instance => AppDataSystemInstance ?? (AppDataSystemInstance = new AppDataSystem());

    //Save method, for saving an object to a file - of any type -- with a name provided by the person saving
    public static T Save<T>(T appData, string fileName)
    {
        //Get path and folder based on the type, automatically
        var filePath = $"{Application.dataPath}/AppData/{typeof(T)}s/";

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        if (!File.Exists($"{filePath}{fileName}"))
        {
            var fileStream = File.Create($"{filePath}{fileName}.json");
            fileStream.Close();
        }

        var serializedObject = JsonConvert.SerializeObject(appData);
        File.WriteAllText($"{filePath}{fileName}.json",serializedObject);

        return appData;
    }

    //Load method, for loading objects and returning objects of any type, given a filename
    public static T Load<T>(string fileName) where T: new()
    {
        var filePath = $"{Application.dataPath}/AppData/{typeof(T)}s/";

        if (File.Exists($"{filePath}{fileName}.json"))
        {
            var appData = JsonConvert.DeserializeObject<T>(File.ReadAllText($"{filePath}{fileName}.json"));
            return appData;
        }
        return Save(new T(), fileName);

        //if (!File.Exists(filePath))
        //{
        //    if (!Directory.Exists($"{Application.dataPath}/StreamingAssets/Data/{typeof(T)}s"))
        //    {
        //        Debug.LogError("You have given a wrong type: "+ typeof(T));
        //    }
        //    else
        //    {
        //        Debug.LogError(fileName+" file doesn't exist.");
        //    }
        //    return default(T);
        //}
        //var fileData = File.ReadAllText(filePath);
        //T NewObject = JsonConvert.DeserializeObject<T>(fileData);
        //return NewObject;
    }

    //The system should check if directories/files you're saving/loading to already exist, and if not create them
    //The system should be robust enough to not explode, if a wrong file name or type is given to it

    //This should give me an Enemy object
    //var enemy = AppDataSystem.Load<Enemy>("Enemy1");
    //AppDataSystem.Save(enemy,"Enemy1");
}
