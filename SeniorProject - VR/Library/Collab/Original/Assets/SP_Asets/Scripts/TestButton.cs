using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : Button {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void onClick()
    {

    }

    public override void cursorEnter()
    {
        //Debug.Log("CursorEnter Called");
        GetComponent<Renderer>().material.color =  new Color(200f/255f, 200f/255f,200f/255f,200f/255f);
        
    }
	public override void cursorExit()
	{
		//Debug.Log("CursorEnter Called");
		GetComponent<Renderer>().material.color =  new Color(0,0,0,0);

	}
}
