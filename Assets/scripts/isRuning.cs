using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class isRuning : NetworkBehaviour {
	private Animator anim;
	// Start is called before the first frame update

	void Start()
    {
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (hasAuthority == false)
		{
			return;
		}
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
		{
			anim.SetBool("isRuning", true);
		}
		else {
			anim.SetBool("isRuning", false);
		}
	}
}
