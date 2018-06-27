using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType{
	red,
	blue,
	green
}

public class ColorButton : MonoBehaviour {
	public GameObject buttonEffect;
	public ColorType type;
	public bool isReleased = true;

	MeshRenderer meshRenderer = null;

	// Use this for initialization
	void Start () {
		meshRenderer = GetComponent<MeshRenderer> ();

		buttonEffect.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		isReleased = false;
		// set buttonEffect
		buttonEffect.SetActive (true);
		//Get random material of button
		int cnt = GameManager.Instance.blueMats.Length;
		int ind = Random.Range (0, cnt - 1);
		//You can insert a your rate rule instead of IND.that is, you can select IND according to when is MISS,
		//when is Good, etc
		meshRenderer.material = GameManager.Instance.GetButtonMaterial(type, ind);
		buttonEffect.GetComponent<Animator> ().SetTrigger ("showEffect");
	}

	void OnMouseUp()
	{
		isReleased = true;
		// Init buttonEffect
		//buttonEffect.SetActive (false);
		//Init buttonMaterial
		meshRenderer.material = GameManager.Instance.GetButtonMaterial(type, 0);
	}
}
