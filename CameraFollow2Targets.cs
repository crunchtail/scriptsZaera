using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2Targets : MonoBehaviour {
	public GameObject P1;
	public GameObject P2;
    public GameObject PowerUp;
    public GameObject followed1;
    public GameObject followed2;
    float distance1, distance2, distance3;
	public float velocidadSeguimiento;
    public float velocidadCamara;
	public Transform Micamara;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        PowerUp = GameObject.FindGameObjectWithTag("PowerUp");
		P1 = GameObject.FindGameObjectWithTag("P1");
		P2 = GameObject.FindGameObjectWithTag("P2");
        compararPosiciones();


        if (SceneChangeManager.freezCamera == true)
        {

            
        }
        else
        {
            float distancia = Vector3.Distance(followed1.transform.position, followed2.transform.position);
            float fixedDistance = distancia;
            if (distancia > 20)
            {
                fixedDistance = 20;
            }
            if (distancia < 5)
            {
                fixedDistance = 5;
            }
            transform.position = Vector3.Lerp(transform.position, (followed1.transform.position + followed2.transform.position) / 2, velocidadSeguimiento);
            Micamara.position = Vector3.Lerp(Micamara.position, new Vector3(Micamara.position.x, Micamara.position.y, -fixedDistance), velocidadCamara);
            Micamara.transform.LookAt(transform);
        }
		


	}
    void compararPosiciones()
    {
        
        if (PowerUp != null)
        {
            distance1 = Vector3.Distance(PowerUp.transform.position, P1.transform.position);
            distance2 = Vector3.Distance(PowerUp.transform.position, P2.transform.position);
        }
        else
        {
            distance1 = 0;
            distance2 = 0;
        }
        distance3 = Vector3.Distance(P1.transform.position, P2.transform.position);
        if (distance3 > distance1 && distance3 > distance2)
        {
            followed1 = P1;
            followed2 = P2;
        }
        if (distance1 > distance2 && distance1 > distance3)
        {
            followed1 = P1;
            followed2 = PowerUp;
        }
        if (distance2 > distance1 && distance2 > distance3)
        {
            followed1 = PowerUp;
            followed2 = P2;
        }
    }
}
