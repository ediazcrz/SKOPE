using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using AssemblyCSharp;

public class RightController : MonoBehaviour
{

    public OVRInput.Controller controller = OVRInput.Controller.RTouch;

    Vector2 joy;
    float isTriggerPressed;

	GameObject marker;
	GameObject markerUI;
    GameObject camera;
    GameObject mapCursor;

    LineRenderer line;

    RaycastHit hit;

    bool teleportStarted;
    bool buttonLock = false;

    Counter c = new Counter(500);


    void Start()
    {
        marker = GameObject.Find("Marker");
		markerUI = GameObject.Find("MarkerUI");
        camera = GameObject.Find("OVRCameraRig");
        mapCursor = GameObject.Find("MapCursor");
        line = gameObject.GetComponent<LineRenderer>();
        teleportStarted = false;
     }

    private void Update()
	{
        //check out if this changees to a specific amount, then adjust it for that, remove that
        transform.localPosition = OVRInput.GetLocalControllerPosition(controller); ;
		transform.localRotation = OVRInput.GetLocalControllerRotation (controller);
		joy = OVRInput.Get (OVRInput.Axis2D.PrimaryThumbstick, controller);
		isTriggerPressed = OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger, controller);

        // Cursor
        if (Physics.Raycast(transform.position, transform.forward, out hit, 15.0f) && hit.collider.gameObject.tag != "Marker")
        {
            marker.transform.position = hit.point;

            if (hit.collider.gameObject.tag == "LeftHand" || hit.collider.gameObject.tag == "Button")
                marker.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
            else
                marker.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            marker.transform.position = new Vector3(10,5,0);
        }

        //Press Button Once
        if (buttonLock && isTriggerPressed == 0 )
            buttonLock = false;

        // Button
        if (hit.collider != null)
        {
            if (isTriggerPressed > 0 && !buttonLock || Input.GetKeyUp("e") && !buttonLock)
            {
                if (hit.collider.gameObject.tag == "Button" || hit.collider.gameObject.tag == "BigButton")
                {
                    Button button = hit.collider.gameObject.GetComponent<Button>();
                    if (button != null)
                    {
                        button.onClick();
                        buttonLock = true;
                    }
                }
            }

        }
			/*if (hit.collider.gameObject.name == "Button") {
				hit.collider.gameObject.GetComponent<Button> ().cursorEnter ();
				currentSelectedButton = hit.collider.gameObject;
			} else if (hit.collider.gameObject.tag == "Exterior Walls") {
				hit.collider.gameObject.GetComponent<ExteriorWalls> ().changeVisibility ();	
			} else if (hit.collider.gameObject.name == "RemoveWallsButton") {
				hit.collider.GetComponent<TestButton> ().cursorEnter ();
				if (OVRInput.Get (OVRInput.Button.One) && c.ready ()) {
					c.startTime ();
					wallsActive = !wallsActive;
					foreach (ExteriorWalls g in (GameObject.FindObjectsOfType<ExteriorWalls>()))
						if (wallsActive)
							g.changeVisibility ();
						else
							g.changeVisibility ();
				}
			} else if (hit.collider.gameObject.name == "SeasonGUIButton") {
				if (OVRInput.Get (OVRInput.Button.One) && c.ready ()) {
					c.startTime ();
					hit.collider.GetComponent<SeasonGUIButton> ().seasonChange ();
					GameObject.FindObjectOfType<SunControl> ().ChangeSun (GameObject.FindObjectOfType<SeasonGUIButton> ().getSeason () * 3 + GameObject.FindObjectOfType<TimeGUIButton> ().getTime ());
				}
			} else if (hit.collider.gameObject.name == "TimeGUIButton") {
				if (OVRInput.Get (OVRInput.Button.One) && c.ready ()) {
					c.startTime ();
					hit.collider.GetComponent<TimeGUIButton> ().timeChange ();
					GameObject.FindObjectOfType<SunControl> ().ChangeSun (GameObject.FindObjectOfType<SeasonGUIButton> ().getSeason () * 3 + GameObject.FindObjectOfType<TimeGUIButton> ().getTime ());

				}
			} else if (hit.collider.gameObject.name == "HomeButton") {	
				if (OVRInput.Get (OVRInput.Button.One) && c.ready ()) {
					camera.transform.position = new Vector3 (-39f, 35f, 46f);			
				}
			}else if (hit.collider.gameObject.name == "BuildingButton") {
				if (OVRInput.Get (OVRInput.Button.One) && c.ready ()) {
					camera.transform.position = new Vector3 (331f, 35f, 410f);
					GameObject.Find ("E2 Revised Animation").GetComponent<Animation> ().Rewind ();
					GameObject.Find ("E2_BuildingAnimation_050917").GetComponent<Animation> ().Rewind ();
					GameObject.Find ("E2 Revised Animation").GetComponent<Animation> ().Play ();
					GameObject.Find ("E2_BuildingAnimation_050917").GetComponent<Animation> ().Play ();
				}

			}else if (hit.collider.gameObject.name == "SoilProfileButton") {
				if (OVRInput.Get (OVRInput.Button.One) && c.ready ()) {
					camera.transform.position = new Vector3 (631f, 60f, 359f);
					GameObject.Find ("Soil Animation - 120516").GetComponent<Animation> ().Rewind ();
					GameObject.Find ("Soil Animation - 120516").GetComponent<Animation> ().Play ();
				}

			}else if (hit.collider.gameObject.name == "SIPAPanelsButton") {
				if (OVRInput.Get (OVRInput.Button.One) && c.ready ()) {
					camera.transform.position = new Vector3 (47.16f, 35f, 357f);	
					GameObject.Find ("E2 Animation Khandakar").GetComponent<Animation> ().Rewind ();
					GameObject.Find ("E2 Animation Khandakar").GetComponent<Animation> ().Play ();
				}

			}else {
				foreach (TestButton tb in GameObject.FindObjectsOfType<TestButton>())
					tb.cursorExit ();				
			}
		}*/
        

        // Teleportation
		if (OVRInput.Get(OVRInput.Button.One, controller) && !teleportStarted)
		{
			//print ("asd");
            //Debug.Log("A Pressed");
			if (hit.collider != null) {
				if (hit.collider.gameObject.tag == "Walkable") {
					teleportStarted = true;
					StartCoroutine (Teleport ());
				}
			}
		}

        //Camera Rotation

        if(camera != null)
        camera.transform.Rotate(new Vector3(0, joy.x,0));
    }

    IEnumerator Teleport()
    {
        //Two Line Points
        Vector3[] linePoints = new Vector3[2];
        Vector3 telePoint = camera.transform.position;

        //While joystick is still push forward
		while (OVRInput.Get(OVRInput.Button.One, controller))
        {
            linePoints[0] = transform.GetChild(0).position;

            if (hit.collider != null)
            {
                telePoint = hit.point;// + new Vector3(0, 0, -1.2f);
                    linePoints[1] = hit.point;
                    line.SetPositions(linePoints);
                
            }
            else
            {
                linePoints[1] = transform.position;
                line.SetPositions(linePoints);
                telePoint = camera.transform.position;
            }

            yield return null;
        }

        camera.transform.position = telePoint;

        linePoints[0] = transform.GetChild(0).position;
        linePoints[1] = transform.GetChild(0).position;
        line.SetPositions(linePoints);

        //mapCursor.transform.localPosition = new Vector3((- 10f - camera.transform.position.x)/318, -1 , (21.3f + camera.transform.position.z)/ 318);
        LeftController.instance.mapPanel.updateCursor(camera.transform.position.x, camera.transform.position.z);

        teleportStarted = false;

        yield return null;
    }
}














































































