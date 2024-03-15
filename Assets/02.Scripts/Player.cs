using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int brave;
    private bool isShieldBreak;
    private int divinePower;
    private int flame;
    private int thorn;
    private bool isWeaponBreak;
    private bool isEcho;
    
    private int usedbrave;


    public int defence;
    public int health;
    public Transform[] effects;
    public Transform[] effectSlots;
    public bool[] availableEffectSlots;
    
    private GameManager gm;


    public void GetBrave(int getBrave)
    {
        brave += getBrave;
        usedbrave++;
        LoadEffects();
    }
    public void TakeShieldBreak()
    {
        isShieldBreak = true;
        LoadEffects();
    }

    public void GetDivinePower(int getDivinePower)
    {
        divinePower += getDivinePower;
        LoadEffects();
    }
    public void GetFlame(int getFlame)
    {
        flame += getFlame;
        LoadEffects();
    }
    public void GetThorn(int getThorn)
    {
        thorn += getThorn;
        LoadEffects();
    }
    public void TakeWeaponBreak()
    {
        isWeaponBreak = true;
        LoadEffects();
    }
    public void GetEcho()
    {
        isEcho = true;
        LoadEffects();
    }
    public void LoseAllDefence()
    {
        defence = 0;
        LoadEffects();
    }
    public void GetBraveByCard(int getBraveByCard)
    {
        for (int i = 0; i < usedbrave; i++)
        {
            brave += getBraveByCard;
        }
        LoadEffects();
    }
    public void BringAllBraveCardInDiscard()
    {
        
        for(int i = 0; i < gm.discardPile.Count; i++)
        {  
            if(gm.discardPile[i].tags.Contains(Tag.brave))
            {
                for (int j = 0; j < gm.availableCardSlots.Length; j++)
                {
                    if(gm.availableCardSlots[i] == true)
                    {
                        gm.discardPile[i].gameObject.SetActive(true);
                        gm.discardPile[i].handIndex = j;
                        gm.discardPile[i].transform.position = gm.cardSlots[j].position;
                        gm.discardPile[i].hasBeenPlayed = false;
                        gm.availableCardSlots[i] = false;
                        gm.discardPile.Remove(gm.deck[i]);
                        return;
                    }
                    else Debug.Log("손이 가득찼다.");
                }
            }
        }
        LoadEffects();
    }
    public void BringAllBraveCardInDeck()
    {
        for(int i = 0; i < gm.deck.Count; i++)
        {  
            if(gm.deck[i].tags.Contains(Tag.brave))
            {
                for (int j = 0; j < gm.availableCardSlots.Length; j++)
                {
                    if(gm.availableCardSlots[i] == true)
                    {
                        gm.deck[i].gameObject.SetActive(true);
                        gm.deck[i].handIndex = j;
                        gm.deck[i].transform.position = gm.cardSlots[j].position;
                        gm.deck[i].hasBeenPlayed = false;
                        gm.availableCardSlots[i] = false;
                        gm.deck.Remove(gm.deck[i]);
                        return;
                    }
                    else Debug.Log("손이 가득찼다.");
                }
            }
        }
        LoadEffects();
    }
    public void GetDefence(int getDefence){
        defence += getDefence;
    }
    public void TurnEnd()
    {
        defence = 0;
        if(brave == 1) brave--;
        if(brave != 0) brave -= brave/2;
        divinePower = 0;
        flame = 0;
        thorn = 0;
        isEcho = false;
        isShieldBreak = false;
        isWeaponBreak = false;
        LoadEffects();
    }
    
    
    
    public void LoadEffects()
    {
        if(brave != 0)
        {
            effects[0].gameObject.SetActive(true);
            effects[0].GetComponentInChildren<TMP_Text>().text = brave.ToString();
            MoveEffect(0);
        }
        else effects[0].gameObject.SetActive(false);

        if (isShieldBreak)
        {   
            effects[1].gameObject.SetActive(true);
            MoveEffect(1);
        }
        else effects[1].gameObject.SetActive(false);

        if(divinePower != 0)
        {
            effects[2].gameObject.SetActive(true);
            effects[2].GetComponentInChildren<TMP_Text>().text = divinePower.ToString();
            MoveEffect(2);
        }
        else effects[2].gameObject.SetActive(false);

         if(flame != 0)
        {
            effects[3].gameObject.SetActive(true);
            effects[3].GetComponentInChildren<TMP_Text>().text = brave.ToString();
            MoveEffect(3);
        }
        else effects[3].gameObject.SetActive(false);

         if(thorn != 0)
        {
            effects[4].gameObject.SetActive(true);
            effects[4].GetComponentInChildren<TMP_Text>().text = brave.ToString();
            MoveEffect(4);
        }
        else effects[4].gameObject.SetActive(false);

        if (isWeaponBreak)
        {   
            effects[5].gameObject.SetActive(true);
            MoveEffect(5);
        }
        else effects[5].gameObject.SetActive(false);

        if (isEcho)
        {   
            effects[6].gameObject.SetActive(true);
            MoveEffect(6);
        }
        else effects[6].gameObject.SetActive(false);
    }
    void MoveEffect(int num)
    {
        for (int i = 0; i < availableEffectSlots.Length; i++)
        {
            if(availableEffectSlots[i])
            {
                effects[num].transform.position = effectSlots[i].transform.position;
                
                availableEffectSlots[i] = false;
                break;
            }
        }
    }
    void SetR()
    {
        for(int i = 0; i < availableEffectSlots.Length; i++)
        {
            availableEffectSlots[i] = true;
        }
        brave = 0;
        isShieldBreak = false;
        divinePower = 0;
        flame = 0;
        thorn = 0;
        isWeaponBreak = false;
        isEcho = false;
    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        SetR();
    }
}
