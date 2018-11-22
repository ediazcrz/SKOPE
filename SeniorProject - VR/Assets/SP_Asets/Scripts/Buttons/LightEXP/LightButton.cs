using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : Button {

    // Use this for initialization

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
        GameObject.Find("FPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_GravityMultiplier = 0;
        InfoPanel.setTextPanel("LIGHT_INTRO");
        if (LeftController.instance != null)
        {
            LeftController.instance.infoPanel.enableExitButton();
            LeftController.instance.optionPanel.setOptionPanel("LightOptions");
        }
        if (GameObject.Find("OVRCameraRig") != null)
        {
            GameObject.Find("OVRCameraRig").transform.position = new Vector3(-55f, 60f, 40f);
        }
        else
        {
            GameObject.Find("FPSController").transform.position = new Vector3(-55f, 60f, 40f);
        }

           
    }
}
