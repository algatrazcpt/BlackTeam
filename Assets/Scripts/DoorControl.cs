using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public Animator animator;
    public int levelAcces›d=0;
    public bool doorState = false;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("DoorTriger");
        if(LevelAcces.Instance.AccesControlCustom(levelAcces›d)&&doorState==false)
        {
            animator.SetTrigger("DoorOpen");
            doorState = true;
        }
    }
}
