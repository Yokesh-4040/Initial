using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameEvents : ScriptableObject
{
    private List<GameEventListner> Listners = new List<GameEventListner>();


    public void Raise()
    {
        for (int i = Listners.Count - 1; i >= 0; i--)
            Listners[i].OnEventRaised();
    }

    public void RegisterListener(GameEventListner listner)
    {
        listner.Response.AddListener(Raise);
    }

    public void UnRegisterListener(GameEventListner listner)
    {
        listner.Response.RemoveListener(Raise);
    }

}
