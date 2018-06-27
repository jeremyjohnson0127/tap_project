using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static GameManager _instance = null;
	public static GameManager Instance {get { return _instance;}}

	public Material[] redMats;
	public Material[] blueMats;
	public Material[] greenMats;

	public bool isReleased = true;

	void Awake()
	{
		_instance = this;
        Modules.LoadDataSave();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Material GetButtonMaterial(ColorType type, int index)
	{
		Material mat = null;
		switch (type) {
		case ColorType.red:
			mat = redMats [index];
			break;
		case ColorType.blue:
			mat = blueMats [index];
			break;
		case ColorType.green:
			mat = greenMats [index];
			break;
		}
		return mat;
	}

    private void OnDestroy()
    {
        Modules.SaveLaneAngle();
        Modules.SaveNoteSize();
        Modules.SaveNoteSpeed();
        Modules.SaveAudioDelay();
    }
}
