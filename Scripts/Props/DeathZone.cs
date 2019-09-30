using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("P1")) 
        {
            HealManager.vidaP1 = 0;
        }
        else if (other.CompareTag("P2"))
        {
            HealManager.vidaP2 = 0;
        }
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
