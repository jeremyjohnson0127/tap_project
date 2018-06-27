using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour {

	public GameObject  dif1;
	public GameObject  dif2;
	public GameObject  dif3;


	public GameObject song1;
	public GameObject song2;



	// Use this for initialization
	void Start () 
	{
		
	}


	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SelectSpeed(int selector)
	{
		if (selector == 1)
		{
			//dif1.gameObject.GetComponent<Toggle>().isOn = true;
			dif2.gameObject.GetComponent<Toggle>().isOn = false;
			dif3.gameObject.GetComponent<Toggle>().isOn = false;
			Globalvars.speed = 5;

		}

		if (selector == 2)
		{
			dif1.gameObject.GetComponent<Toggle>().isOn = false;
			dif3.gameObject.GetComponent<Toggle>().isOn = false;
			Globalvars.speed = 10;
		}

		if (selector == 3)
		{
			dif1.gameObject.GetComponent<Toggle>().isOn = false;
			dif2.gameObject.GetComponent<Toggle>().isOn = false;
			Globalvars.speed = 16;


		}
	}

	public void PlayBtn()
	{
		Application.LoadLevel("GameArea");
	}
}
