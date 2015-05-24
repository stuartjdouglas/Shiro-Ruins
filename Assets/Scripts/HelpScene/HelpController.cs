﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelpController : MonoBehaviour {

    public GameObject sliderObject;
    private float inputAmount;
    private float sliderValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        playerInput();

        
	}


    public void changeLevel(int level)
    {
        GameManager.instance.changeLevel(level);
    }

    private void playerInput()
    {
        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("delete"))
        {
            GameManager.instance.changeLevel(1);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            inputAmount = 0.01f * Input.GetAxisRaw("Vertical");
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            inputAmount = 0.01f * Input.GetAxisRaw("Vertical");
        }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            inputAmount = 0;
        }
        else if (Input.GetAxisRaw("Vertical") > 0.6f)
        {
            inputAmount = 0.01f * 0.6f;
        }

        sliderValue = sliderObject.GetComponent<Scrollbar>().value;

        sliderObject.GetComponent<Scrollbar>().value += inputAmount;
    }
}
