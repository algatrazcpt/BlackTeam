using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CustomDialog : MonoBehaviour
{
    public static CustomDialog Instance;
    public TMP_Text customDialogTextTMP;
    private string[] lines = new string[5];
    public int index;
    public float textWriteSpeed;
    public Animator animator;
    void Start()
    {
        customDialogTextTMP.text = "";
        if (Instance != null)
        {
            Destroy(Instance);
        }
        DialogInits();
        Instance = this;

        DontDestroyOnLoad(gameObject);

    }
    void DialogInits()
    {
        index = 0;
        lines[0] = "Chip kullan (E)";
        lines[1] = "�ifre Par�as�n� Kullan (E)";
        lines[2] = "Zaman� b�k (E)";
        lines[3] = "B�t�n bunlar�n sorumlusu nas�l bir vir�s olabilir";
        lines[4] = "Burdan ka�mal�y�m";
    }
    public void StartTaskChoice(int value)
    {
        index = value;
        customDialogTextTMP.text = lines[index];
        
        StartCoroutine("Typline");
    }
    public void StarAnimation()
    {
        animator.SetBool("isItemT", true);
    }
    public void StopAnimation()
    {
        animator.SetBool("isItemT",false);
    }

}
