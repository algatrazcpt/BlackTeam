using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TeleportTime : MonoBehaviour
{
    public static TeleportTime Instance;
    public TMP_Text timerText;
    public float teleportMaxTime=60;
    public float teleportCurrentTime = 60;
    public float timerExecuter = 1f;
    public bool isTimeFinished=false;
    void Start()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    public void StartTeleportTimer()
    {
        StartCoroutine("TimerControl");

    }
    public void DeleteTimerNotBreak()
    {
        teleportCurrentTime = teleportMaxTime;
        timerText.text = "" + teleportMaxTime;
        StopAllCoroutines();
    }
    public void ReturnMainTime()
    {
        TimeControl.Instance.isSubState = false;
        Destroy(gameObject);
        SceneManager.LoadScene("CutScene", LoadSceneMode.Additive);
        Debug.Log("Wroking");
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
