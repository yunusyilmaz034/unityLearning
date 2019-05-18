using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class number : MonoBehaviour, IBeginDragHandler
{
    [SerializeField]
    private NumberData numData;

    public AudioClip TrueSound
    {
        get
        {
            return numData.TrueSound;
        }
    }
    public AudioClip FalseSound
    {
        get
        {
            return numData.FalseSound;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(numData.Id);
        Debug.Log(numData.CardName);
        Debug.Log(numData.Icon.name);
        Debug.Log(numData.TrueSound.name);
        Debug.Log(numData.FalseSound.name);
        //throw new System.NotImplementedException();
    }
    public void FillData(int number, Sprite sp, AudioClip trueSound, AudioClip falseSound)
    {
        numData.Id = number;
        numData.CardName = number.ToString();
        numData.Icon = sp;
        numData.TrueSound = trueSound;
        numData.FalseSound = falseSound;
    }
    public void RegisterData(NumberData data)
    {
        numData = data;
    }
}
