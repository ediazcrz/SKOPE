using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Time_Button : Button {

    int currentTime = 0;
    // Use this for initialization
    Texture nine;
    Texture twelve;
    Texture five;

    Light_Season_Button lightSeason;

    // Use this for initialization
    void Start () {
        nine = Resources.Load("Materials/9am", typeof(Texture)) as Texture;
        twelve = Resources.Load("Materials/12pm", typeof(Texture)) as Texture;
        five = Resources.Load("Materials/5pm", typeof(Texture)) as Texture;
        lightSeason = GameObject.Find("Light_Season").GetComponent<Light_Season_Button>();
    }
	

    public override void onClick()
    {
        timeChange();
        GameObject.FindObjectOfType<SunControl>().ChangeSun(lightSeason.getSeason() * 3 + getTime());
    }

    public int getTime()
    {
        return currentTime;
    }

    public void timeChange()
    {
        currentTime = (currentTime + 1) % 3;
        if (currentTime == 0)
        {
            this.GetComponent<Renderer>().material.mainTexture = nine;

        }
        else if (currentTime == 1)
        {
            this.GetComponent<Renderer>().material.mainTexture = twelve;

        }
        else if (currentTime == 2)
        {
            this.GetComponent<Renderer>().material.mainTexture = five;

        }
    }
}
