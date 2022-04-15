using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixdLoadAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public static FixdLoadAnimation Instance;
    public float animationDuration = 5f;
    public Animator animator;
    void Start()
    {
        if(Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OpenAnimation()
    {
        StartCoroutine("AnimationController");
    }
    IEnumerator AnimationController()
    {
        animator.SetTrigger("StartLoadT");
        yield return new WaitForSeconds(animationDuration);
        animator.SetTrigger("ExitLoadT");
    }
}
