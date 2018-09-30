using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour
{

    public Text coordinates;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        coordinates.text = "Latitude:" + GPS.Instance.latitude.ToString() +
            "   \nLongitude:" + GPS.Instance.longitude.ToString();// +
            //"   \nAltitude:" + GPS.Instance.altitude.ToString();
    }
}
