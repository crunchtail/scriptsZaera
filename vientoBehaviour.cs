using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vientoBehaviour : MonoBehaviour {
	public float Windforce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay(Collider other)
	{

		Vector3 WindForceDirection;
		
		if(other.CompareTag("P1") || other.CompareTag("P2"))
		{
			
			WindForceDirection = transform.forward;
			other.transform.position += WindForceDirection * Windforce;
		}
			

		

	}
}
