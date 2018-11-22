using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : Button {
	bool cursorOn = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void onClick()
    {
        Debug.Log("Button Pressed");
    }

    /*public override void cursorEnter()
    {
        //Debug.Log("CursorEnter Called");
		if(!cursorOn){
			cursorOn = true;
			GetComponent<Renderer>().material.color =  new Color(200f/255f, 200f/255f,200f/255f,200f/255f);
		}
        
    }
	public override void cursorExit()
	{
		//Debug.Log("CursorEnter Called");
		if (cursorOn) {
			cursorOn = false;
			GetComponent<Renderer>().material.color =  new Color(1,1,1,1);
		}

	}*/
}
