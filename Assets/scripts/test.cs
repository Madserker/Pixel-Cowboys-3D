﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	public void OnCollisionEnter(Collision other)
	{
		Debug.Log(other);
		Debug.Log(other.gameObject.name);
		if (other.gameObject.name == "Local")
		{
			// how much the character should be knocked back
			var magnitude = 5000;
			// calculate force vector
			var force = transform.position - other.transform.position;
			// normalize force vector to get direction only and trim magnitude
			force.Normalize();
			gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
		}
	}
}

