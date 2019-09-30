using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {
    public GameObject Cam1;
    public GameObject Cam2;
    public Collider wall;
    public bool camControl;
    // Use this for initialization
    void Start () {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        camControl = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&(camControl == false))
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            camControl = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wall.isTrigger = false;
        }
    }
}
