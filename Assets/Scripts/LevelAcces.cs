using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAcces : MonoBehaviour
{
    public bool isLevelAcces1;
    public bool isLevelAcces2;
    public bool isLevelAcces3;
    public bool isLevelAcces4;
    void LevelControl(int value)
    {
        if(value==1)
        {
            isLevelAcces1=true;
        }
        else if (value == 2)
        {
            isLevelAcces2 = true;
        }
       else if (value == 3)
        {
            isLevelAcces3 = true;
        }
       else if (value == 4)
        {
            isLevelAcces4 = true;
        }

    }

}
