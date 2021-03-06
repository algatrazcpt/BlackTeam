using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour
{
    string levelId;
    string settingsId;
    private void Start()
    {
        Init();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(levelId);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void StartSettings()
    {
        SceneManager.LoadScene(settingsId);
    }
    public void Init()
    {
        levelId = "CutSceneOpening";
        settingsId = GameSettings.Instance.settingsId;
    }
}
