using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vsynch : MonoBehaviour {

	float timeelapsed;
	public float delaytime;
	bool active = false;
	public GameObject vplayer;
    public GameObject videoScreen;

    private void OnEnable()
    {
        timeelapsed = 0;
        delaytime = Modules.fAudioDelay;
        active = false;
        vplayer.SetActive(false);
        GameObject.Find("Guitar Camera").GetComponent<CameraMovement>().video = false;

        if (videoScreen != null)
        {
            if (Modules.bShowYoutubeScreen == 1)
                videoScreen.SetActive(true);
            else
                videoScreen.SetActive(false);
        }

        AudioSource audioSource = vplayer.GetComponent<AudioSource>();
        audioSource.volume = Modules.fGameVolume;
    }

    // Use this for initialization
    void Start () {
		//waitingscreen.SetActive(false);
		Debug.Log("Youtube Video Started");
    }
	
	// Update is called once per frame
	void Update () {
		timeelapsed = Time.fixedDeltaTime + timeelapsed;

		if ((!active) && (delaytime <= timeelapsed))
		{
			active = true;
			vplayer.SetActive(true);
			GameObject.Find("Guitar Camera").GetComponent<CameraMovement>().video = true;

		}
	}

}
