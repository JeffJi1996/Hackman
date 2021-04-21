using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public Enemy enemy1;
    //public Enemy enemy2;

    public void OnEnable()
    {
        AppDataSystem.Save(enemy1,"EnemyPPP");
       // var enemy2 = AppDataSystem.Load<Enemy>("Enemy2");

        var enemy = AppDataSystem.Load<Enemy>("EnemyPPP");
        Debug.Log(enemy.Name);
        //AppDataSystem.Save(enemy,"Enemy1");
    }
}
