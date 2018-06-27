using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ChartLoader.NET.Framework;

public class Notelist : MonoBehaviour {

	public int length =0;
	public Note[] listofnotes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (listofnotes!=null)
		length = listofnotes.Length;
	}
}
