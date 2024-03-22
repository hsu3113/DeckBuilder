using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();


    public List<Card> deckNotUse = new List<Card>();
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
            int num = Random.Range(0,deck.Count);
            Card randomCard = deck[num];
            randomCard.DrawThisCard(CardPlace.Deck);
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
    public void SizeCount()
    {
        deckSizeText.text = deck.Count.ToString();    
        discardPileText.text = discardPile.Count.ToString();
    }
    
    private void Awake()
    {
        hands = new List<Card>(new Card[availableCardSlots.Length]);
    }
    private void Update()
    {
        SizeCount();
    }

}