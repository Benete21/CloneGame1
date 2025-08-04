using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public UI_MANAGER uI_MANAGER;
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.gameObject.name == "EnemyFight")
        {
            Debug.Log("Test");
        }*/
        
        if (other.CompareTag("Enemy"))
        {
            cameraFollow.EnterBattle(transform);
        }

        // CALL BattleMode(); when cemera movement is done  -Ntsikelelo
    }
    
// When battle ends
    void EndBattle()
    {
        cameraFollow.ExitBattle();
    }

   void BattleMode()
    {
        uI_MANAGER.BattleState();
    }
}
