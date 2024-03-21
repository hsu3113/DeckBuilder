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
    public string cardInform;

    public EffectType[] effectTypes;

    public List<Tag> tags = new List<Tag>();

    public int[] figure;

    public GameManager gm;
    public Player player;

    public TMP_Text textName, textInform;
    private string _cardInform;
    private bool exhausted = false;

 /*   private void OnMouseDown()
    {
        if(!hasBeenPlayed)
        {
            transform.position += Vector3.up * 2;
            hasBeenPlayed = true;
            for(int i = 0; i < effectTypes.Length; i++)
            {
                switch(effectTypes[i])
                {
                    case EffectType.GetBrave:
                    player.GetBrave(figure[i]);
                    break;
                    case EffectType.ApplyBrave:
                    break;
                    case EffectType.GetBraveByCard:
                    break;
                    case EffectType.GetDivinePower:
                    player.GetDivinePower(figure[i]);
                    break;
                    case EffectType.ApplyDivinePower:
                    break;
                    case EffectType.GetFlame:
                    player.GetFlame(figure[i]);
                    break;
                    case EffectType.ApplyFlame:
                    break;
                    case EffectType.GetThorn:
                    player.GetThorn(figure[i]);
                    break;
                    case EffectType.ApplyThorn:
                    break;
                    case EffectType.GetDefence:
                    player.GetThorn(figure[i]);
                    break;
                    case EffectType.ApplyDefence:
                    break;
                    case EffectType.TakeShieldBreak:
                    player.TakeShieldBreak();
                    break;
                    case EffectType.ApplyShieldBreak:
                    break;
                    case EffectType.TakeWeaponBreak:
                    player.TakeWeaponBreak();
                    break;
                    case EffectType.ApplyWeaponBreak:
                    player.ApplyWeaponBreak();
                    break;
                    case EffectType.GetEcho:
                    player.GetEcho();
                    break;
                    case EffectType.ApplyEcho:
                    break;
                    case EffectType.LoseAllDefence:
                    player.LoseAllDefence();
                    break;
                    case EffectType.BringAllBraveCard:
                    player.BringTagCardInDeck(Tag.brave, 0);
                    player.BringTagCardInDiscard(Tag.brave, 0);
                    break;
                    case EffectType.BringAllBraveCardInDiscard:
                    player.BringTagCardInDiscard(Tag.brave, 0);
                    break;
                    case EffectType.Exhaust:
                    MoveToExhaust();
                    exhausted = true;
                    break;
                    case EffectType.LoseAllBrave:
                    player.LoseAllDefence();
                    break;
                    case EffectType.DiscardInHands:
                    player.DiscardInHands(figure[i]);
                    break;
                    case EffectType.BringShieldCard:
                    player.BringTagCardInDeck(Tag.brave, figure[i]);
                    player.BringTagCardInDiscard(Tag.brave, figure[i]);
                    break;
                }
            }
            player.LoadEffects();
            gm.availableCardSlots[handIndex] = true;
            gm.hands.Remove(this);
            if(!exhausted) Invoke("MoveToDiscardPile", 2f);
        }
    }*/
    /*public void MoveToDiscardPile()
    {
        gm.discardPile.Add(this);
        gameObject.SetActive(false);
    }
    public void MoveToExhaust()
    {
        gm.exhaust.Add(this);
        gameObject.SetActive(false);
    }
    */
    public void DrawThisCard()
    {
        for (int i = 0; i < gm.availableCardSlots.Length; i++)
        {
            if(gm.availableCardSlots[i])
            { 
                gameObject.SetActive(true);
                handIndex = i;
                transform.position = gm.cardSlots[i].position;
                hasBeenPlayed = false;
                gm.availableCardSlots[i] = false;
                gm.hands[i] = this;  
                return;              
            }
        }
        Debug.Log("손이 가득찼다.");
    }
/*
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
    }*/
}