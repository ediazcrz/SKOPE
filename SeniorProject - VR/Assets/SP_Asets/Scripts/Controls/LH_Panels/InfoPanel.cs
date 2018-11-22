using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour {

    public static InfoPanel infoPanel;

    GameObject textPanel;
    GameObject audioButton;
    GameObject exitButton;

	// Use this for initialization
	void Start () {

        infoPanel = this;

        textPanel = this.transform.GetChild(0).gameObject;
        audioButton = this.transform.GetChild(1).gameObject;
        exitButton = this.transform.GetChild(2).gameObject;

        setTextPanel("SIPA_INTRO");
        exitButton.SetActive(false);
	}

   public static void setTextPanel(string panelName)
    {
        if(infoPanel !=null)
        infoPanel.textPanel.GetComponent<Renderer>().material.mainTexture = Resources.Load("InfoPane/Text/" + panelName, typeof(Texture)) as Texture;
    }

    public void enableExitButton()
    {
        infoPanel.exitButton.SetActive(true);
        if (GameObject.Find("OVRCameraRig") != null)
        {
            infoPanel.exitButton.GetComponent<ExitButton>().setOriginalPosition(GameObject.Find("OVRCameraRig").transform.position); ;
        }
        else
        {
            infoPanel.exitButton.GetComponent<ExitButton>().setOriginalPosition(GameObject.Find("FPSController").transform.position); ;
        }
    }

    public static void setInfoPanel(string codeName)
    {

    }
}
