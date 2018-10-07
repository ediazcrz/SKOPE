using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUpdate : MonoBehaviour {

    public Text dist;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dist.text = "Distance from SIPA: \n" + Distance.Instance.dist2.ToString() + "m";
    }
}
