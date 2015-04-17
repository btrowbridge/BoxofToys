﻿using UnityEngine;
using System.Collections;

public class CubeRotationXminus : MonoBehaviour {

	public GameObject targetCube;
	public GameObject triggerParent;
	public float distanceDownUp = 5.0f;
	public float distanceRight = -20.0f;
	public GameObject GhostCube;
	bool moving = false;
	float speed = 100f;
	
	
	
	void OnTriggerExit(Collider other)
	{
		triggerParent.transform.position += Vector3.right * distanceRight;
		
		
		moving = true;
		
		
	}
	void FixedUpdate ()
	{
		if (moving) 
		{
			
			GhostCube.transform.position += Vector3.down * distanceDownUp;
			targetCube.transform.position = Vector3.Lerp (targetCube.transform.position, GhostCube.transform.position, Time.fixedDeltaTime * speed);
			
			
			GhostCube.transform.position += Vector3.right * distanceRight;
			targetCube.transform.position = Vector3.Lerp (targetCube.transform.position, GhostCube.transform.position, Time.fixedDeltaTime * speed);
			
			GhostCube.transform.Rotate (0, 0, -90);
			targetCube.transform.rotation = Quaternion.Slerp (targetCube.transform.rotation, GhostCube.transform.rotation, Time.fixedDeltaTime * speed);
			
			GhostCube.transform.position += Vector3.up * distanceDownUp;
			targetCube.transform.position = Vector3.Lerp (targetCube.transform.position, GhostCube.transform.position, Time.fixedDeltaTime * speed);
			
			
			moving = false;
		}
		
	}
}
