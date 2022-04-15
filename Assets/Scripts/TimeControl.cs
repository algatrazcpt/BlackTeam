using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimeControl : MonoBehaviour
{
    public GameObject gameStop;
    public static TimeControl Instance;
    void Start()
    {
        gameStop = GameObject.Find("GameStopObject");
        if(Instance!=null)
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
        FixdLoadAnimation.Instance.OpenAnimation();
        SceneManager.LoadScene("Level2", LoadSceneMode.Additive);
        

    }
}
