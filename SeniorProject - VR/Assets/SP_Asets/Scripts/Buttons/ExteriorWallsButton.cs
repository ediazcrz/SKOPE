using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExteriorWallsButton : Button{

    // Use this for initialization
    GameObject walls;

	void Start () {
        walls = GameObject.Find("EnvelopeE4");
	}

    public override void onClick()
    {
        if (walls.activeSelf)
        {
            walls.SetActive(false);
        }
        else
        {
            walls.SetActive(true);
        }
    }
}
