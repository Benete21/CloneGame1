using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    public CameraFollow cameraFollow;
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
    }
    
    

// When battle ends
    void EndBattle()
    {
        cameraFollow.ExitBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
