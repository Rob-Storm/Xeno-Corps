using System.Collections.Generic;
using System;

public static class EventManager
{
    private static Dictionary<Type, List<Delegate>> eventListeners = new Dictionary<Type, List<Delegate>>();

    public static void Subscribe<T>(Action<T> listener) where T : struct
    {
        Type eventType = typeof(T);
        if (!eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType] = new List<Delegate>();
        }
        eventListeners[eventType].Add(listener);
    }

    public static void Unsubscribe<T>(Action<T> listener) where T : struct
    {
        Type eventType = typeof(T);
        if (eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType].Remove(listener);
        }
    }

    public static void Broadcast<T>(T eventArgs) where T : struct
    {
        Type eventType = typeof(T);
        if (eventListeners.ContainsKey(eventType))
        {
            foreach (Delegate listener in eventListeners[eventType])
            {
                ((Action<T>)listener)?.Invoke(eventArgs);
            }
        }
    }
}