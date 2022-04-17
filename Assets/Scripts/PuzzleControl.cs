using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControl : MonoBehaviour
{
    // Start is called before the first frame update
    float currentRotate;
    public int currentPosition = 0;
    public int accesPosition = 1;
    public int puzzleÝd =0;
    void Start()
    {
        currentRotate = transform.rotation.y;
    }
    public void ChangeRotation()
    {
        accesPosition += 1;
        if(accesPosition>4)
        {
            accesPosition = 0;
        }
        currentRotate += 90;
        transform.Rotate(0f, currentRotate, 0.0f);
    }
}
