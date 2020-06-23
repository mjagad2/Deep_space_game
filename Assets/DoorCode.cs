using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCode : MonoBehaviour
{
    [SerializeField]
    private GameObject winText;

    [SerializeField]
    Text codeText;

    string codeTextValue = "";

    public static bool youWin2;
    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        youWin2 = false;
    }
    // Start is called before the first frame update
    void Update()
    {
        codeText.text = codeTextValue;
        if(codeTextValue=="783")
        {
            youWin2 = true;
            winText.SetActive(true);
        }
        else
        if (codeTextValue.Length > 3)
        {
            codeTextValue = "";
        }
       
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
   
}
