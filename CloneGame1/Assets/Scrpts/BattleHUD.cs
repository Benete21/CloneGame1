using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

    public Text nameTextPlayer;
    public Slider hpSliderPlayer;
    public Text nameTextEnemy;
    public Slider hpSliderEnemy;

    public void SetHUD(Unit_Info unit)
    {
        nameTextPlayer.text = unit.Plyer_Name;
        hpSliderPlayer.maxValue = unit.Player_Health_Max;
        hpSliderPlayer.value = unit.Player_Health_Curr;
        nameTextEnemy.text = unit.Enemy_Name;
        hpSliderEnemy.maxValue = unit.Enemy_Health_Max;
        hpSliderEnemy.value = unit.Enemy_Health_Curr;
    }

    public void SetHP(int hp)
    {
        hpSliderPlayer.value = hp;
    }

}
