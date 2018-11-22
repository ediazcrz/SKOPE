using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalButton : Button {

    bool active;

    GameObject wall;
    GameObject Mech;

    // Use this for initialization
    void Start() {
        active = true;
        wall = GameObject.Find("Mechanical");
     
       
    }
    private void Update()
    {
        if (GameObject.Find("OVRCameraRig") != null)
        {
            this.transform.LookAt(new Vector3(GameObject.Find("OVRCameraRig").transform.position.x, this.transform.position.y, GameObject.Find("FPSController").transform.position.z));
        }
        else
        {
            this.transform.LookAt(new Vector3(GameObject.Find("FPSController").transform.position.x, this.transform.position.y, GameObject.Find("FPSController").transform.position.z));
        }
    }
    public override void onClick()
    {
        if (active)
        {
            wall.SetActive(false);
       
            active = false;
        }
        else
        {
            wall.SetActive(true);
         
            active = true;
        }
    }

    
}
