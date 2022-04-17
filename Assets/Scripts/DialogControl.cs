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
        lines[0] = "Çok fazla zamaným kalmadý bir önce çözmeliyim sorunu";
        lines[1] = "Artýk çok geç";
        lines[2] = "Gücüm tükeniyor";
        lines[3] = "Bütün bunlarýn sorumlusu nasýl bir virüs olabilir";
        lines[4] = "Burdan kaçmalýyým";
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
