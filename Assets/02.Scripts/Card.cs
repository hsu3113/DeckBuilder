using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum CardType
{
    attack,
    assistant
}
[System.Serializable]
public class Card
{
    public string name;
    
    public CardType cardType;
    public string inform;
}
[CreateAssetMenu(fileName ="CardSO",menuName = "Scriptable Object/CardSO")]
public class CardSO : ScriptableObject
{
    public Card[] cards;
}
