using System;
using UnityEngine;

public class PortalSFX : MonoBehaviour
{
    [SerializeField] private AudioClip portalSound;
    private AudioSource audioSource;
    private int count = 1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.parent.CompareTag("Player") && count == 1)
        {
            count = 2;
            audioSource.PlayOneShot(portalSound, 0.1f);
            Debug.Log("Portal sound played");
        }
    }
}
