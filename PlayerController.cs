using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
	public GameObject espada;
    public GameObject espada2;
    public GameObject emitter;
    public AudioSource SonidoEspada;
	
    CharacterController charController;
    
   
    
    bool isMoving = false;
    Vector3 movimiento;
    public float gravityScale = 5;
    public float speed;
	public float Damage;
    
    public float jumpForce;
    public bool isFalling;
	public float puntosDeVida;
    
    bool isGrounded;
	public bool canUseSword = true;
    
	public bool blocking;

    public GameObject sistemaDeParticulas;
    public GameObject Sparks;

    PlayerController controlPersonaje;
    public ParticleSystem RunningParticles;
	//Power Ups
	PowerUpsBase powerUp;
	

    //Inputs
    public string FireButton;
    public string axename = "L_Hor";
    public string jumpButton;
    public string ShieldButton;
    public string ShieldButton2;
    public string AttackButton;

    //tags
    public string tag = "P1";
    public string espadaTag = "weaponP1";
    public string armaTag;
    
    public float x, y;
    bool combo = false;

    public ShieldBehaviour protect;
    public GameObject escudo;
    public GameObject CurEscudo;
    public bool IsDefending;
    public float Cooldown;
    public float Cadencia = 1f;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        transform.tag = tag;
		controlPersonaje = GetComponent<PlayerController>();
		canUseSword = true;
        
    }
	public void animatorcheking()
	{

		if (anim.GetCurrentAnimatorStateInfo(0).IsTag("mov")){
			Locomotion();

		}
	}
    // Update is called once per frame
    void Update()
    {
        Cooldown -= Time.deltaTime;

        if (charController.isGrounded)
        {

            var emision = RunningParticles.emission;
            
            emision.rateOverDistance = 7;
        }
        else
        {
            var emision = RunningParticles.emission;
            emision.rateOverDistance = 0;
        }
		animatorcheking();
		attackActive();

		x = Input.GetAxisRaw(axename);


        isGrounded = ((charController.collisionFlags & CollisionFlags.Below) != 0);


        
        if ((Input.GetButtonDown(AttackButton) && canUseSword)&&(!IsDefending))
        {
            anim.SetTrigger("Attack");

            SonidoEspada.Play();
        }


        //velocidad = charController.velocity;
        if (x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;

        }
        anim.SetBool("isMoving", isMoving);
        
        anim.SetBool("isFalling", isFalling);
        anim.SetBool("isGrounded", charController.isGrounded);
        
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (Input.GetButtonDown(AttackButton))
        {
			if (powerUp)
			{
				powerUp.Usar();
			}

		}
		

		movimiento = new Vector3(x * speed * 0.1f, movimiento.y - gravityScale * Time.deltaTime, 0);

		if (PauseMenuManager.IsPaused == false)
		{
			if (((((Input.GetButton(ShieldButton) || (Input.GetButton(ShieldButton2))) /*&& (this.tag == "P1") */) && (!IsDefending)) && (Cooldown < 0)))
			{
				Instantiate(escudo, this.transform);
				protect = GetComponentInChildren<ShieldBehaviour>();
				CurEscudo = protect.gameObject;
				IsDefending = true;
			}
			else if ((((Input.GetButtonUp(ShieldButton) || (Input.GetButtonUp(ShieldButton2))) /*&& (this.tag == "P1")*/) && (IsDefending)))
			{
				Destroy(CurEscudo);
				Cooldown = Cadencia;
				IsDefending = false;
			}
			else if (CurEscudo.GetComponent<ShieldBehaviour>().destroy)
			{
				IsDefending = false;
				Cooldown = Cadencia;
			}
		}
		



            //if (((((Input.GetButton(ShieldButton) || (Input.GetButton(ShieldButton2))) && (this.tag == "P2")) && (!IsDefending)) && (Cooldown < 0)))
            //{
            //    Instantiate(escudo, this.transform);
            //    protect = GetComponentInChildren<ShieldBehaviour>();
            //    CurEscudo = protect.gameObject;
            //    IsDefending = true;
            //}
            //else if ((((Input.GetButtonUp(ShieldButton) || (Input.GetButtonUp(ShieldButton2))) && (this.tag == "P2")) && (IsDefending)))
            //{
            //    Destroy(CurEscudo);
            //    Cooldown = Cadencia;
            //    IsDefending = false;
            //}
            //else if (CurEscudo.GetComponent<ShieldBehaviour>().destroy)
            //{
            //    IsDefending = false;
            //    Cooldown = Cadencia;
            //}

       



    }
    private void Locomotion()
    {
		if(PauseMenuManager.IsPaused == false)
		{
			charController.Move(movimiento);
		}
        

		if (x > 0)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
		}
		if (x < 0)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);
		}
		if (isGrounded)
		{

			isFalling = false;
			movimiento = new Vector3(movimiento.x, movimiento.y, 0);

			if ((Input.GetButtonDown(jumpButton)&&(!IsDefending)))
			{
				anim.SetTrigger("Jump");
				movimiento.y = jumpForce;
			}
		}
		else
		{


			isFalling = true;
		}
	}
    void OnTriggerEnter(Collider other)
    {
		GameObject player1 = GameObject.FindGameObjectWithTag("P1");
		GameObject player2 = GameObject.FindGameObjectWithTag("P2");
        Animator anim1 = player1.GetComponent<Animator>();
        Animator anim2 = player2.GetComponent<Animator>();
		if (!blocking)
		{
            
			if ((this.tag == "P1" && other.tag == "weaponP2") && (!IsDefending))
			{
				
                if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("invulnerable"))
                {

                    HealManager.vidaP1 -= Damage;
                    Instantiate(sistemaDeParticulas, espada.transform.position, Quaternion.identity);
                    transform.LookAt(new Vector3(player2.transform.position.x, this.transform.position.y, this.transform.position.z));
                    //if (anim2.GetCurrentAnimatorStateInfo(0).IsTag("tirar") && combo)
                    //{
                    //    anim.SetTrigger("caer");
                    //}
                    //else
                    //{
                        anim.SetTrigger("hitMe");
                        combo = true;
                        StartCoroutine(resetearCombo());
                    //}
                    anim.SetTrigger("hitMe");
                }
                
				
				
			}
            else if((this.tag == "P1" && other.tag == "weaponP2") && (IsDefending))
            {
                CurEscudo.GetComponent<ShieldBehaviour>().puntosVida -= 5;
                Instantiate(Sparks, espada.transform.position, Quaternion.identity);
            }

			if ((this.tag == "P2" && other.tag == "weaponP1")&&(!IsDefending))
			{
				
                if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("invulnerable") )
                {
                    HealManager.vidaP2 -= 5;
                    Instantiate(sistemaDeParticulas, espada.transform.position, Quaternion.identity);
                    transform.LookAt(new Vector3(player1.transform.position.x, this.transform.position.y, this.transform.position.z));
                    //if (anim1.GetCurrentAnimatorStateInfo(0).IsTag("tirar") && combo)
                    //{
                    //    anim.SetTrigger("caer");
                    //}
                   
                        anim.SetTrigger("hitMe");
                        combo = true;
                        StartCoroutine(resetearCombo());
                    
                }
                
				
			}
            else if ((this.tag == "P2" && other.tag == "weaponP1") && (IsDefending))
            {
                CurEscudo.GetComponent<ShieldBehaviour>().puntosVida -= 5;
                Instantiate(Sparks, espada.transform.position, Quaternion.identity);
            }

        }
        if (other.CompareTag("PowerUp"))
        {
			//powerUp = other.GetComponent<SnowBallGun>();
			//powerUp.Coger(this.transform);
			CogerPowerUp(other.gameObject);
        }


    }
	public void CogerPowerUp(GameObject objetoRecogido)
	{
		if (objetoRecogido.CompareTag("PowerUp") && powerUp == null)
		{
            PowerUpsBase pb = objetoRecogido.GetComponent<PowerUpsBase>();
            if (pb.isParented == false)
            {
                powerUp = objetoRecogido.GetComponent<PowerUpsBase>();
                canUse(false);
            }
            
            
            
			if(transform.tag == "P1" && powerUp != null)
			{
                
				powerUp.Coger(transform,"P2" , controlPersonaje, emitter);
			}
			else
			{
				powerUp.Coger(transform, "P1", controlPersonaje, emitter);
			}
			
		}
		
	}
	public void canUse(bool canOrNot)
	{
		canUseSword = canOrNot;
	}
	public void attackActive()
	{
		if (canUseSword)
		{
            if (this.tag == "P1")
            {
                espada.SetActive(true);
                espada2.SetActive(false);
            }
            if (this.tag == "P2")
            {
                espada.SetActive(false);
                espada2.SetActive(true);
            }
        }
		else
		{
            if (this.tag == "P1") espada.SetActive(false);
            if (this.tag == "P2") espada2.SetActive(false);
        }
	}
    public IEnumerator resetearCombo()
    {
        yield return new WaitForSeconds(0.75f);
        combo = false;
    }
    
	
}
