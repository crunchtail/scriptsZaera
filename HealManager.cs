using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealManager : MonoBehaviour {
	public static float vidaP1 = 50;
	public static float vidaP2 = 50;
	public static float vidaMaxima = 50;
    public static bool P1Muerto;
    public static bool P2Muerto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (vidaP1 <= 0) {
			vidaP1 = vidaMaxima;
            P1Muerto = true;

		}
		if (vidaP2 <= 0) {
			vidaP2 = vidaMaxima;
            P2Muerto = true;   
		}
	}
}
