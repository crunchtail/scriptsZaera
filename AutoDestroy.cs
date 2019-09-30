using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {
    public float timeToDestroy;
	// Use this for initialization
	void Start () {
        Invoke("Destruir", timeToDestroy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Destruir()
    {
        Destroy(this.gameObject);
    }
}
