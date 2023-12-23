using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    #region Self Variables

    #region Private Variables

    private AudioSource _audioSource;

    #endregion

    #endregion

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            _audioSource.Play();
            Destroy(other.gameObject);
        }
    }
}
