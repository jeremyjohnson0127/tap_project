using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class XplorerGuitarInput : MonoBehaviour
{
	public GameObject tapacc;
	public GameObject indicator1;
	public GameObject indicator2;
	public GameObject indicator3;
	public GameObject base1;
	public GameObject base2;
	public GameObject base3;

	public Material base1normal;
	public Material base1OK;
	public Material base1BAD;

    public bool DebugController = false;

    public int A;
    public int B;
    public int X;
    public int Y;
    public int START;
    public int SELECT;
    public int DPadLeft = 0;
    public int DPadRight = 0;
    public int DPadUp = 0;
    public int DPadDown = 0;
    public int rightShoulder;
    public int leftShoulder;
    public int strum = 0;

    public bool green;
    public bool red;
    public bool yellow;
    public bool blue;
    public bool orange;

	public string finger1;
	public string finger2;
	public string finger3;
	public string finger4;



	void Start()
	{
		Globalvars.indicator1 = indicator1;
		Globalvars.indicator2 = indicator2;
		Globalvars.indicator3 = indicator3;


	}
    // Update is called once per frame
    void Update()
    {
		//  GetControllerInput();

		if (Input.GetKeyDown(KeyCode.A))
			Click("Cube1");
		if (Input.GetKeyDown(KeyCode.S))
			Click("Cube2");
		if (Input.GetKeyDown(KeyCode.D))
			Click("Cube3");


		if (Input.GetKey(KeyCode.A))
			Hold("Cube1");
		if (Input.GetKey(KeyCode.S))
			Hold("Cube2");
		if (Input.GetKey(KeyCode.D))
			Hold("Cube3");


		if (Input.GetKeyUp(KeyCode.A))
			HoldOut("Cube1");
		if (Input.GetKeyUp(KeyCode.S))
			HoldOut("Cube2");
		if (Input.GetKeyUp(KeyCode.D))
			HoldOut("Cube3");
		
		RayCastControl();

    }

	public void BackToMenu()
	{
        Modules.gameState = GameState.PostGame;
        Modules.SaveGameState();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


	void RayCastControl()
	{
		int layerMask = 1 << 8;
		foreach (Touch touch in Input.touches)
		{

			Debug.Log(touch.phase+" "+touch.fingerId);
			//Do something with the touches

			if (touch.phase == TouchPhase.Began )
			{
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit;

				if (touch.phase == TouchPhase.Began)
				{
					
					ray = Camera.main.ScreenPointToRay(touch.position);
					if (Physics.Raycast(ray, out hit, 100f,layerMask))
					{
						Click(hit.collider.gameObject.name);
						if (touch.fingerId == 0)
							finger1 = hit.collider.gameObject.name;
						if (touch.fingerId == 1)
							finger2 = hit.collider.gameObject.name;
						if (touch.fingerId == 2)
							finger3 = hit.collider.gameObject.name;
						if (touch.fingerId == 3)
							finger4 = hit.collider.gameObject.name;
						
						//Debug.Log(hit.collider.gameObject.name);
					}
				}

			
				if (touch.phase == TouchPhase.Stationary)
				{
					/*
					if (touch.fingerId == 0)
						Click(finger1);
					if (touch.fingerId == 1)
						Click(finger2);
					if (touch.fingerId == 2)
						Click(finger3);
					if (touch.fingerId == 3)
						Click(finger4);
					*/
				}
			}

		}

	}

	void HoldOut(string name)
	{

		//Debug.Log("hold " + name);
		if (name.Equals("Cube1"))
		{
			Globalvars.greenpressed = false;
		}
		if (name.Equals("Cube2"))
		{
			Globalvars.bluepressed = false;
		}
		if (name.Equals("Cube3"))
		{
			Globalvars.redpressed = false;
		}

	}

	void Hold(string name)
	{

		//Debug.Log("hold " + name);
		if (name.Equals("Cube1"))
		{
			Globalvars.greenpressed = true;
		}
		if (name.Equals("Cube2"))
		{
			Globalvars.bluepressed = true;
		}
		if (name.Equals("Cube3"))
		{
			Globalvars.redpressed = true;
		}

	}


	void Click(string name)
	{
	//	Debug.Log("click "+name);

		if (name.Equals("Cube1"))
		{
			//Debug.Log("test ");
			GameObject.Find("GreenBtn").GetComponent<matcontrol>().effect.SetActive(false);
			GameObject.Find("GreenBtn").GetComponent<matcontrol>().effect.SetActive(true);
			if ((Globalvars.aux1green != null) && (!Globalvars.aux1green.GetComponent<stats>().clicked) 
			    )
			{

				Globalvars.aux1green.GetComponent<stats>().clicked = true;
				//GameObject.Find("BoardG").GetComponent<ColorControl>().color = Color.green;
				GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().good;

				if (!Globalvars.aux1green.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else 
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;


				if ((Globalvars.aux1green.GetComponent<stats>().entered) && (!Globalvars.aux1green.GetComponent<stats>().sliearly))
				{
					Scoring("veryearly");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().bad;

				}
				if ((Globalvars.aux1green.GetComponent<stats>().sliearly) && (!Globalvars.aux1green.GetComponent<stats>().perfect))
				{
					Scoring("slisearly");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;
				}
				if ((Globalvars.aux1green.GetComponent<stats>().perfect) && (!Globalvars.aux1green.GetComponent<stats>().slilate))
				{
					Scoring("perfect");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().perfect;

				}
				if ((Globalvars.aux1green.GetComponent<stats>().slilate) && (!Globalvars.aux1green.GetComponent<stats>().verylate))
				{
					Scoring("slilate");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;

				}
				if ((Globalvars.aux1green.GetComponent<stats>().verylate))
				{
					Scoring("verylate");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().bad;

				}



				Globalvars.streakcounter = Globalvars.streakcounter + 1;
				//GameObject.Find("BoardG").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("GreenBtn").GetComponent<matcontrol>().timer = 1f;


			}
			else if ((Globalvars.aux2green != null) && (!Globalvars.aux2green.GetComponent<stats>().clicked)
			        )
			{
				Globalvars.aux2green.GetComponent<stats>().clicked = true;
				//GameObject.Find("BoardG").GetComponent<ColorControl>().color = Color.green;
				GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().good;

				if (!Globalvars.aux2green.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;


				if ((Globalvars.aux2green.GetComponent<stats>().entered) && (!Globalvars.aux2green.GetComponent<stats>().sliearly))
				{
					Scoring("veryearly");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().bad;

				}
				if ((Globalvars.aux2green.GetComponent<stats>().sliearly) && (!Globalvars.aux2green.GetComponent<stats>().perfect))
				{
					Scoring("slisearly");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;

				}
				if ((Globalvars.aux2green.GetComponent<stats>().perfect) && (!Globalvars.aux2green.GetComponent<stats>().slilate))
				{
					Scoring("perfect");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().perfect;

				}
				if ((Globalvars.aux2green.GetComponent<stats>().slilate) && (!Globalvars.aux2green.GetComponent<stats>().verylate))
				{
					Scoring("slilate");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;

				}
				if ((Globalvars.aux2green.GetComponent<stats>().verylate))
				{
					Scoring("verylate");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().bad;

				}





				Globalvars.streakcounter = Globalvars.streakcounter + 1;
				//GameObject.Find("BoardG").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("GreenBtn").GetComponent<matcontrol>().timer = 1f;

			}
			else if ((Globalvars.aux3green != null) && (!Globalvars.aux3green.GetComponent<stats>().clicked)
			        )
			{
				Globalvars.aux3green.GetComponent<stats>().clicked = true;
				//GameObject.Find("BoardG").GetComponent<ColorControl>().color = Color.green;
				GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().good;


				if (!Globalvars.aux3green.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;

				if ((Globalvars.aux3green.GetComponent<stats>().entered) && (!Globalvars.aux3green.GetComponent<stats>().sliearly))
				{
					Scoring("veryearly");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().bad;

				}
				if ((Globalvars.aux3green.GetComponent<stats>().sliearly) && (!Globalvars.aux3green.GetComponent<stats>().perfect))
				{
					Scoring("slisearly");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;

				}
				if ((Globalvars.aux3green.GetComponent<stats>().perfect) && (!Globalvars.aux3green.GetComponent<stats>().slilate))
				{
					Scoring("perfect");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().perfect;

				}
				if ((Globalvars.aux3green.GetComponent<stats>().slilate) && (!Globalvars.aux3green.GetComponent<stats>().verylate))
				{
					Scoring("slilate");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;

				}
				if ((Globalvars.aux3green.GetComponent<stats>().verylate))
				{
					Scoring("verylate");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().bad;

				}




				Globalvars.streakcounter = Globalvars.streakcounter + 1;
				//GameObject.Find("BoardG").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("GreenBtn").GetComponent<matcontrol>().timer = 1f;

			}
			else
			{
				Debug.Log(Globalvars.redclicks + " click error");
				//GameObject.Find("BoardG").GetComponent<ColorControl>().color = Color.red;
				GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().miss;

				Globalvars.incorrectnotes = Globalvars.incorrectnotes + 1;
				Scoring("bad");
				Globalvars.streakcounter = 0;
				//GameObject.Find("BoardG").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("GreenBtn").GetComponent<matcontrol>().timer = 1f;

			}



		}

		else if (name.Equals("Cube2"))
		{
			GameObject.Find("BlueBtn").GetComponent<matcontrol>().effect.SetActive(false);
			GameObject.Find("BlueBtn").GetComponent<matcontrol>().effect.SetActive(true);
			//Debug.Log("test ");
			if ((Globalvars.aux1blue != null) && (!Globalvars.aux1blue.GetComponent<stats>().clicked) 
			   )
			{

				Globalvars.aux1blue.GetComponent<stats>().clicked = true;
				//GameObject.Find("BoardB").GetComponent<ColorControl>().color = Color.green;
				GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().good;


				if (!Globalvars.aux1blue.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;

				if ((Globalvars.aux1blue.GetComponent<stats>().entered) && (!Globalvars.aux1blue.GetComponent<stats>().sliearly))
				{
					Scoring("veryearly");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().bad;

				}
				if ((Globalvars.aux1blue.GetComponent<stats>().sliearly) && (!Globalvars.aux1blue.GetComponent<stats>().perfect))
				{
					Scoring("slisearly");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().good;

				}
				if ((Globalvars.aux1blue.GetComponent<stats>().perfect) && (!Globalvars.aux1blue.GetComponent<stats>().slilate))
				{
					Scoring("perfect");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().perfect;
				}
				if ((Globalvars.aux1blue.GetComponent<stats>().slilate) && (!Globalvars.aux1blue.GetComponent<stats>().verylate))
				{
					Scoring("slilate");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().good;
				}
				if ((Globalvars.aux1blue.GetComponent<stats>().verylate))
				{
					Scoring("verylate");
					GameObject.Find("GreenBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("GreenBtn").GetComponent<matcontrol>().bad;

				}

				Globalvars.streakcounter = Globalvars.streakcounter + 1;
				//GameObject.Find("BoardB").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("BlueBtn").GetComponent<matcontrol>().timer = 1f;
			}
			else if ((Globalvars.aux2blue != null) && (!Globalvars.aux2blue.GetComponent<stats>().clicked)
			        )
			{
				Globalvars.aux2blue.GetComponent<stats>().clicked = true;
				//GameObject.Find("BoardB").GetComponent<ColorControl>().color = Color.green;
				GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().good;

				if (!Globalvars.aux2blue.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;

				if ((Globalvars.aux2blue.GetComponent<stats>().entered) && (!Globalvars.aux2blue.GetComponent<stats>().sliearly))
				{
					Scoring("veryearly");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().bad;

				}
				if ((Globalvars.aux2blue.GetComponent<stats>().sliearly) && (!Globalvars.aux2blue.GetComponent<stats>().perfect))
				{
					Scoring("slisearly");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().good;
				}
				if ((Globalvars.aux2blue.GetComponent<stats>().perfect) && (!Globalvars.aux2blue.GetComponent<stats>().slilate))
				{
					Scoring("perfect");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().perfect;
				}
				if ((Globalvars.aux2blue.GetComponent<stats>().slilate) && (!Globalvars.aux2blue.GetComponent<stats>().verylate))
				{
					Scoring("slilate");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().good;
				}
				if ((Globalvars.aux2blue.GetComponent<stats>().verylate))
				{
					Scoring("verylate");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().bad;

				}



				Globalvars.streakcounter = Globalvars.streakcounter + 1;
				//GameObject.Find("BoardB").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("BlueBtn").GetComponent<matcontrol>().timer = 1f;
			}
			else if ((Globalvars.aux3blue != null) && (!Globalvars.aux3blue.GetComponent<stats>().clicked)
			        )
			{
				Globalvars.aux3blue.GetComponent<stats>().clicked = true;
				//GameObject.Find("BoardB").GetComponent<ColorControl>().color = Color.green;
				GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().good;


				if (!Globalvars.aux3blue.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;

				if ((Globalvars.aux3blue.GetComponent<stats>().entered) && (!Globalvars.aux3blue.GetComponent<stats>().sliearly))
				{
					Scoring("veryearly");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().bad;

				}
				if ((Globalvars.aux3blue.GetComponent<stats>().sliearly) && (!Globalvars.aux3blue.GetComponent<stats>().perfect))
				{
					Scoring("slisearly");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().good;
				}
				if ((Globalvars.aux3blue.GetComponent<stats>().perfect) && (!Globalvars.aux3blue.GetComponent<stats>().slilate))
				{
					Scoring("perfect");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().perfect;
				}
				if ((Globalvars.aux3blue.GetComponent<stats>().slilate) && (!Globalvars.aux3blue.GetComponent<stats>().verylate))
				{
					Scoring("slilate");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().good;
				}
				if ((Globalvars.aux3blue.GetComponent<stats>().verylate))
				{
					Scoring("verylate");
					GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().bad;

				}
				
				Globalvars.streakcounter = Globalvars.streakcounter + 1;
				//GameObject.Find("BoardB").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("BlueBtn").GetComponent<matcontrol>().timer = 1f;
			}
			else
			{
				Debug.Log(Globalvars.redclicks + " click error");
				GameObject.Find("BoardB").GetComponent<ColorControl>().color = Color.red;
				GameObject.Find("BlueBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("BlueBtn").GetComponent<matcontrol>().miss;

				Globalvars.incorrectnotes = Globalvars.incorrectnotes + 1;
				Scoring("bad");
				Globalvars.streakcounter = 0;
				//GameObject.Find("BoardB").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("BlueBtn").GetComponent<matcontrol>().timer = 1f;

			}

		}

		else if (name.Equals("Cube3"))
		{
			GameObject.Find("RedBtn").GetComponent<matcontrol>().effect.SetActive(false);
			GameObject.Find("RedBtn").GetComponent<matcontrol>().effect.SetActive(true);
			//	Debug.Log("test ");
			if( (Globalvars.aux1!=null)&& (!Globalvars.aux1.GetComponent<stats>().clicked)
			  )
			{
				
				Globalvars.aux1.GetComponent<stats>().clicked = true;
				//GameObject.Find("BoardR").GetComponent<ColorControl>().color = Color.green;
				GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;

				if (!Globalvars.aux1.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;



				if ((Globalvars.aux1.GetComponent<stats>().entered) && (!Globalvars.aux1.GetComponent<stats>().sliearly))
				{
					Scoring("veryearly");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().bad;

				}
				if ((Globalvars.aux1.GetComponent<stats>().sliearly) && (!Globalvars.aux1.GetComponent<stats>().perfect))
				{
					Scoring("slisearly");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;
				}
				if ((Globalvars.aux1.GetComponent<stats>().perfect) && (!Globalvars.aux1.GetComponent<stats>().slilate))
				{
					Scoring("perfect");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().perfect;

				}
				if ((Globalvars.aux1.GetComponent<stats>().slilate) && (!Globalvars.aux1.GetComponent<stats>().verylate))
				{
					Scoring("slilate");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;

				}
				if ((Globalvars.aux1.GetComponent<stats>().verylate))
				{
					Scoring("verylate");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().bad;

				}


				/*
				if (!Globalvars.aux1.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");


				}
				else
				{
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;
					Scoring("perfect");
				}
				*/
				Globalvars.streakcounter = Globalvars.streakcounter + 1;
				//GameObject.Find("BoardR").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("RedBtn").GetComponent<matcontrol>().timer = 1f;
			}
			else if ((Globalvars.aux2 != null) && (!Globalvars.aux2.GetComponent<stats>().clicked)
			       )
			{
				Globalvars.aux2.GetComponent<stats>().clicked = true;
				//GameObject.Find("BoardR").GetComponent<ColorControl>().color = Color.green;
				GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;



				if (!Globalvars.aux2.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;



				if ((Globalvars.aux2.GetComponent<stats>().entered) && (!Globalvars.aux2.GetComponent<stats>().sliearly))
				{
					Scoring("veryearly");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().bad;

				}
				if ((Globalvars.aux2.GetComponent<stats>().sliearly) && (!Globalvars.aux2.GetComponent<stats>().perfect))
				{
					Scoring("slisearly");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;
				}
				if ((Globalvars.aux2.GetComponent<stats>().perfect) && (!Globalvars.aux2.GetComponent<stats>().slilate))
				{
					Scoring("perfect");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().perfect;
				}
				if ((Globalvars.aux2.GetComponent<stats>().slilate) && (!Globalvars.aux2.GetComponent<stats>().verylate))
				{
					Scoring("slilate");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;
				}
				if ((Globalvars.aux2.GetComponent<stats>().verylate))
				{
					Scoring("verylate");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().bad;

				}


				/*
				if (!Globalvars.aux2.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else
				{
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;
					Scoring("perfect");
				}
				*/				
				Globalvars.streakcounter = Globalvars.streakcounter + 1;
				//GameObject.Find("BoardR").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("RedBtn").GetComponent<matcontrol>().timer = 1f;
			}
			else if ((Globalvars.aux3 != null) && (!Globalvars.aux3.GetComponent<stats>().clicked)
			        )
			{
				Globalvars.aux3.GetComponent<stats>().clicked = true;
				//GameObject.Find("BoardR").GetComponent<ColorControl>().color = Color.green;
				GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;

				if (!Globalvars.aux3.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;


				if ((Globalvars.aux3.GetComponent<stats>().entered) && (!Globalvars.aux3.GetComponent<stats>().sliearly))
				{
					Scoring("veryearly");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().bad;

				}
				if ((Globalvars.aux3.GetComponent<stats>().sliearly) && (!Globalvars.aux3.GetComponent<stats>().perfect))
				{
					Scoring("slisearly");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;

				}
				if ((Globalvars.aux3.GetComponent<stats>().perfect) && (!Globalvars.aux3.GetComponent<stats>().slilate))
				{
					Scoring("perfect");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().perfect;

				}
				if ((Globalvars.aux3.GetComponent<stats>().slilate) && (!Globalvars.aux3.GetComponent<stats>().verylate))
				{
					Scoring("slilate");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().good;

				}
				if ((Globalvars.aux3.GetComponent<stats>().verylate))
				{
					Scoring("verylate");
					GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().bad;

				}

				/*
				if (!Globalvars.aux3.GetComponent<stats>().perfect)
				{
					Globalvars.correctnotes = Globalvars.correctnotes + 1;
					Scoring("good");
				}
				else
				{
					Globalvars.perfectnotes = Globalvars.perfectnotes + 1;
					Scoring("perfect");
				}
				*/
				Globalvars.streakcounter = Globalvars.streakcounter + 1;
				//GameObject.Find("BoardR").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("RedBtn").GetComponent<matcontrol>().timer = 1f;
			}
			else
			{
				Debug.Log(Globalvars.redclicks + " click error");
				//GameObject.Find("BoardR").GetComponent<ColorControl>().color = Color.red;
				GameObject.Find("RedBtn").GetComponent<matcontrol>().clickmat = GameObject.Find("RedBtn").GetComponent<matcontrol>().miss;
				Globalvars.incorrectnotes = Globalvars.incorrectnotes + 1;
				Scoring("bad");
				Globalvars.streakcounter = 0;
				//GameObject.Find("BoardR").GetComponent<ColorControl>().timer = 1f;
				GameObject.Find("RedBtn").GetComponent<matcontrol>().timer = 1f;

			}


		}

		else
		{
			
			return;
		}


	}


	public void Scoring(string caseofscore)
	{

		Debug.Log(caseofscore);
	


		if ((caseofscore == "perfect") || (caseofscore == "miss")
		|| (caseofscore == "veryearly") || (caseofscore == "verylate")
		|| (caseofscore == "slisearly") || (caseofscore == "slilate"))
		{
			tapacc.GetComponent<tapacccontrol>().set(caseofscore);

		}
		if (caseofscore == "bad")
		{
			tapacc.GetComponent<tapacccontrol>().set("miss");
		}


			int perfect = 0;
		int good = 0;
		int bad= 0;
		int miss = 0;

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

		if ((Globalvars.streakcounter > 199) )
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
