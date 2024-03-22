using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public List<Card> deck = new List<Card>();
    public List<Card> deckNotUse = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public List<Card> hands = new List<Card>();
    public List<Card> exhaust = new List<Card>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    
    public TMP_Text deckSizeText;
    public TMP_Text discardPileText;
    public TMP_Text exhaustSizeText;

    public List<Enemy> enemies = new List<Enemy>();
    public bool[] enemyIsEcho;
    
    public void AddCardInDeck(int num)
    {
        GameObject card = Instantiate(cards[num].gameObject);
        deck.Add(card.GetComponent<Card>());
    }
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
        exhaustSizeText.text = exhaust.Count.ToString();
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