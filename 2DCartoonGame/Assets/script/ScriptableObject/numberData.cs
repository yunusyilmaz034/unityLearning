using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card Number", menuName ="Card Number", order = 51)]
public class NumberData : ScriptableObject
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string cardName;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private AudioClip trueSound;
    [SerializeField]
    private AudioClip falseSound;

    public int Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }
    public string CardName
    {
        get
        {
            return this.cardName;
        }
        set
        {
            this.cardName = value;
        }
    }
    public Sprite Icon
    {
        get
        {
            return icon;
        }
        set
        {
            icon = value;
        }
    }
    public AudioClip TrueSound
    {
        get
        {
            return trueSound;
        }
        set
        {
            trueSound = value;
        }
    }
    public AudioClip FalseSound
    {
        get
        {
            return falseSound;
        }
        set
        {
            falseSound = value;
        }
    }
}
