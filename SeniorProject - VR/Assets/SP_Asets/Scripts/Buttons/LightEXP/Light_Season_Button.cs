using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Season_Button : Button {

    int currentSeason = 0;

    Texture summer;
    Texture fall;
    Texture winter;
    Texture spring;
    MeshRenderer rend;

    Light_Time_Button lightTime;

    // Use this for initialization
    void Start () {
        rend = GetComponent<MeshRenderer>();
        summer = Resources.Load("Materials/Summer", typeof(Texture)) as Texture;
        fall = Resources.Load("Materials/Fall", typeof(Texture)) as Texture;
        winter = Resources.Load("Materials/Winter", typeof(Texture)) as Texture;
        spring = Resources.Load("Materials/Spring", typeof(Texture)) as Texture;
        rend.material.mainTexture = spring;
        lightTime = GameObject.Find("Light_Time").GetComponent<Light_Time_Button>();
    }

    public override void onClick()
    {
        seasonChange();
        GameObject.FindObjectOfType<SunControl>().ChangeSun(getSeason() * 3 + lightTime.getTime());
    }

    public int getSeason()
    {
        return currentSeason;
    }


    public void seasonChange()
    {
        currentSeason = (currentSeason + 1) % 4;
        if (currentSeason == 0)
        {
            rend.material.mainTexture = spring;
        }
        else if (currentSeason == 1)
        {
            rend.material.mainTexture = summer;

        }
        else if (currentSeason == 2)
        {
            rend.material.mainTexture = fall;

        }
        else if (currentSeason == 3)
        {
            rend.material.mainTexture = winter;

        }
    }
}
