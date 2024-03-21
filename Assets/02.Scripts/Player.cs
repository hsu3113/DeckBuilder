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
    
    private int usedBrave;
    public int haveBrave;
    public int haveShield;

    private int target;
    public int defence;
    public int health;
    public Transform[] effects;
    public Transform[] effectSlots;
    public bool[] availableEffectSlots;
    public bool[] isMove;
    private GameManager gm;


    public void GetBrave(int getBrave)
    {
        brave += getBrave;
        usedBrave++;
    }
    public void TakeShieldBreak()
    {
        isShieldBreak = true;
    }

    public void GetDivinePower(int getDivinePower)
    {
        divinePower += getDivinePower;
    }
    public void GetFlame(int getFlame)
    {
        flame += getFlame;
    }
    public void GetThorn(int getThorn)
    {
        thorn += getThorn;
    }
    public void TakeWeaponBreak()
    {
        isWeaponBreak = true;
    }

    public void ApplyWeaponBreak()
    {
        gm.enemyIsWeaponBreak[target] = true;
    }
    public void GetEcho()
    {
        isEcho = true;
    }
    public void LoseAllDefence()
    {
        defence = 0;
    }
    public void GetBraveByCard(int getBraveByCard)
    {
        for (int i = 0; i < usedBrave; i++)
        {
            brave += getBraveByCard;
        }
    }
    public void BringTagCardInDeck(Tag tag, int amount)
    {
        int count = 0;
        if(amount == 0)
        {
            for(int i = 0; i < gm.deck.Count; i++)
            {  
                if(gm.deck[i].tags.Contains(tag))
                {
                    gm.deck[i].DrawThisCard();
                    gm.deck.Remove(gm.deck[i]);
                }
            }
        }
        else
        {
            while(count < amount)
            {
                int i = 0;
                if(gm.deck[i].tags.Contains(tag))
                {
                    gm.deck[i].DrawThisCard();
                    gm.deck.Remove(gm.deck[i]);
                    count++;
                }
                i++;
            }
        }
        
    }
    public void BringTagCardInDiscard(Tag tag, int amount)
    {
        int count = 0;
        if(amount == 0)
        {
           for(int i = 0; i < gm.discardPile.Count; i++)
            {  
                if(gm.discardPile[i].tags.Contains(tag))
                {
                    gm.discardPile[i].DrawThisCard();
                    gm.discardPile.Remove(gm.deck[i]);
                }
            } 
        }
        else
        {
            while(count < amount)
            {
                int i = 0;
                if(gm.discardPile[i].tags.Contains(tag))
                {
                    count++;
                    gm.discardPile[i].DrawThisCard();
                    gm.discardPile.Remove(gm.deck[i]);
                }
                i++;
            }
        }
    }
   
    public void GetDefence(int getDefence)
    {
        defence += getDefence;
    }
    
    public void LoseAllBrave()
    {
        brave = 0;
    }

    public void DiscardInHands(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            int r = Random.Range(0,gm.cardSlots.Length);
            Card randomCard = gm.hands[Random.Range(0,gm.hands.Count)];
            randomCard.hasBeenPlayed = true;
            gm.availableCardSlots[randomCard.handIndex] = true;
            gm.hands.Remove(randomCard);
            randomCard.MoveToDiscardPile();
        }
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
            if(availableEffectSlots[i] && !isMove[num])
            {
                effects[num].transform.position = effectSlots[i].transform.position;
                isMove[num] = true;
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
        haveBrave = 0;
        haveShield = 0;
        for(int i = 0; i < gm.deck.Count; i++)
        {
            for(int j = 0; j < gm.deck[i].tags.Count; j++)
            {
                if(gm.deck[i].tags[j] == Tag.brave)
                {
                    haveBrave++;
                }
            }
        }
    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        SetR();
    }
}
