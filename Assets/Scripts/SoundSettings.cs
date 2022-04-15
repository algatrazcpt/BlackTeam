using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    GameSettings gameSettings;
    AudioSource audioSource;
    void Start()
    {
        gameSettings = GameSettings.Instance;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        audioSource.volume = gameSettings.VolumeValue;
    }
}
