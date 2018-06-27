using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControl : MonoBehaviour {

	public float timer = 3f;
	public Color color = Color.grey;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0)
		{
			timer = timer - Time.deltaTime;
			this.gameObject.GetComponent<SpriteRenderer>().color = color;

		}
		else
		{
			this.GetComponent<SpriteRenderer>().color = Color.grey;
			timer = 0;
		}
	}
}
