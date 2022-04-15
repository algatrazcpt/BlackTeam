using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;
    public string levelId = "Level";
    public string menuId = "MainMenu";
    public string settingsId = "SettingsMenu";
    private float volumeValue=0.5f;
    public float VolumeValue { get => volumeValue; set => volumeValue = value; }
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
