using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsMenuControl : MonoBehaviour
{
    GameSettings gameSettings;
    public Slider volumeSlider;
    string menuId;
    void Start()
    {
        Init();
       
        volumeSlider.onValueChanged.AddListener(VolumeChange);
        volumeSlider.value = gameSettings.VolumeValue;
        gameSettings.VolumeValue = volumeSlider.value;
    }

    public void VolumeChange(float value)
    {
        gameSettings.VolumeValue = value;
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(menuId);
    }
    public void Init()
    {
        menuId = GameSettings.Instance.menuId;
        gameSettings = GameSettings.Instance;
    }
}
