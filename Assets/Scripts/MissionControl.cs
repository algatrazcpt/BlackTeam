using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MissionControl : MonoBehaviour
{
    public static MissionControl Instance;
    public TMP_Text taskTextTMP;
    private string[] lines=new string[7];
    public int index;
    public float textWriteSpeed;
    public Animator animator;
    public bool []allTaskState=new bool[7];
    void Start()
    {
        taskTextTMP.text = "";
        for (int i = 0; i < allTaskState.Length; i++)
        {
            allTaskState[i] = true;
        }
        if (Instance != null)
        {
            Destroy(Instance);
        }
        TaskInits();
        Instance = this;

        DontDestroyOnLoad(gameObject);

    }
    void TaskInits()
    {
        index = 0;
        lines[0] = "Zaman Sistemini Kullan";
        lines[1] = "Seviye Bir Eri�im Elde Et";
        lines[2] = "Hanhgara Git";
        lines[3] = "Seviye �kinci Eri�im Elde Et";
        lines[4] = "Hangardaki G�� Par�as�n� Bul  ";
        lines[5] = "Kontrol odas�ndaki baglant�y� d�zelt ";
        lines[6] = "Seviye 3 eri�im kazan  ";
    }
    public bool TaskState(int value)
    {
        return allTaskState[value];
    }
    public void GetTask(int value)
    {
        index = value;
    }
    public void StartTask()
    {
        allTaskState[index] =false;
        taskTextTMP.text = "";
        if (index > lines.Length)
        {

        }
        else
        {
            animator.SetTrigger("TaskGetT");
            StartCoroutine("Typline");
        }
    }
    IEnumerator Typline()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            taskTextTMP.text += c;
            yield return new WaitForSeconds(textWriteSpeed);
        }
    }
}
