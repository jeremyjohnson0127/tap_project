using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvascontrol : MonoBehaviour {

	public Text correct;
	public Text perfect;
	public Text incorrect;
	public Text missed;
	public Text streak;
	public Text score;
	public Text percentage;
	public Text test;
	public Text fpscount;
	public Image barImage;
    public XplorerGuitarInput guitarInput;

    // Use this for initialization

    float deltaTime = 0.0f;

	void Start () {
		Globalvars.correctnotes = 0;
		Globalvars.incorrectnotes = 0;
		Globalvars.missednotes = 0;
		Globalvars.blueclicks = 0;
		Globalvars.redclicks = 0;
		Globalvars.greenclicks = 0;
	}
	
	// Update is called once per frame
	void Update () {

		float perc = 0;
	
		perc = (float) ((Globalvars.numberofnotesplayed *1.0f) / (Globalvars.numbeofnotestotal * 1.0f));
		//Debug.Log(perc);

		float fps = (int)(1f / Time.unscaledDeltaTime);

		//Debug.Log(Globalvars.numberofnotesplayed + "  " + Globalvars.numbeofnotestotal);
		fpscount.text = fps + "";
		perfect.text = "Perfect: " + Globalvars.perfectnotes;
		correct.text = "Correct: " + Globalvars.correctnotes;
		incorrect.text = "Incorrect: " + Globalvars.incorrectnotes;
		missed.text = "Missed :" + Globalvars.missednotes;
		streak.text = "" + Globalvars.streakcounter;
		float totalnotes = Globalvars.correctnotes + Globalvars.perfectnotes + Globalvars.incorrectnotes + Globalvars.missednotes;
		float hitrate = ((Globalvars.correctnotes + Globalvars.perfectnotes) / (totalnotes));
		if (totalnotes == 0)
			hitrate = 0;
		percentage.text = "" + ( Mathf.Floor (hitrate * 100)) + "%";  
		score.text = "" + Globalvars.score;
        //test.text = "Rednots " + Globalvars.redclicks;
        barImage.fillAmount = perc;

        if (barImage.fillAmount >= 1)
        {
            guitarInput.BackToMenu();
        }
	}
}
