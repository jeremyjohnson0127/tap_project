using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private float _speed;
	float timeelapsed;
	public float time;
	bool active = false;
	public bool video = false;
    Vector3 oldPos;

	/// <summary>
	/// The Camera Speed.
	/// </summary>
	public float Speed
    {
        get 
        { 
            return _speed; 
        }
        set 
        { 
            _speed = value; 
        }
    }

    private void Start()
    {
        oldPos = transform.localPosition;
    }
    void Update()
	{
		timeelapsed = Time.fixedDeltaTime + timeelapsed;

		if ((!active) && (time <= timeelapsed))
		{
			active = true;
		}
	}


	// Update is called once per frame
	void FixedUpdate () 
	{
		
		if ((active == true) && (video==true))
		{
			transform.Translate(Speed * Vector3.forward * Time.deltaTime, Space.World);
		}
	}

    public void Init()
    {
        if ((active == true) && (video == true))
        {
            transform.localPosition = oldPos;
        }
    }
}
