using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Test class for observer pattern
/// </summary>
public class SubjectComponent : MonoBehaviour
{
    private Subject subject = new Subject();

    private void Start()
    {
        subject.AddObserver(new ConcreteObserver());
        subject.AddObserver(new ConcreteObserver());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            subject.NotifyObservers(null);
        }
    }
}
