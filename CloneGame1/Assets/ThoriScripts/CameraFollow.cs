using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public CinemachineVirtualCamera playerCam;
    public CinemachineVirtualCamera battleCam;

    public Transform battleFocusPoint;
    
    void Awake()
    {
        battleFocusPoint = new GameObject("BattleFocusPoint").transform;
    }

    public void EnterBattle(Vector3 position)
    {
        Vector3 offset = new Vector3(0, 1.5f, 0);
        battleFocusPoint.position = position + offset;

        battleCam.Follow = battleFocusPoint;
        battleCam.LookAt = battleFocusPoint;
        
        battleCam.Priority = 20;
        playerCam.Priority = 10;
        
        Debug.Log("Moving battle focus point to: " + (position + offset));
    }

    public void ExitBattle()
    {
        battleCam.Priority = 5;
        playerCam.Priority = 20;
    }
}
