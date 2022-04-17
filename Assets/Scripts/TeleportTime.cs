using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TeleportTime : MonoBehaviour
{
    public GameObject gameDelete;
    public static TeleportTime Instance;
    public TMP_Text timerText;
    public float allTime = 30;
    public float teleportMaxTime=60;
    public float teleportCurrentTime = 60;
    public float timerExecuter = 1f;
    public bool isTimeFinished=false;
    public bool isSubLevel = false;
    void Start()
    {
        
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        StartAlltimeController();
        DontDestroyOnLoad(gameObject);
    }
    public void StartAlltimeController()
    {
        StartCoroutine("StartAlltime");
    }
    IEnumerator StartAlltime()
    {

        yield return new WaitForSeconds(timerExecuter);
        allTime -= timerExecuter;
        if(allTime==0)
        {
            GameOverScren();
        }
        if(isSubLevel==false)
        {
            timerText.text =""+ allTime;
        }
        StartCoroutine("StartAlltime");
    }
    void GameOverScren()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

    public void StartTeleportTimer()
    {
        StartCoroutine("TimerControl");

    }
    public void DeleteTimerNotBreak()
    {

        teleportCurrentTime = teleportMaxTime;
        timerText.text = "" + teleportMaxTime;
        isSubLevel = false;
        StopCoroutine("TimerControl");
    }
    public void ReturnMainTime()
    {
        isSubLevel = false;
        TimeControl.Instance.isSubState = false;
        gameDelete = GameObject.Find("GameDelete");
        Destroy(gameDelete);
        teleportCurrentTime = teleportMaxTime;
        timerText.text = "" + teleportMaxTime;
        SceneManager.LoadScene("CutScene", LoadSceneMode.Additive);
    }
    IEnumerator TimerControl()
    {
        yield return new WaitForSeconds(timerExecuter);
        teleportCurrentTime -= timerExecuter;
        timerText.text = "" + teleportCurrentTime;
        if (teleportCurrentTime == 0)
        {
            StopAllCoroutines();
            teleportCurrentTime = teleportMaxTime;
            ReturnMainTime();
        }
        else
        {
            TimeMessage(teleportCurrentTime);
            StartCoroutine("TimerControl");
        }
    }


    public void TimeMessage(float value)
    {
        if(teleportCurrentTime==20)
        {
            DialogControl.Instance.StartTaskChoice(0);
        }
        else if(teleportCurrentTime == 40)
        {
            DialogControl.Instance.StartTaskChoice(2);
        }
    }
}
