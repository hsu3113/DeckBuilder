using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int brave;
    private bool shieldBreak;
    private int divinePower;
    private int flame;
    private int thorn;
    private bool weaponBreak;
    private bool echo;
    public Transform[] effects;
    public Transform[] effectSlots;
    public bool[] availableEffectSlots;



    public void GetBrave(int b)
    {
        brave += b;
        LoadEffects();
    }
    public void TakeShieldBreak()
    {
        shieldBreak = true;
        LoadEffects();
    }

    public void GetDivinePower(int d)
    {
        divinePower += d;
        LoadEffects();
    }
    public void GetFlame(int f)
    {
        flame += f;
        LoadEffects();
    }
    public void GetThorn(int t)
    {
        thorn += t;
        LoadEffects();
    }
    public void TakeWeaponBreak()
    {
        weaponBreak = true;
        LoadEffects();
    }
    public void GetEcho()
    {
        echo = true;
        LoadEffects();
    }
    public void LoadEffects()
    {
        if(brave != 0)
        {
            effects[0].gameObject.SetActive(true);
            effects[0].GetComponentInChildren<TMP_Text>().text = brave.ToString();
            for (int i = 0; i < availableEffectSlots.Length; i++)
            {
                if(availableEffectSlots[i])
                {
                    transform.position = effectSlots[i].position;
                    availableEffectSlots[i] = false;
                }
            }
        }
        else effects[0].gameObject.SetActive(false);

        if (shieldBreak)
        {   
            effects[1].gameObject.SetActive(true);
            for (int i = 0; i < availableEffectSlots.Length; i++)
            {
                if(availableEffectSlots[i])
                {
                    transform.position = effectSlots[i].position;
                    availableEffectSlots[i] = false;
                }
            }
        }
        else effects[1].gameObject.SetActive(false);

        if(divinePower != 0)
        {
            effects[2].gameObject.SetActive(true);
            effects[2].GetComponentInChildren<TMP_Text>().text = brave.ToString();
            for (int i = 0; i < availableEffectSlots.Length; i++)
            {
                if(availableEffectSlots[i])
                {
                    transform.position = effectSlots[i].position;
                    availableEffectSlots[i] = false;
                }
            }
        }
        else effects[2].gameObject.SetActive(false);

         if(flame != 0)
        {
            effects[3].gameObject.SetActive(true);
            effects[3].GetComponentInChildren<TMP_Text>().text = brave.ToString();
            for (int i = 0; i < availableEffectSlots.Length; i++)
            {
                if(availableEffectSlots[i])
                {
                    transform.position = effectSlots[i].position;
                    availableEffectSlots[i] = false;
                }
            }
        }
        else effects[3].gameObject.SetActive(false);

         if(thorn != 0)
        {
            effects[4].gameObject.SetActive(true);
            effects[4].GetComponentInChildren<TMP_Text>().text = brave.ToString();
            for (int i = 0; i < availableEffectSlots.Length; i++)
            {
                if(availableEffectSlots[i])
                {
                    transform.position = effectSlots[i].position;
                    availableEffectSlots[i] = false;
                }
            }
        }
        else effects[4].gameObject.SetActive(false);

        if (weaponBreak)
        {   
            effects[5].gameObject.SetActive(true);
            for (int i = 0; i < availableEffectSlots.Length; i++)
            {
                if(availableEffectSlots[i])
                {
                    transform.position = effectSlots[i].position;
                    availableEffectSlots[i] = false;
                }
            }
        }
        else effects[5].gameObject.SetActive(false);

        if (echo)
        {   
            effects[6].gameObject.SetActive(true);
            for (int i = 0; i < availableEffectSlots.Length; i++)
            {
                if(availableEffectSlots[i])
                {
                    transform.position = effectSlots[i].position;
                    availableEffectSlots[i] = false;
                }
            }
        }
        else effects[6].gameObject.SetActive(false);
    }
}
