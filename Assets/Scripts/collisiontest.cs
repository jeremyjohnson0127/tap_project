using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisiontest : MonoBehaviour {



	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log(Globalvars.control1col + "  " + Globalvars.control2col + "  " + Globalvars.control3col);
	}




	void OnCollisionEnter(Collision collision)	{

		//Debug.Log("colision enter" + collision.other.name);
		/*
		if ((collision.other.name.Contains("Cube1")) && (!Globalvars.pressgreen) )
		{
		//	Debug.Log("colision enter" + collision.other.name);

			Globalvars.pressgreen = true;
			Globalvars.indicator1.SetActive(true);
			Globalvars.control1col = Globalvars.control1col + 1;

		}

		if ((collision.other.name.Contains("Cube2")) && (!Globalvars.pressgreen))
		{
		//	Debug.Log("colision enter" + collision.other.name);

			Globalvars.pressblue = true;
			Globalvars.indicator2.SetActive(true);
			Globalvars.control2col = Globalvars.control2col + 1;


		}


		if ((collision.other.name.Contains("Cube3")) && (!Globalvars.pressgreen))
		{

			Globalvars.pressred = true;
			Globalvars.indicator3.SetActive(true);
			Globalvars.control3col = Globalvars.control3col + 1;

		}

		*/
		if (collision.other.name.Contains("ERASER"))
		{
			//Debug.Log(this.transform.name);
			Globalvars.numberofnotes = Globalvars.numberofnotes - 1;
			Globalvars.numberofnotesplayed = Globalvars.numberofnotesplayed + 1;
			GameObject.Destroy( this.transform.parent.gameObject );

		}
	}
	/*
	void OnCollisionExit(Collision collision)
	{
		//Debug.Log("colision exit" + collision.other.name);
	//	if (collision.other.name.Contains("Cube")) 
			//Debug.Log("colision exit" + collision.other.name);


		if ((collision.other.name.Contains("Cube1")) && (Globalvars.pressgreen))
		{
			//Debug.Log("colision exit" + collision.other.name);
			Globalvars.pressgreen = false;
			Globalvars.indicator1.SetActive(false);
			Globalvars.control1col = Globalvars.control1col - 1;

		}

		if ((collision.other.name.Contains("Cube2")) && (Globalvars.pressblue))
		{
			//Debug.Log("colision exit" + collision.other.name);
			Globalvars.pressblue = false;
			Globalvars.indicator2.SetActive(false);
			Globalvars.control2col = Globalvars.control2col - 1;

		}


		if ((collision.other.name.Contains("Cube3")) && (Globalvars.pressred))
		{
			//Debug.Log("colision exit" + collision.other.name);
			Globalvars.pressred = false;
			Globalvars.indicator3.SetActive(false);
			Globalvars.control3col = Globalvars.control3col - 1;

		}




	
	}

*/

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("trigger enter " + other.name);
	}

	void OnTriggerExit(Collider other)
	{
		// Destroy everything that leaves the trigger
		//Debug.Log("trigger ends");
	}
}
