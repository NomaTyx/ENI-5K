using CharacterMovement;
using System;
using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CameraMover : MonoBehaviour
{
    private CinemachineCamera _staticCam;
    private void OnTriggerEnter(Collider other)
    {
        var cam = other.gameObject.GetComponent<PlayerController>().PlayerCamera;
        _staticCam = GetComponentInChildren<CinemachineCamera>();
        SwitchToStaticCam(cam);
    }

    private void OnTriggerExit(Collider other)
    {
        var cam = other.gameObject.GetComponent<PlayerController>().PlayerCamera;
        SwitchToPlayerCam(cam);
    }

    private void SwitchToStaticCam(CinemachineCamera playerCam)
    {
        playerCam.Priority = 0;
        _staticCam.Priority = 1;
    }

    private void SwitchToPlayerCam(CinemachineCamera playerCam)
    {
        playerCam.Priority = 1;
        _staticCam.Priority = 0;
    }
}
