using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBoton : MonoBehaviour {
    AudioSource sonidoBoton;
	// Use this for initialization
	void Start () {
        sonidoBoton = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Suena()
    {
        sonidoBoton.Play();
    }
}
