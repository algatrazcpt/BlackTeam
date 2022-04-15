using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimeControlSubLevel : MonoBehaviour
{
    TimeControl timeControl;
    void Start()
    {
        timeControl = TimeControl.Instance;
    }
    public void ReturnGame()
    {
        
        FixdLoadAnimation.Instance.OpenAnimation();
       
        SceneManager.UnloadSceneAsync("Level2");
        timeControl.FrozenTime(false);
    }
}
