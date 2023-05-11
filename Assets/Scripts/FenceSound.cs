using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSound : MonoBehaviour
{
    public AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            audio.Play();
        }
    }
}
