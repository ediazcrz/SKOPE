using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunControl : MonoBehaviour {

	// Use this for initialization\
	Vector3 spring9AM;
	Vector3 spring12PM;
	Vector3 spring5PM;
	Vector3 summer9AM;
	Vector3 summer12PM;
	Vector3 summer5PM;
	Vector3 fall9AM;
	Vector3 fall12PM;
	Vector3 fall5PM;
	Vector3 winter9AM;
	Vector3 winter12PM;
	Vector3 winter5PM;
	void Start () {
		spring9AM = new Vector3(37.525f, -236.17f, -2.97f);
		spring12PM = new Vector3(60.4f,-182.193f,52.568f);
		spring5PM = new Vector3(40.943f,-113.217f,110.005f);
		summer9AM = new Vector3(23.059f,-279.612f,-468.668f);
		summer12PM = new Vector3(86.86f,-171.341f,-378.418f);
		summer5PM = new Vector3(40.943f,-113.217f,110.005f);
		fall9AM = new Vector3(29.255f, -243.709f,-452.389f);
		fall12PM = new Vector3(53.611f, -174.982f, 0f);
		fall5PM = new Vector3(42.436f, -123.731f, 33.04f);
		winter9AM = new Vector3(19.482f,-214.77f,-5.88f);
		winter12PM = new Vector3(38.7f, -175f, 7f);
		winter5PM = new Vector3(20.5f,-136.7f,12.099f);
		
	}
	// Update is called once per frame
	void Update () {
	}
	public void ChangeSun(int i){
		if (i == 0) {
			this.transform.eulerAngles = spring9AM;
		}else if(i ==1){
			this.transform.eulerAngles = (spring12PM);
			
		}else if(i ==2){
			this.transform.eulerAngles = (spring5PM);

		}else if(i ==3){
			this.transform.eulerAngles = (summer9AM);

		}else if(i ==4){
			this.transform.eulerAngles = (summer12PM);

		}else if(i ==5){
			this.transform.eulerAngles = (summer5PM);

		}else if(i ==6){
			this.transform.eulerAngles = (fall9AM);

		}else if(i ==7){
			this.transform.eulerAngles = (fall12PM);

		}else if(i ==8){
			this.transform.eulerAngles = (fall5PM);

		}else if(i ==9){
			this.transform.eulerAngles = (winter9AM);

		}else if(i ==10){
			this.transform.eulerAngles = (winter12PM);

		}else if(i ==11){
			this.transform.eulerAngles = (winter5PM);

		}
	
	}
}
