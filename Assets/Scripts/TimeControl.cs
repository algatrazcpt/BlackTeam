using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimeControl : MonoBehaviour
{

    LevelAcces level;
    public GameObject gameStop;
    public static TimeControl Instance;
    public bool isSubState=false;
    void Start()
    {
        level = LevelAcces.Instance;
        gameStop = GameObject.Find("GameStopObject");
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void FrozenTime(bool value)
    {
        if (value)
        {
            gameStop.SetActive(false);
        }
        else
        {
            gameStop.SetActive(true);
        }
    }
    public void StartLevel()
    {
        FrozenTime(true);
        SceneManager.LoadScene("CutScene", LoadSceneMode.Additive);
        //SceneManager.LoadScene(LevelAcces.Instance.GetCurrentLevel(), LoadSceneMode.Additive);
    }
    public void ReturnGame()
    {
        LevelAcces.Instance.currentLevel = 0;
        SceneManager.LoadScene("CutScene", LoadSceneMode.Additive);
        //SceneManager.UnloadSceneAsync(LevelAcces.Instance.GetCurrentLevel());
        FrozenTime(false);

    }
}