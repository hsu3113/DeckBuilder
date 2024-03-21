using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    GetBrave,
    ApplyBrave, 
    GetBraveByCard,
    GetDivinePower, 
    ApplyDivinePower,
    GetFlame, 
    ApplyFlame, 
    GetThorn, 
    ApplyThorn, 
    GetDefence,
    ApplyDefence,

    TakeShieldBreak, 
    ApplyShieldBreak, 
    TakeWeaponBreak, 
    ApplyWeaponBreak, 
    GetEcho,
    ApplyEcho,
    LoseAllDefence,
    BringAllBraveCard,
    BringAllBraveCardInDiscard,
    Exhaust,
    LoseAllBrave,
    DiscardInHands,
    BringShieldCard
}
public enum Tag
{
    brave,
    shield
}
