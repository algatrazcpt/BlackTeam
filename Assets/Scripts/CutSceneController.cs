using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    public Animator animator;
    public int levelId;
    void Start()
    {
        sceneName = LevelAcces.Instance.GetCurrentLevel();
        if (TimeControl.Instance.isSubState)
        {
            animator.SetTrigger("LoadT");
        }
        else
        {
            animator.SetTrigger("UnloadT");
        }
    }
    public void ChangeScene()
    {
        Debug.Log("LoadScene");
        SceneManager.UnloadSceneAsync("CutScene");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
    public void UnloadScene()
    {

        Debug.Log("UnloadScene");
        SceneManager.UnloadSceneAsync("CutScene");
        SceneManager.UnloadSceneAsync(sceneName);
        TimeControl.Instance.FrozenTime(true);
        TimeControl.Instance.FrozenTime(false);
        //TimeControl.Instance.FrozenTime(false);
    }
}
