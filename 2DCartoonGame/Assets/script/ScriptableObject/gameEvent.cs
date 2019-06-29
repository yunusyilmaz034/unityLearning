using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)]
public class gameEvent : ScriptableObject
{
    private List<gameEventListener> listeners = new List<gameEventListener>();
   

    public void Raise()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(gameEventListener g)
    {
        listeners.Add(g);
    }
    public void UnRegisterListener(gameEventListener g)
    {
        listeners.Remove(g);
    }
}
