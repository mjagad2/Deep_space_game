using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instruction : MonoBehaviour
{
    public void leaveScene1()
    {
        SceneManager.LoadScene(0);
    }
}
