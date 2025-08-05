using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public TurnBattleSystem TBS;
    public GameObject StartScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 battlePosition = transform.position; 
            cameraFollow.EnterBattle(battlePosition);
            StartCoroutine(ShowBattleScene());
        }
    }

    public void EndBattle()
    {
        cameraFollow.ExitBattle();
    }
    IEnumerator ShowBattleScene()
    {
        yield return new WaitForSeconds(2f);
        StartScreen.SetActive(true);
    }
}
