using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadaBehaviour : PowerUpsBase {

	public GameObject granada;
	GameObject granadaInstance;
	Rigidbody rgGranada;
	public float throw_force;
	public float altura;
	public GameObject explosionParticles;
	public float daño;
    bool canExplosion = false;
    public LayerMask players;
	public AudioSource sonido;
	

	bool canUse = true;
	public float radius;
    public bool shield;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (granadaInstance != null)
        {
            granadaInstance.transform.position = new Vector3(granadaInstance.transform.position.x, granadaInstance.transform.position.y, 0);
        }
		
	}
	public override void Usar()
	{
		if (canUse)
		{
			granadaInstance = Instantiate(granada,emiter.transform.position, Quaternion.identity);
			rgGranada = granadaInstance.GetComponent<Rigidbody>();
			rgGranada.AddForce(throw_force * Player.transform.forward + new Vector3(0,altura,0), ForceMode.Impulse);
			canUse = false;
			numeroDeUsos--;
			StartCoroutine(explosion());
            
			if(numeroDeUsos == 0)
			{
				devolverControl();
			}
		}
		
	}

	private IEnumerator explosion()
	{
		yield return new WaitForSeconds(1f);
        Vector3 explosionPosition = granadaInstance.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius, players);

        Instantiate(explosionParticles, granadaInstance.transform.position, Quaternion.identity);
		sonido.Play();
        Destroy(granadaInstance);

        
        canUse = true;
        
        foreach (Collider hit in colliders)
        {
            if (!hit.GetComponent<PlayerController>().IsDefending)
            {

                
                if (hit.CompareTag(jugadorAfectado))
                {
                    for (int i = 0; i < colliders.Length; i++)
                    {
                        if ((jugadorAfectado == "P2"))
                        {
                            HealManager.vidaP2 -= daño;
                        }
                        else if ((jugadorAfectado == "P1"))
                        {
                            HealManager.vidaP1 -= daño;
                        }
                        Animator anim = hit.gameObject.GetComponent<Animator>();
                        hit.gameObject.transform.LookAt(new Vector3(granadaInstance.transform.position.x, hit.transform.position.y, hit.transform.position.z));
                        anim.SetTrigger("caer");

                    }
                }
            }
            else 
            {
                shield = hit.GetComponent<PlayerController>().CurEscudo.GetComponent<ShieldBehaviour>().destroy = true;
                
            }
            
        }
        if (numeroDeUsos <= 0)
        {
            devolverControl();
            Destroy(this.gameObject);
        }
        
		
	}
    private void OnCollisionEnter(Collision hit2)
    {
        
        
            
            
        
        
    }
}
