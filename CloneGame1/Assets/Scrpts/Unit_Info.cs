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

    public int damage01;
    public int damage02;
    public int damage03;
    public int damage04;
    public int damageEnemy;
    public int Gold;
    public int GoldEnemy;

    public int BP_Point;

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
    public void PlayerBrave()
    {
        if(BP_Point > 0)
        BP_Point -= 1;
    }
    public void PlayerDefault()
    {
        BP_Point += 1;
    }
}
