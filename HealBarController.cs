using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealBarController : MonoBehaviour {
	public Image vidaP1;
	public Image vidaP2;
	float porcentajeP1;
	float porcentajeP2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		porcentajeP1 = HealManager.vidaP1 / HealManager.vidaMaxima;
		porcentajeP2 = HealManager.vidaP2 / HealManager.vidaMaxima;
		vidaP1.fillAmount = porcentajeP1;
		vidaP2.fillAmount = porcentajeP2;
	}
}
