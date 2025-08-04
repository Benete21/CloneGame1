using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    public CameraFollow cameraFollow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 battlePosition = transform.position; 
            cameraFollow.EnterBattle(battlePosition);
        }
    }

    public void EndBattle()
    {
        cameraFollow.ExitBattle();
    }
}
