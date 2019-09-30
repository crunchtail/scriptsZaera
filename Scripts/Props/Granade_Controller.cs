using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade_Controller : MonoBehaviour {

    public Rigidbody rg;
    public float throw_force;
    public Vector3 ThrowForceDirection;

    public LayerMask objetivo;

    public float Force;
    public float _UpForce; 
    public Vector3 ForceDirection;

    public float radius = 5f;
    // Use this for initialization
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0)|| Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            rg.AddForce(throw_force * ThrowForceDirection, ForceMode.Force);

            StartCoroutine(explosion());
        }
    }

    private IEnumerator explosion()
    {
        yield return new WaitForSeconds(1.5f);

        Vector3 explosionPosition = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius, objetivo);
        foreach (Collider hit in colliders)
        {
            Rigidbody rg_explosion = hit.GetComponent<Rigidbody>();
            if(rg_explosion != null)
                {
                rg_explosion.AddExplosionForce(Force, explosionPosition, radius, _UpForce, ForceMode.Impulse);
            }
        }
    }

}
