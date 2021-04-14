using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class AppDataSystem 
{
    private static AppDataSystem AppDataSystemInstance;
    public static AppDataSystem instance => AppDataSystemInstance ?? (AppDataSystemInstance = new AppDataSystem());

    //Save method, for saving an object to a file - of any type -- with a name provided by the person saving
    public void Save<T>(T objectName, string fileName)
    {
        var objName1 = objectName.ToString();
        var serializedObject = JsonConvert.SerializeObject(objectName);
        File.WriteAllText($"{Application.dataPath}/StreamingAssets/Data/{typeof(T)}s/{fileName}.json",serializedObject);
    }
    //Load method, for loading objects and returning objects of any type, given a filename
    public T Load<T>(string fileName)
    {
        var fileData = File.ReadAllText($"{Application.dataPath}/StreamingAssets/Data/{typeof(T)}s/{fileName}.json");
        T NewObject = JsonConvert.DeserializeObject<T>(fileData);
        return NewObject;
    }

    //The system should check if directories/files you're saving/loading to already exist, and if not create them
    //The system should be robust enough to not explode, if a wrong file name or type is given to it

    //This should give me an Enemy object
    //var enemy = AppDataSystem.Load<Enemy>("Enemy1");
    //AppDataSystem.Save(enemy,"Enemy1");
}
