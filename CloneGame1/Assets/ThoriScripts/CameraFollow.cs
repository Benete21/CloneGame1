using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public CinemachineVirtualCamera playerCam;
    public CinemachineVirtualCamera battleCam;

    public void EnterBattle(Transform enemy)
    {
        battleCam.Follow = enemy;
        battleCam.LookAt = enemy;
        battleCam.Priority = 20;
        playerCam.Priority = 10;
    }

    public void ExitBattle()
    {
        battleCam.Priority = 5;
        playerCam.Priority = 20;
    }
}
