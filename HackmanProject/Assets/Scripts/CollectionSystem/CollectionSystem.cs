using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The collection system is our SUBSCRIBER or LISTENER
public class CollectionSystem : MonoBehaviour
{

    private void OnEnable()
    {
        //Subscribe方法会查询一下字典里有没有【CollectionEvent】
        //没有的话，就把OnCollectionEvent这个事件赋给字典中【CollectionEvent】这个Type对应的Delegate
        // 有的话，就delegates[CollectionEvent] += OnCollectionEvent（也就是Delegate.Combine（两个delegates））
        Evently.instance.Subscribe<CollectionEvent>(OnCollectionEvent);
    }

    private void OnDisable()
    {
        Evently.instance.Unsubscribe<CollectionEvent>(OnCollectionEvent);
    }

    //这是要传的Action事件
    private void OnCollectionEvent(CollectionEvent evt)
    {
        Debug.Log("collect something!");
        Destroy(evt.Collectable.gameObject);
    }
}

public class CollectionEvent
{
    public CollectableComponent Collectable;


    public CollectionEvent(CollectableComponent _collectable)
    {
        Collectable = _collectable;
    }

}
