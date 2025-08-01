using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurnBasedSystem : MonoBehaviour
{

    public int Player_Health_Max;
    public int Player_Health_Curr;
    public int Enemy_Health_Max;
    public int Enemy_Health_Curr;

    public int damage;
    public int Default;
    public int Brave;
    public int Gold;
    public int Player_Speed;
    public int Enemy_Speed;
    public int BP_Points;


    public bool PlayerTurn;
    public bool EnemyTurn;

    public GameObject AttackUI;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerAttack()
    {
        AttackUI.SetActive (true);
    }
    public void SelectAttackCard()
    {
        
    }
    public void Attack_01()
    {
        damage += Random.Range(1,2);    
    }
    public void Attack_02()
    {
        damage += Random.Range(1, 2);
    }
    public void Attack_03()
    {
        damage += Random.Range(1, 2);
    }
    public void Attack_04()
    {
        damage += Random.Range(1, 2);
    }
}
