﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameScript : MonoBehaviour
{
            [Header("Set in Inspector")]
        public GameObject ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnMouseDown()
    {
        //exits game
        Application.Quit();
    }
}
