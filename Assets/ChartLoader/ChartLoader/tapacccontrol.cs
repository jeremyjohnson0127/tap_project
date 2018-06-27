using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapacccontrol : MonoBehaviour {

	public GameObject missed;
	public GameObject perfect;
	public GameObject searly;
	public GameObject slate;
	public GameObject vearely;
	public GameObject vlate;

	// Use this for initialization
	void Start () {
	ClearAll();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void set(string var)
	{
		ClearAll();
		if (var.Contains("perfect"))
		{
			perfect.SetActive(true);
		}
	
		if (var.Contains("miss"))
		{
			missed.SetActive(true);
		}
	
		if (var.Contains("veryearly"))
		{
			vearely.SetActive(true);
		}

		if (var.Contains("verylate"))
		{
			vlate.SetActive(true);
		}

		if (var.Contains("slisearly"))
		{
			searly.SetActive(true);
		}

		if (var.Contains("slilate"))
		{
			slate.SetActive(true);
		}

	}
	public void ClearAll()
	{
		missed.SetActive(false);
		perfect.SetActive(false);
		searly.SetActive(false);
		slate.SetActive(false);
		vearely.SetActive(false);
		vlate.SetActive(false);
	}
}

