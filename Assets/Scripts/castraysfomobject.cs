using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castraysfomobject : MonoBehaviour {

	public bool perfect;
	public bool enter;
	public bool exit;
	public bool center;
	public bool sliearly;
	public bool slilate;
	public bool verylate;

	public bool green;
	public bool blue;
	public bool red;
	public GameObject baseboard;
	public GameObject aux1;
	public GameObject aux2;
	public GameObject aux3;


	// Use this for initialization
	void Start () {
		
	}
	void Update()
	{

		if (Globalvars.redclicks < 0)
			Globalvars.redclicks = 0;

		if (Globalvars.blueclicks < 0)
			Globalvars.blueclicks = 0;

		if (Globalvars.greenclicks < 0)
			Globalvars.greenclicks = 0;
		
		Update2();

	}
	// Update is called once per frame

	void Update2 () {


		RaycastHit objectHit;
		Vector3 fwd = this.transform.TransformDirection(Vector3.up);
		Debug.DrawRay(this.transform.position, fwd * 50, Color.green);

		if (Physics.Raycast(this.transform.position, fwd, out objectHit, 50))
		{
            //Debug.Log(objectHit.transform.name);
            // Rayo de entrada
            if (objectHit.transform.gameObject.gameObject.GetComponent<stats>() != null)
            {
                stats stat = objectHit.transform.gameObject.gameObject.GetComponent<stats>();

                if ((sliearly) && (stat.sliearly == false))
                {
                    stat.sliearly = true;
                }

                if ((slilate) && (stat.slilate == false))
                {
                    stat.slilate = true;
                }

                if ((verylate) && (stat.verylate == false))
                {
                    stat.verylate = true;
                }


                if ((enter) && (stat.entered == false))
                {
                    objectHit.transform.gameObject.gameObject.GetComponent<stats>().entered = true;
                    if (red)
                    {
                        if (Globalvars.aux1 == null)
                        {
                            Globalvars.aux1 = objectHit.transform.gameObject;
                        }
                        else if (Globalvars.aux2 == null)
                        {
                            Globalvars.aux2 = objectHit.transform.gameObject;
                        }
                        else if (Globalvars.aux3 == null)
                        {
                            Globalvars.aux3 = objectHit.transform.gameObject;
                        }

                        else if ((Globalvars.aux1 != null) && (Globalvars.aux1.gameObject.gameObject.GetComponent<stats>().clicked))
                        {
                            Globalvars.aux1 = objectHit.transform.gameObject;
                        }

                        else if ((Globalvars.aux2 != null) && (Globalvars.aux2.gameObject.gameObject.GetComponent<stats>().clicked))
                        {
                            Globalvars.aux2 = objectHit.transform.gameObject;
                        }

                        else if ((Globalvars.aux3 != null) && (Globalvars.aux3.gameObject.gameObject.GetComponent<stats>().clicked))
                        {
                            Globalvars.aux3 = objectHit.transform.gameObject;
                        }

                        else
                        {
                        }
                    }
                    if (green)
                    {
                        if (Globalvars.aux1green == null)
                        {
                            Globalvars.aux1green = objectHit.transform.gameObject;
                        }
                        else if (Globalvars.aux2green == null)
                        {
                            Globalvars.aux2green = objectHit.transform.gameObject;
                        }
                        else if (Globalvars.aux3green == null)
                        {
                            Globalvars.aux3green = objectHit.transform.gameObject;
                        }

                        else if ((Globalvars.aux2green != null) && (Globalvars.aux2green.gameObject.gameObject.GetComponent<stats>().clicked))
                        {
                            Globalvars.aux2green = objectHit.transform.gameObject;
                        }

                        else if ((Globalvars.aux2green != null) && (Globalvars.aux2green.gameObject.gameObject.GetComponent<stats>().clicked))
                        {
                            Globalvars.aux2green = objectHit.transform.gameObject;
                        }

                        else if ((Globalvars.aux3green != null) && (Globalvars.aux3green.gameObject.gameObject.GetComponent<stats>().clicked))
                        {
                            Globalvars.aux3green = objectHit.transform.gameObject;
                        }

                        else
                        {
                        }
                    }
                    if (blue)
                    {
                        if (Globalvars.aux1blue == null)
                        {
                            Globalvars.aux1blue = objectHit.transform.gameObject;
                        }
                        else if (Globalvars.aux2blue == null)
                        {
                            Globalvars.aux2blue = objectHit.transform.gameObject;
                        }
                        else if (Globalvars.aux3blue == null)
                        {
                            Globalvars.aux3blue = objectHit.transform.gameObject;
                        }

                        else if ((Globalvars.aux1blue != null) && (Globalvars.aux1blue.gameObject.gameObject.GetComponent<stats>().clicked))
                        {
                            Globalvars.aux1blue = objectHit.transform.gameObject;
                        }

                        else if ((Globalvars.aux2blue != null) && (Globalvars.aux2blue.gameObject.gameObject.GetComponent<stats>().clicked))
                        {
                            Globalvars.aux2blue = objectHit.transform.gameObject;
                        }

                        else if ((Globalvars.aux3blue != null) && (Globalvars.aux3blue.gameObject.gameObject.GetComponent<stats>().clicked))
                        {
                            Globalvars.aux3blue = objectHit.transform.gameObject;
                        }

                        else
                        {
                        }
                    }




                }
                if ((perfect) && (!stat.perfect))
                {
                    if ((green) || (blue) || (red))
                    {
                        stat.perfect = true;
                    }
                }

                if ((!enter) && (!exit) && (stat.longNote))
                {
                    Debug.Log("Long note to be clicked");

                    if (green)
                    {
                        Globalvars.longgreen = objectHit.transform.gameObject.gameObject.GetComponent<stats>().longNote;
                    }

                    if (blue)
                    {
                        Globalvars.longblue = objectHit.transform.gameObject.gameObject.GetComponent<stats>().longNote;

                    }
                    if (red)
                    {
                        Globalvars.longred = objectHit.transform.gameObject.gameObject.GetComponent<stats>().longNote;

                    }

                    /*
                    if ((Globalvars.greenpressed) && (green))
                    {
                        Debug.Log("correct green");
                        GameObject.Find("BoardG").GetComponent<ColorControl>().color = Color.green;
                        GameObject.Find("BoardG").GetComponent<ColorControl>().timer = 1f;


                    }
                    if ((!Globalvars.greenpressed) && (green))
                    {
                        GameObject.Find("BoardG").GetComponent<ColorControl>().color = Color.red;
                        GameObject.Find("BoardG").GetComponent<ColorControl>().timer = 1f;


                        //Debug.Log("fallo green");
                    }

                    if ((Globalvars.bluepressed) && (blue))
                    {
                        GameObject.Find("BoardB").GetComponent<ColorControl>().color = Color.green;
                        GameObject.Find("BoardB").GetComponent<ColorControl>().timer = 1f;
                        Debug.Log("correct blue");
                    }
                    if ((!Globalvars.bluepressed) && (blue))
                    {
                        GameObject.Find("BoardB").GetComponent<ColorControl>().color = Color.red;
                        GameObject.Find("BoardB").GetComponent<ColorControl>().timer = 1f;
                        //Debug.Log("fallo blue");
                    }

                    if ((Globalvars.redpressed) && (red))
                    {
                        GameObject.Find("BoardR").GetComponent<ColorControl>().color = Color.green;
                        GameObject.Find("BoardR").GetComponent<ColorControl>().timer = 1f;
                        Debug.Log("correct red");
                    }
                    if ((!Globalvars.redpressed) && (red))
                    {
                        //Debug.Log("fallo red");
                        GameObject.Find("BoardR").GetComponent<ColorControl>().color = Color.red;
                        GameObject.Find("BoardR").GetComponent<ColorControl>().timer = 1f;
                    }

                        */
                }


                // Rayo de salida
                if ((exit) && (stat.exit == false))
                {
                    objectHit.transform.gameObject.gameObject.GetComponent<stats>().exit = true;
                    if (green)
                    {

                        if (!objectHit.transform.gameObject.gameObject.GetComponent<stats>().clicked)
                        {
                            //Debug.Log(Globalvars.redclicks + " missed");

                            //Debug.Log("missed note");
                            Globalvars.missednotes = Globalvars.missednotes + 1;
                            Globalvars.streakcounter = 0;
                            Scoring("miss");
                            Globalvars.greenclicks = Globalvars.greenclicks - 1;

                        }

                    }

                    if (blue)
                    {

                        if (!objectHit.transform.gameObject.gameObject.GetComponent<stats>().clicked)
                        {
                            //Debug.Log(Globalvars.redclicks + " missed");

                            //Debug.Log("missed note");
                            Globalvars.missednotes = Globalvars.missednotes + 1;
                            Globalvars.streakcounter = 0;
                            Scoring("miss");
                            Globalvars.blueclicks = Globalvars.blueclicks - 1;

                        }


                    }

                    if (red)
                    {

                        if (!objectHit.transform.gameObject.gameObject.GetComponent<stats>().clicked)
                        {
                            //Debug.Log(Globalvars.redclicks + " missed");

                            //Debug.Log("missed note");
                            Globalvars.missednotes = Globalvars.missednotes + 1;
                            Globalvars.streakcounter = 0;
                            Scoring("miss");
                            Globalvars.redclicks = Globalvars.redclicks - 1;

                        }

                    }



                }

            }

		}

	
	}

		public void Scoring(string caseofscore)
	{

		int perfect = 0;
		int good = 0;
		int bad = 0;
		int miss = -75;

		if ((Globalvars.streakcounter > 0) && (Globalvars.streakcounter < 50))
		{
			perfect = 100;
			good = 50;
			bad = 25;
			miss = -75;
		}

		if ((Globalvars.streakcounter > 49) && (Globalvars.streakcounter < 100))
		{
			perfect = 200;
			good = 100;
			bad = 50;
			miss = -75;
		}
		if ((Globalvars.streakcounter > 99) && (Globalvars.streakcounter < 150))
		{
			perfect = 400;
			good = 200;
			bad = 100;
			miss = -75;
		}
		if ((Globalvars.streakcounter > 149) && (Globalvars.streakcounter < 200))
		{
			perfect = 800;
			good = 400;
			bad = 200;
			miss = -75;
		}

		if ((Globalvars.streakcounter > 199))
		{
			perfect = 1600;
			good = 800;
			bad = 400;
			miss = -75;
		}

		if (caseofscore == "perfect")
		{
			Globalvars.score = Globalvars.score + perfect;
		}
		if (caseofscore == "good")
		{
			Globalvars.score = Globalvars.score + good;

		}
		if (caseofscore == "bad")
		{

			Globalvars.score = Globalvars.score + bad;

		}
		if (caseofscore == "miss")
		{
			Debug.Log("miss");
			Globalvars.score = Globalvars.score + miss;
		}

	}


}
