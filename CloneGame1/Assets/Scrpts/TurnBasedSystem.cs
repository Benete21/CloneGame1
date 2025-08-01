using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedSystem : MonoBehaviour
{

    public int Player_Health_Max;
    public int Player_Health_Curr;
    public int Enemy_Health_Max;
    public int Enemy_Health_Curr;

    public int [] attack = new int [4];
    public int Default;
    public int Brave;
    public int Gold;
    public int Player_Speed;
    public int Enemy_Speed;

    public bool PlayerTurn;
    public bool EnemyTurn;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
