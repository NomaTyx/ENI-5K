using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound()
    {
        Debug.Log("hello");
        _audioSource.Play();
    }
}
