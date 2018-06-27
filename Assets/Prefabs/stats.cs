using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

	public bool perfect = false;
	public bool sliearly = false; 
	public bool slilate = false; 
	public bool verylate = false; 


	public bool clicked = false;
	public bool entered = false;
	public bool exit = false;
	public bool longNote = false;
	public int index = 0;

	// Use this for initialization
	void Start () {
		longNote = this.gameObject.GetComponentInParent<NoteLongControl>().islong;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
