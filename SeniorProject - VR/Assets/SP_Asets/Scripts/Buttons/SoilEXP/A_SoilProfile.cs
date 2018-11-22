using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_SoilProfile : Button {

	// Use this for initialization
	void Start () {
		
	}
	void Update() {

        if (GameObject.Find("OVRCameraRig") != null)
        {
            this.transform.LookAt(new Vector3(GameObject.Find("OVRCameraRig").transform.position.x, this.transform.position.y, GameObject.Find("FPSController").transform.position.z));
        }
        else
        {
            this.transform.LookAt(new Vector3( GameObject.Find("FPSController").transform.position.x, this.transform.position.y, GameObject.Find("FPSController").transform.position.z));
        }
    }
    public override void onClick()
    {
        InfoPanel.setTextPanel("SOIL_INTRO");
        if (LeftController.instance != null) { 
            LeftController.instance.infoPanel.enableExitButton();
    }
        if (GameObject.Find("OVRCameraRig") != null)
        {
            GameObject.Find("OVRCameraRig").transform.position = new Vector3(667.6385f, 35.5755f, 250.0379f);
        }
        else
        {
            GameObject.Find("FPSController").transform.position = new Vector3(667.6385f, 35.5755f, 250.0379f);
        }
        GameObject.Find("Soil Animation - 120516").GetComponent<Animation>().Rewind();
        GameObject.Find("Soil Animation - 120516").GetComponent<Animation>().Play();
    }
}
