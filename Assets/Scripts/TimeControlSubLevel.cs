using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimeControlSubLevel  : MonoBehaviour
{
    TimeControl timeControl;
    void Start()
    {
        timeControl = TimeControl.Instance;
    }

    public void ReturnGame()
    {
        LevelAcces.Instance.currentLevel = 0;
        SceneManager.UnloadSceneAsync(LevelAcces.Instance.GetCurrentLevel());
        timeControl.FrozenTime(false);

    }
}
