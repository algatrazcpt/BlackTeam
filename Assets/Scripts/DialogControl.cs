using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogControl : MonoBehaviour
{
    public static DialogControl Instance;
    public TMP_Text dialogTextTMP;
    private string[] lines = new string[5];
    public int index;
    public float textWriteSpeed;
    public Animator animator;
    void Start()
    {
        dialogTextTMP.text = "";
        if (Instance != null)
        {
            Destroy(Instance);
        }
        DialogInits();
        Instance = this;

        DontDestroyOnLoad(gameObject);

    }
    void DialogInits ()
    {
        index = 0;
        lines[0] = "�ok fazla zaman�m kalmad� bir �nce ��zmeliyim sorunu";
        lines[1] = "Art�k �ok ge�";
        lines[2] = "G�c�m t�keniyor";
        lines[3] = "B�t�n bunlar�n sorumlusu nas�l bir vir�s olabilir";
        lines[4] = "Burdan ka�mal�y�m";
    }
    public void TaskState(int value)
    {
        index=Random.Range(0, lines.Length);
    }
    public void StartTaskChoice(int value)
    {
        index = value;
        animator.SetTrigger("DialogGetT");
        StartCoroutine("Typline");
    }
    public void StartTaskRandom()
    {
        index = Random.Range(0, lines.Length);
        dialogTextTMP.text = "";
        animator.SetTrigger("DialogGetT");
        StartCoroutine("Typline");
    }

    IEnumerator Typline()
    {
        dialogTextTMP.text = "";
        foreach (char c in lines[index].ToCharArray())
        {
            dialogTextTMP.text += c;
            yield return new WaitForSeconds(textWriteSpeed);
        }
        //animator.SetTrigger("DialogDeleteT");
    }
}
