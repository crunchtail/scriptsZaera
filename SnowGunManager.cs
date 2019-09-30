using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGunManager : MonoBehaviour {
    public Transform holder;
    public GameObject snowball;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
           
        
    }
    public void Usar(Transform referencia)
    {
        GameObject bala = Instantiate(snowball, this.transform.position + this.transform.forward * 5, Quaternion.identity);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
		rb.velocity = referencia.forward;
    }
}
