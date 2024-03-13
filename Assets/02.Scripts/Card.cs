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

    public effectType[] effectTypes;

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
            for(int i = 0; i < effectTypes.Length; i++)
            {
                switch(effectTypes[i])
                {
                    case effectType.getBrave:
                    player.GetBrave(figure[i]);
                    break;
                    case effectType.applyBrave:
                    break;
                    case effectType.getBraveByCard:
                    break;
                    case effectType.getDivinePower:
                    player.GetDivinePower(figure[i]);
                    break;
                    case effectType.applyDivinePower:
                    break;
                    case effectType.getFlame:
                    player.GetFlame(figure[i]);
                    break;
                    case effectType.applyFlame:
                    break;
                    case effectType.getThorn:
                    player.GetThorn(figure[i]);
                    break;
                    case effectType.applyThorn:
                    break;
                    case effectType.getDefence:
                    player.GetThorn(figure[i]);
                    break;
                    case effectType.applyDefence:
                    break;
                    case effectType.takeShieldBreak:
                    player.TakeShieldBreak();
                    break;
                    case effectType.applyShieldBreak:
                    break;
                    case effectType.takeWeaponBreak:
                    player.TakeWeaponBreak();
                    break;
                    case effectType.applyWeaponBreak:
                    break;
                    case effectType.getEcho:
                    player.GetEcho();
                    break;
                    case effectType.applyEcho:
                    break;
                }
            }
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