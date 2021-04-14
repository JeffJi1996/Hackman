using System;
using System.IO;
using System.Net.Mime;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;

public class SerializationExamples : MonoBehaviour
{
    //public TextAsset EnemyFile;
    
    public Enemy enemy;
    public Text EnemyText;
    public void OnEnable()
    {
        //The Format:
        //{
           //"Name":"Nat",
           //"ID":"c491949a-f17c-48e3-88ab-e456aa5d0ebf",
           //"HP":9000
        //}


        //enemy = new Enemy() {Name = "Nat", ID = Guid.NewGuid(), HP = 9000};
        var enemyData =
            File.ReadAllText($"{Application.dataPath}/StreamingAssets/Data/{typeof(Enemy)}s/EnemyFile.json");
        enemy = JsonConvert.DeserializeObject<Enemy>(enemyData);
        EnemyText.text = $"{enemy.Name}:{enemy.HP}HP";
        //UnityJson is too simple to deal with complex data(Like it can't save Vector2)
        // enemy = JsonConvert.DeserializeObject<Enemy>(EnemyFile.text);
    }

    public void OnDisable()
    {
         var serializedEnemy = JsonConvert.SerializeObject(enemy);
        File.WriteAllText($"{Application.dataPath}/StreamingAssets/Data/{typeof(Enemy)}s/EnemyFile.json",serializedEnemy);
        Debug.Log(serializedEnemy);
    }

}

public class Good
{

}
