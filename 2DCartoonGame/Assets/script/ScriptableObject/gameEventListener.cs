using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gameEventListener : MonoBehaviour
{
    [SerializeField]
    private gameEvent GameEvent;
    [SerializeField]
    private UnityEvent Event;

    private void OnEnable()
    {
        GameEvent.RegisterListener(this);
    }
    private void OnDisable()
    {
        GameEvent.UnRegisterListener(this);
    }

    public void OnEventRaised()
    {
        Debug.Log("OnEventRaised call");
        Event.Invoke();
    }

}
