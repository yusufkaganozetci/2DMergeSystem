using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    OnFreeCellWanted,
    OnBallClicked,
    OnBallReleased,
    OnBallDestroyWanted,
}

public class EventManager : MonoBehaviour
{

    public Dictionary<EventType, Action> delegatesWithZeroParamDict
        = new Dictionary<EventType, Action>();

    public Dictionary<EventType, Action<object>> delegatesWithOneParamDict
        = new Dictionary<EventType, Action<object>>();

    public Dictionary<EventType, Func<object>> delegatesWithReturnDict 
        = new Dictionary<EventType, Func<object>>();
    
    public static EventManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void OnDestroy()
    {
        delegatesWithZeroParamDict?.Clear();
        delegatesWithOneParamDict?.Clear();
        delegatesWithReturnDict?.Clear();
    }

    

    public void SubscribeToEvent(EventType eventType, Action<object> listener)
    {
        if (delegatesWithOneParamDict.ContainsKey(eventType))
        {
            delegatesWithOneParamDict[eventType] += listener;
        }
        else
        {
            delegatesWithOneParamDict[eventType] = listener;
        }
    }

    public void SubscribeToEvent(EventType eventType, Func<object> listener)
    {
        if (delegatesWithReturnDict.ContainsKey(eventType))
        {
            delegatesWithReturnDict[eventType] += listener;
        }
        else
        {
            delegatesWithReturnDict[eventType] = listener;
        }
    }

    public object TriggerTheEvent(EventType eventType)
    {
        if (delegatesWithReturnDict[eventType] == null) return null;
        return delegatesWithReturnDict[eventType]();
    }

    public void TriggerTheEvent(EventType eventType, object arg)
    {
        if (delegatesWithOneParamDict[eventType] == null) return;
        delegatesWithOneParamDict[eventType](arg);
    }

}