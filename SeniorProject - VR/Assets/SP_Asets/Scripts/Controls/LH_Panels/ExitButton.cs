using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : Button {

    static Vector3 originalPosition;

	// Use this for initialization

	public override void onClick()
    {
        if (GameObject.Find("OVRCameraRig") != null)
        {
            GameObject.Find("OVRCameraRig").transform.position = originalPosition;
        }
        else
        {
            GameObject.Find("FPSController").transform.position = originalPosition;
            GameObject.Find("FPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_GravityMultiplier = 2;
        }
        InfoPanel.setTextPanel("SIPA_INTRO");
        LeftController.instance.optionPanel.disableOptionPanel();
        this.gameObject.SetActive(false);
    }

    public void setOriginalPosition(Vector3 position)
    {
        originalPosition = position;
    }
}
