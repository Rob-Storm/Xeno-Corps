using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
            observers.Remove(observer);
        else
            Debug.LogError($"Observers list does not contain '{observer}'!");
    }
    public void NotifyObservers(object parameter)
    {
        foreach (IObserver observer in observers) 
        {
            observer.OnNotify(parameter);
        } 
    }
}
