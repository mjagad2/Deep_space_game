﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtonScript : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;

    private void Awake()
    {
        for(int i = 0; i < 6; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
        }
    }
}
