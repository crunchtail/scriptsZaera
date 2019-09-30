using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler2 : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorChecking();
	}
	public void AnimatorChecking()
	{
		if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Locomotion")){
			Locomotion();
		}
	}
	public void Locomotion()
	{

	}
}
