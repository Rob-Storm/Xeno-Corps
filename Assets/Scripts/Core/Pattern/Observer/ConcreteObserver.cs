using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteObserver : IObserver
{
    public void OnNotify(object parameter)
    {
        Debug.Log($"ConcreteObserver: Notified with parameter: {parameter}");
    }
}
