using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameController;

public class GameStateEventManager : MonoBehaviour
{
    private Dictionary<GameState, List<IEventListener>> eventListenersDict = new Dictionary<GameState, List<IEventListener>>();

    public void Subscribe(GameState eventType, IEventListener listener)
    {
        SafetyCheck(eventType);
        Debug.Log("Subscribe a listener for type " + eventType);
        eventListenersDict[eventType].Add(listener);
        Debug.Log("After subscribing, list length is " + eventListenersDict[eventType].Count);
    }

    public void Unsubscribe(GameState eventType, IEventListener listener)
    {
        SafetyCheck(eventType);
        eventListenersDict[eventType].Remove(listener);
    }

    public void Notify(GameState eventType)
    {
        Debug.Log("Notify is called for event " + eventType);
        SafetyCheck(eventType);
        Debug.Log("Listreners of such type: " + eventListenersDict[eventType].Count);
        foreach (IEventListener listener in eventListenersDict[eventType].ToArray())
        {
            Debug.Log("Notify a listener of type " + eventType);
            listener.Notify(eventType);
        }
    }

    private void SafetyCheck(GameState eventType)
    {
        if (!eventListenersDict.ContainsKey(eventType))
        {
            Debug.Log("No set for type was present. Creating a new one... " + eventType);
            eventListenersDict[eventType] = new List<IEventListener>();
        }
    }
}
