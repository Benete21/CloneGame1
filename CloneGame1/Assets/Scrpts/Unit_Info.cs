using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Unit_Info : MonoBehaviour
{
    public string Plyer_Name;
    public string Enemy_Name;

    public int Player_Health_Max;
    public int Player_Health_Curr;
    public int Enemy_Health_Max;
    public int Enemy_Health_Curr;

    public int damage;
    public int Gold;

    public bool PlayerTakeDamage(int dmg)
    {
        Player_Health_Curr  -= dmg;

        if (Player_Health_Curr <= 0)
            return true;
        else
            return false;
    }

    public bool EnemyTakeDamage(int dmg)
    {

        Enemy_Health_Curr -= dmg;

        if (Enemy_Health_Curr <= 0)
            return true;
        else
            return false;
    }

    public void HealPlayer(int amount)
    {
        Player_Health_Curr += amount;
        if (Player_Health_Curr > Player_Health_Max)
            Player_Health_Curr = Player_Health_Max;
    }
}
