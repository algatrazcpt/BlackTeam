using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerConmtrol : MonoBehaviour
{
    public void GameFinish()
    {
        
        SceneManager.LoadScene("GameFinish");
    }
}
