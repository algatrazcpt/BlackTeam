using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChipsSifreControls : MonoBehaviour
{
    public Animator animator;
    public static ChipsSifreControls Instance;
    public TMP_Text sabitTaskText;
    public static int maxChips = 16;
    public int currentChips = 0;
    public bool allChipsDone = false;
    public string chipsMetin = "Tüm SifreChiplerini Topla" + maxChips + "/"+0;
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
    public void AddChips()
    {
        if (currentChips >= maxChips)
        {
            allChipsDone = true;
            chipsMetin = "Makinayý Kurtar";
            sabitTaskText.text = chipsMetin;
        }
        else
        {
            sabitTaskText.text = "";
            currentChips += 1;
            chipsMetin = "Tüm SifreChiplerini Topla" + maxChips + "/" + currentChips;
            sabitTaskText.text = chipsMetin;
            animator.SetTrigger("TaskGetT");
        }
    }
}
