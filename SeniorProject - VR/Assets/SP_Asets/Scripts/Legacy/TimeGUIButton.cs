using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGUIButton : MonoBehaviour {

	int currentTime = 0;
	// Use this for initialization
	Texture nine;
	Texture twelve;

	Texture five;
	void Start () {
		nine = Resources.Load("Materials/9am",typeof(Texture)) as Texture;
		twelve = Resources.Load("Materials/12pm",typeof(Texture)) as Texture;
		five = Resources.Load("Materials/5pm",typeof(Texture)) as Texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public int getTime(){
		return currentTime;
	}

	public void timeChange(){
		currentTime = (currentTime + 1) % 3;
		if (currentTime == 0) {
			this.GetComponent<Renderer>().material.mainTexture = nine;
			
		} else if (currentTime == 1) {
			this.GetComponent<Renderer>().material.mainTexture = twelve;
		
		} else if (currentTime == 2) {
			this.GetComponent<Renderer>().material.mainTexture = five;
		
		}
	}
}
