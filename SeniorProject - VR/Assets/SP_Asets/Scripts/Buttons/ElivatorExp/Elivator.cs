using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elivator : Button
{

    bool active;

    GameObject wall;
  

    // Use this for initialization
    void Start()
    {
        active = true;
        wall = GameObject.Find("E2 Lobby Wall");
 
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
