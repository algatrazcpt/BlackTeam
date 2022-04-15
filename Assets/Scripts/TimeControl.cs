using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimeControl : MonoBehaviour
{
    private GameObject gameStop;
    void Start()
    {
        gameStop = GameObject.Find("GameStop");
    }
    void Update()
    {
        
    }
    public void ReturnGame()
    {
        FrozenTime(false);
        SceneManager.UnloadSceneAsync("Level2");
        GameObject.Find("GameStop").SetActive(false);
        
    }
    void FrozenTime(bool value)
    {
        if(value)
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
        SceneManager.LoadScene("Level2",LoadSceneMode.Additive);
        
    }
}
