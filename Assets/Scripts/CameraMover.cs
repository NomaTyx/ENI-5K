using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CameraMover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var cam = other.GetComponent<Camera>();
    }
}
