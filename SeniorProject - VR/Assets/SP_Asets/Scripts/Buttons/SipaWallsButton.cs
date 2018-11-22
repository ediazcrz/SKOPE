using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SipaWallsButton : Button {

    List<GameObject> walls;
    bool active;

	// Use this for initialization
	void Start () {
        walls = new List<GameObject>();
        for(int x = 0; x < 19; x++)
        {
            walls.Add(GameObject.Find("SIPA_WALL_" + x));
        }

        active = true;
	}
    public void Update()
    {
        
    }

    public override void onClick()
    {
        if (active)
        {
            foreach (GameObject wall in walls)
            {
                wall.SetActive(false);
            }
            active = false;
        }
        else
        {
            foreach (GameObject wall in walls)
            {
                wall.SetActive(true);
            }
            active = true;
        }
    }
}
