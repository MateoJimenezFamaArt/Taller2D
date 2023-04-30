using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    [SerializeField] AudioClip background;

    private void Start()
    {
        MusicSource.clip = background;
        MusicSource.Play();
    }

}

