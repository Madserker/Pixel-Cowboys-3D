using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {
	// Start is called before the first frame update
	private CharacterController controller;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	private Animator anim;

	private Vector3 moveDirection = Vector3.zero;


	public float mouseSensitivity = 100.0f;
	public float clampAngle = 80.0f;

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis

	void Start()
	{
		//Is this my object?
		if (isLocalPlayer == false) {
			//this obj belongs to another player
			return;
		}
		//since the playerobject is invisible and not part of the world,
		//give me something physical to move

		CmdSpawnMyUnit();
	}

	public GameObject PlayerUnitPrefab;


	// Update is called once per frame
	void Update()
	{

	}

	GameObject myPlayerUnit;
	//COMMAND THE SERVER
	[Command]
	void CmdSpawnMyUnit() {
		//We are guarenteed to be on the server
		GameObject go = Instantiate(PlayerUnitPrefab);
		myPlayerUnit = go;
		//go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient)
		//propagate to all the clients
		NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
	}
	
}
