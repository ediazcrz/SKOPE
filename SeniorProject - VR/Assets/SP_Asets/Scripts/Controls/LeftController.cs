using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeftController : MonoBehaviour
{

    public OVRInput.Controller controller = OVRInput.Controller.LTouch;
    GameObject camera;

    public OptionPanel optionPanel;
    public MapPanel mapPanel;
    public InfoPanel infoPanel;

    public static LeftController instance;

    private void Start()
    {
        instance = this;
        optionPanel = GameObject.Find("OptionsPane").GetComponent<OptionPanel>();
        mapPanel = GameObject.Find("MapPane").GetComponent<MapPanel>();
        infoPanel = GameObject.Find("InfoPane").GetComponent<InfoPanel>();
        if (GameObject.Find("OVRCameraRig") != null)
        {
            camera = GameObject.Find("OVRCameraRig");
        }
    }
    private void Update()
    {
        if (GameObject.Find("OVRCameraRig") != null)
        {
            transform.localPosition = OVRInput.GetLocalControllerPosition(controller); ;
            transform.localRotation = OVRInput.GetLocalControllerRotation(controller);

            Vector2 joy = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);
            transform.GetChild(0).transform.Rotate(new Vector3(joy.y * 3, 0, 0));
        }
        else
        {
            if(Input.GetKey("q"))
            {
                transform.GetChild(0).transform.Rotate(new Vector3(3, 0, 0));
            }
            if (Input.GetKey("z"))
            {
                transform.GetChild(0).transform.Rotate(new Vector3(-3, 0, 0));
            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit ;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               
                if (Physics.Raycast(ray, out hit,1,5))
                {
                    if (hit.collider.gameObject.tag == "Button" || hit.collider.gameObject.tag == "BigButton")
                    {
                        Button button = hit.collider.gameObject.GetComponent<Button>();
                        if (button != null)
                        {
                            button.onClick();
                           
                        }
                    }

                }
            }


        }
    }
}

