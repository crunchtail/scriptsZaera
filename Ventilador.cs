using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : PowerUpsBase {
	
	public float WindForce; //Cantidad de fuerza de esta zona de viento si o no
	bool activado = false;
	Vector3 WindForceDirection; //Direccion en la que se aplica la fuerza
								// Use this for initialization
								// Use this for initialization
	public GameObject zonaEfecto;
	public Collider zonaEffect;
	public float duracion;
	public float cooldowmn = 0;
    public GameObject ParticleSystem;
    public Animator windAnim;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Player != null)
        {
            transform.eulerAngles = Player.transform.eulerAngles;
            transform.position = Player.transform.position + Player.forward * 0.5f + Vector3.up;
            transform.eulerAngles = new Vector3(0, Player.transform.localEulerAngles.y + 90, transform.eulerAngles.z);
        }
		
		
		if (activado)
		{
            Hijo.SetActive(true);
            windAnim.SetBool("activado", true);
			cooldowmn += Time.deltaTime;
            ParticleSystem.SetActive(true);
			if(cooldowmn >= duracion)
			{
				devolverControl();
				Destroy(this.gameObject);
			}
		}

	}
	public override void Usar()
	{
        if (activado)
        {
            devolverControl();
            Destroy(this.gameObject);
        }
		activado = true;
		zonaEffect.enabled = true;
		//zonaEfecto.SetActive(true);
		

	}
	void OnTriggerStay(Collider other)
	{
		if (activado)
		{
			if ((jugadorAfectado == other.gameObject.tag))
			{
                if (!(other.GetComponent<PlayerController>().IsDefending))
                {
                    Animator enemyAnim = other.GetComponent<Animator>();
                    other.transform.LookAt(new Vector3(this.transform.position.x, other.transform.position.y, other.transform.position.z));
                    if (!enemyAnim.GetCurrentAnimatorStateInfo(0).IsTag("invulnerable"))
                    {
                        enemyAnim.SetTrigger("caer");
                    }
                }
				
				
			}
		}
	}



}

