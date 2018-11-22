using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanel : MonoBehaviour {

    GameObject Map;
    GameObject MapCursor;

	// Use this for initialization
	void Start () {
        Map = transform.GetChild(0).gameObject;
        MapCursor = transform.GetChild(1).gameObject;
	}
	
    public void updateCursor(float x, float y)
    {
        MapCursor.transform.localPosition = new Vector3((-10f - x) / 318, -1, (21.3f + y) / 318);
    }

    public void disableCursor()
    {

    }
    private void Update()
    {
        updateCursor(this.transform.position.x, this.transform.position.z);
    }
}
