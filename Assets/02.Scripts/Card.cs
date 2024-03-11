using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool hasBeenPlayed;

    public int handIndex;
    public string cardName,cardCost,cardInform;
    public int[] figure;

    private GameManager gm;
    public TMP_Text Name, Cost, Inform;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

    }

    private void OnMouseDown()
    {
        if(!hasBeenPlayed)
        {
            transform.position += Vector3.up * 2;
            hasBeenPlayed = true;
            gm.availableCardSlots[handIndex] = true;
            Invoke("MoveToDiscardPile", 2f);
        }
    }
    void MoveToDiscardPile()
    {
        gm.discardPile.Add(this);
        gameObject.SetActive(false);
    }
}

class Effect
{
    Card card = new Card();
    void Brave(int dmg)
    {
         card.cardInform += $"용기를 {dmg}얻는다. ";
    }
}
class Write
{
    Card card = new Card();
    void Writing(string n, string c, string i)
    {
        card.Name.text = n;
        card.Cost.text = c;
        card.Inform.text = i;
    }
}