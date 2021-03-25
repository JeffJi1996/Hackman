using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesExamples : MonoBehaviour
{
    //Delegates are converted to classes by the compiler
    //And since they're classes... we can create NEW objects
    private delegate void MeDelegate();
    private delegate int Dele1();
    private delegate void Dele2(int num);


    public void OnEnable()
    {
        //We're not invoking Foo here, we're just passing it...
        //MeDelegate meDelegate = Foo;
        MeDelegate meDelegate = new MeDelegate(Foo);
        Dele1 dele1 = new Dele1(FooReturnInt);
        //This is a reference to a class, but it's also treated like a METHOD
        meDelegate.Invoke();

        MeDelegate meDelegate2 = Goo;
        Dele2 dele2 = FooTakeInt;
        //If we write this, the compiler will replace this with an INVOKE call
        //This is shorthand/syntactic sugar
        meDelegate2();
        dele1();
        dele2(1);

        //When this is compiled, we'll get a new MeDelegate, and it's invoke method will be called
        //With delegates, we are able to treat methods like first class objects,表示可以把方法当成一个类来使用，所以可以将参数设为一个方法

        InvokeTheDelegate(Foo);

        //Delegates are references to objects AND methods
        Debug.Log($"Target:{meDelegate.Target},Method:{meDelegate.Method}");
        //因为Goo是static方法，所以它没有target，而Foo是静态方法，所以它
        Debug.Log($"Target:{meDelegate2.Target},Method:{meDelegate2.Method}");

    }

    private void Foo()
    {
        Debug.Log("Foo!");
    }

    private static void Goo()
    {
        Debug.Log("Goo!");
    }

    private static void InvokeTheDelegate(MeDelegate del)
    {
        del();
    }

    private void FooTakeInt(int number)
    {
        Debug.Log("Foo take int!");
    }

    private int FooReturnInt()
    {
        Debug.Log("Foo return int!");
        return 0;
    }
}
