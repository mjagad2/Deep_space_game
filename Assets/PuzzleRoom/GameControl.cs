using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject winText;

    [SerializeField]
    private Transform[] pictures;

    public static bool youWin;
    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        youWin = false;
    }

    // Update is called once per frame
    void Update(){
        if (System.Math.Abs(pictures[0].rotation.z) < Mathf.Epsilon &&
            System.Math.Abs(pictures[1].rotation.z) < Mathf.Epsilon &&
            System.Math.Abs(pictures[2].rotation.z) < Mathf.Epsilon &&
            System.Math.Abs(pictures[3].rotation.z) < Mathf.Epsilon &&
            System.Math.Abs(pictures[4].rotation.z) < Mathf.Epsilon &&
            System.Math.Abs(pictures[5].rotation.z) < Mathf.Epsilon &&
            System.Math.Abs(pictures[6].rotation.z) < Mathf.Epsilon &&
            System.Math.Abs(pictures[7].rotation.z) < Mathf.Epsilon &&
            System.Math.Abs(pictures[8].rotation.z) < Mathf.Epsilon)
        {
            youWin = true;
            winText.SetActive(true);
        }
    }
}
