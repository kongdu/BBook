using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMAnager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> bgms;

    private void Start()
    {
        bgms = new List<AudioClip>();

        audioSource.clip = bgms[Random.Range(0, bgms.Count + 1)];
    }
}