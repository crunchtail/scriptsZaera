using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallManager : MonoBehaviour {
    Rigidbody rg;
    public float speed;
    public float ShooterDistance;
    
	public GameObject collisionParticles;

    public float time;
    // Use this for initialization
    void Start() {
        rg = GetComponent<Rigidbody>();

        
        //Invoke("destruir", time);
        Destroy(this.gameObject, 3f);
        rg.velocity *= speed;
    }

    // Update is called once per frame
    void Update() {
       
    }
    public void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.CompareTag("P1"))&&(collision.gameObject.GetComponent<PlayerController>().IsDefending == false))
        {
            HealManager.vidaP1 -= 5;
			Instantiate(collisionParticles, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
			
        }
        else if ((collision.collider.CompareTag("P2")) && (collision.gameObject.GetComponent<PlayerController>().IsDefending == false))
        {
            HealManager.vidaP2 -= 5;
			Instantiate(collisionParticles, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
        }
    }
}
