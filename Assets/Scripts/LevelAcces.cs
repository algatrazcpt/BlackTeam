using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAcces : MonoBehaviour
{
    public static LevelAcces Instance;
    private bool[] isLevelAcces = new bool[5];
    public bool isMainAcces=true;
    public int maxLevel = 4;
    public int currentLevel=1;
    private string[] allLevels=new string[5];
    public void Awake()
    {
        allLevels[0] = "MainGame A";
        allLevels[1] = "MainGame B";
        allLevels[2] = "MainGame C";
        isLevelAcces[0] = false;
        isLevelAcces[1] = false;
        isLevelAcces[2] = false;

        if (Instance!=null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LevelControl(int value)
    {
        isLevelAcces[value] = true;
    }
    public string GetCurrentLevel()
    {
        if (AccesControl())
        {
            return allLevels[currentLevel];
        }
        else
        {
            Debug.Log("Level eriþimi yok");
            return "ERROR";
        }
    }
    public bool AccesControl()
    {
        if (isLevelAcces[currentLevel])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
