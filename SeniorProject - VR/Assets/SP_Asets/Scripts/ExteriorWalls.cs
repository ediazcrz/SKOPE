using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExteriorWalls : MonoBehaviour {
	public Renderer rend;
	public Collider coll;
	// Use this for initialization
	bool visible = true;
	bool visibleChanged = false;
	void Start () {
		rend = GetComponent<Renderer> ();
		coll = GetComponent<Collider> ();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (visibleChanged) {
			if (visible) {
				rend.enabled = true;
				coll.enabled = true;
			} else {
				rend.enabled = false;
				coll.enabled = false;
			}
			visibleChanged = false;
		}
	}
	public void changeVisibility(){
		visible = !visible;
		visibleChanged = true;
	}
}
