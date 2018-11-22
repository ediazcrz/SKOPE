using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonGUIButton : MonoBehaviour {

	int currentSeason = 0;
	// Use this for initialization
	Texture summer;
	Texture fall;
	Texture winter;
	Texture spring;
	MeshRenderer rend;

	void Start () {
		rend = GetComponent<MeshRenderer> ();
		summer = Resources.Load ("Materials/Summer", typeof(Texture)) as Texture;
		fall = Resources.Load("Materials/Fall",typeof(Texture)) as Texture;
		winter = Resources.Load("Materials/Winter",typeof(Texture)) as Texture;
		spring = Resources.Load("Materials/Spring",typeof(Texture)) as Texture;
		rend.material.mainTexture = spring;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public int getSeason(){
		return currentSeason;
	}

	public void seasonChange(){
		currentSeason = (currentSeason + 1) % 4;
		if (currentSeason == 0) {
			rend.material.mainTexture = spring;
		} else if (currentSeason == 1) {
			rend.material.mainTexture = summer;

		} else if (currentSeason == 2) {
			rend.material.mainTexture = fall;

		} else if (currentSeason == 3) {
			rend.material.mainTexture = winter;

		}
	}
}
