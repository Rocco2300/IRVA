using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseballbat : MonoBehaviour
{

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, other.contacts[0].point, 1f);
    }

}
