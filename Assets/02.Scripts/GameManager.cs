using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public List<Card> hands = new List<Card>();
    public List<Card> exhaust = new List<Card>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    
    public TMP_Text deckSizeText;
    public TMP_Text discardPileText;

    public int[] enemyHealth;
    public int[] enemyBrave;
    public bool[] enemyIsShieldBreak;
    public int[] enemyDivinePower;
    public int[] enemyFlame;
    public int[] enemyThorn;
    public bool[] enemyIsWeaponBreak;
    public bool[] enemyIsEcho;
    
    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            Card randomCard =  deck[Random.Range(0,deck.Count)];
            randomCard.DrawThisCard();
            deck.Remove(randomCard);
        }
    }

    public void Shuffle()
    {
        if(discardPile.Count >= 1)
        {
            foreach(Card card in discardPile)
            {
                deck.Add(card);
            }
                discardPile.Clear();
        }
    }

    private void Update()
    {
        deckSizeText.text = deck.Count.ToString();
        discardPileText.text = discardPile.Count.ToString();
    }


}