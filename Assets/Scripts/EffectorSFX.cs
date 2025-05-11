using System;
using UnityEngine;

public class EffectorSFX : MonoBehaviour
{
    [SerializeField] private AudioClip effectorSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.parent.CompareTag("Player"))
        {
            audioSource.PlayOneShot(effectorSound, 0.1f);
            Debug.Log("Effector sound played");
        }
    }
}
