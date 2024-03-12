using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int brave;
    private bool shildBreak;
    public Transform[] effects;
    public Transform[] effectSlots;
    public bool[] availableEffectSlots;



    public void GetBrave(int b){
        brave += b;
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

        if (shildBreak)
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
    }
}
