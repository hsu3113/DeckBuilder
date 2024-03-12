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

    public string cardName;
    [TextArea]
    public string   cardInform;

    public int[] figure;

    private GameManager gm;
    public Player player;

    public TMP_Text textName, textInform;
    private string _cardInform;

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

    public string SetInform(string inform)
    {
        string[] informs = inform.Split('!');
        string informR = "";
        for(int i = 0; i < informs.Length; i++)
        {
            if(i%2 == 0)
            {
                informR += informs[i];
            }
            else
            {
                informR += figure[i/2];
            }
        }
        return informR;
    }

    void Writing(string n, string i)
    {
        textName.text = n;
        textInform.text = i;
    }

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        textName = transform.GetChild(1).GetComponent<TMP_Text>();
        textInform = transform.GetChild(2).GetComponent<TMP_Text>();
        _cardInform = SetInform(cardInform);
        Writing(cardName,_cardInform);
    }
}