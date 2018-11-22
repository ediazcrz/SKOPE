using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RightController : MonoBehaviour
{

    public OVRInput.Controller controller = OVRInput.Controller.RTouch;

    bool teleportStarted;
    Vector2 joy;
    float isTriggerPressed;
    GameObject marker;
    GameObject camera;
	GameObject currentSelectedButton;
    LineRenderer line;
    RaycastHit hit;

    void Start()
    {
        marker = GameObject.Find("Marker");
        camera = GameObject.Find("OVRCameraRig");
        line = gameObject.GetComponent<LineRenderer>();
        //line.enabled = false;
        teleportStarted = false;
     }

    private void Update()
    {
        transform.position = OVRInput.GetLocalControllerPosition(controller) + camera.transform.position;
        transform.rotation = OVRInput.GetLocalControllerRotation(controller);
        joy = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);
        isTriggerPressed = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);

        // Cursor
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10.0f) && hit.transform.gameObject.tag != "Marker")
            marker.transform.position = hit.point;
        else
            marker.transform.position = new Vector3(0,-5,0);

        // Button

		if (hit.collider != null)
		if (hit.collider.gameObject.tag == "Button") {
			hit.collider.gameObject.GetComponent<Button> ().cursorEnter ();
			currentSelectedButton = hit.collider.gameObject;
		} else {
			if (currentSelectedButton != null) {
				currentSelectedButton.GetComponent<Button> ().cursorExit ();
				currentSelectedButton = null;
			}
		}
        

        // Teleportation
        if (joy.y > .8 && !teleportStarted)
        {
            teleportStarted = true;
            StartCoroutine(Teleport());
        }
            

    }

    IEnumerator Teleport()
    {
        //Two Line Points
        Vector3[] linePoints = new Vector3[2];
        Vector3 telePoint = camera.transform.position;

        //While joystick is still push forward
        while (joy.y > 0.1)
        {
            linePoints[0] = transform.GetChild(0).position;

            if (hit.collider != null)
            {
                    telePoint = hit.point + new Vector3(0, 0, -1.5f);
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

        teleportStarted = false;

        yield return null;
    }
}