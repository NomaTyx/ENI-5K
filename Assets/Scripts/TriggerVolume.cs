using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerVolume : MonoBehaviour
{
    [SerializeField] private string _tagFilter = "Player";

    public UnityEvent<GameObject> OnEnter;
    public UnityEvent<GameObject> OnExit;

    private void OnTriggerEnter(Collider other)
    {
        bool hasTag = !string.IsNullOrEmpty(_tagFilter);
        bool tagMatch = other.CompareTag(_tagFilter);

        // invoke if no tag, or matching tag
        if (!hasTag || (hasTag && tagMatch))
        {
            OnEnter.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bool hasTag = !string.IsNullOrEmpty(_tagFilter);
        bool tagMatch = other.CompareTag(_tagFilter);

        // invoke if no tag, or matching tag
        if (!hasTag || (hasTag && tagMatch))
        {
            OnExit.Invoke(other.gameObject);
        }
    }
}