using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slidercontrolanes : MonoBehaviour {

	public GameObject slider;

	public GameObject ref1, ref2, ref3, ref4;
	private GameObject Cam;

	GameObject lane1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeAngle( )
	{
		Debug.Log(slider.GetComponent<Slider>().value);
		float val = slider.GetComponent<Slider>().value;

		if (val<0.25f)
		{
			ref1.SetActive(true);
			ref2.SetActive(false);
			ref3.SetActive(false);
			ref4.SetActive(false);

			/*
			Cam.transform.localPosition = new Vector3(ref1.transform.position.x, ref1.transform.position.y, ref3.transform.position.z);		
			Cam.transform.eulerAngles = new Vector3 (ref1.transform.eulerAngles.x , 
			                                     ref1.transform.eulerAngles.y , 
			                                     ref1.transform.eulerAngles.z);*/
		}

		if ((val>=0.25f) &&  (val<0.5f))
		{

			ref1.SetActive(false);
			ref2.SetActive(true);
			ref3.SetActive(false);
			ref4.SetActive(false);
			/*
			Cam.transform.localPosition = new Vector3(ref2.transform.position.x, ref2.transform.position.y, ref2.transform.position.z);
			Cam.transform.eulerAngles = new Vector3(ref2.transform.eulerAngles.x,
			                                        ref2.transform.eulerAngles.y,
			                                        ref2.transform.eulerAngles.z);*/
		}

		if ((val>=0.5f) &&  (val<0.75f))
		{
			ref1.SetActive(false);
			ref2.SetActive(false);
			ref3.SetActive(true);
			ref4.SetActive(false);
			/*
			Cam.transform.localPosition = new Vector3(ref3.transform.position.x, ref3.transform.position.y, ref3.transform.position.z);
			Cam.transform.eulerAngles = new Vector3(ref3.transform.eulerAngles.x,
			                                        ref3.transform.eulerAngles.y,
			                                        ref3.transform.eulerAngles.z);*/
		}

		if (val>=0.75f)
		{
			ref1.SetActive(false);
			ref2.SetActive(false);
			ref3.SetActive(false);
			ref4.SetActive(true);

			/*
			Cam.transform.localPosition = new Vector3(ref4.transform.position.x, ref4.transform.position.y, ref4.transform.position.z);
			Cam.transform.eulerAngles = new Vector3(ref4.transform.eulerAngles.x,
			                                        ref4.transform.eulerAngles.y,
			                                        ref4.transform.eulerAngles.z);*/

		}


	}
}
