using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{

    public static GPS Instance { set; get; }            // Makes it a property

    public float latitude;
    public float longitude;
    //public float altitude;

    // Use this for initialization
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);                  // Just in case you change scenes
        StartCoroutine(StartLocationService());         // Send request for your phone to use GPS //Parallel action
    }

    private IEnumerator StartLocationService()          // Colections
    {
        while (true)
        {
            if (!Input.location.isEnabledByUser)
            {
                Debug.Log("User has not enabled GPS");
                yield break;                                // ends the coroutine                          
            }

            Input.location.Start(1f, .1f);

            int maxWait = 20;

            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);            // while loop will be called 20 times
                maxWait--;
            }

            if (maxWait <= 0)
            {
                Debug.Log("Timed out");
                yield break;
            }

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determine device location");
                yield break;
            }

            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            //altitude = Input.location.lastData.altitude;

            //yield break;
        }
        //Input.location.Stop();
    }
}

