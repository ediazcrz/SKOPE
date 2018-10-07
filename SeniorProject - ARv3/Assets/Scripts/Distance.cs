using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour {

    //public Text dist;
    public double distance1;
    public static Distance Instance { set; get; }

    public float x1;
    public float y1;
    public float x2;
    public float y2;

    public float dist2;

    // Use this for initialization
    void Start () {
        Instance = this;
        x1 = GPS.Instance.latitude;
        y1 = GPS.Instance.longitude;
        x2 = 25.75698556f;
        y2 = -80.3766838f;
        //x2 = 26.2414147f;
        //y2 = -80.2513379f;
    }

    public float Calc(float lat1, float lon1, float lat2, float lon2)
    {

        var R = 6378.137; // Radius of earth in KM
        var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
          Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
          Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        distance1 = R * c;
        distance1 = distance1 * 1000f; // meters
                                     //set the distance text on the canvas

        float distanceFloat = (float)distance1;

        return distanceFloat;
    }

    // Update is called once per frame
    void Update () {
            x1 = GPS.Instance.latitude;
            y1 = GPS.Instance.longitude;
            dist2 = Calc(x1, y1, x2, y2);
            //dist.text = "Distance: " + dist2.ToString();
    }
}
