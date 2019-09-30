using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour {
    float explosionForce;
    Vector3 explosionPosition;
    float explosionRadius;
    public Animator anim;
    public bool spawn;
    public bool destroy;
    public Renderer renderSphere;
    public GameObject SecondSphere;
    public Rigidbody[] rg_cristal;

    public HeroesInstanceManager Players;
    public GameObject P1;
    public GameObject P2;

    public int puntosVida;
     public float Cooldown;
    // Use this for initialization
    void Start () {
        explosionPosition = transform.position;
        anim = GetComponent<Animator>();
        renderSphere = GetComponent<MeshRenderer>();
        SecondSphere.gameObject.SetActive(false);

        GameObject objetoconscript = GameObject.Find("Game Manager");

        Players = objetoconscript.GetComponent<HeroesInstanceManager>();


        P1 = Players.playerOne;
        P2 = Players.playerTwo;
        

        anim.SetBool("Spawn", true);
        this.gameObject.tag = this.transform.parent.gameObject.tag;
    }
	
	// Update is called once per frame
	void Update () {
        Cooldown -= Time.deltaTime;
        GameObject objetoconscript = GameObject.Find("Game Manager");
        Players = objetoconscript.GetComponent<HeroesInstanceManager>();
        //P1 = Players.playerOne;
        //P2 = Players.playerTwo;

        P1 = GameObject.Find(Players.playerOneName);
        P2 = GameObject.Find(Players.playerTwoName);

        anim.SetBool("destroy", destroy);

        if (destroy == true)
        {
            anim.SetBool("destroy", true);
            renderSphere.enabled = false;
            SecondSphere.gameObject.SetActive(true);
            Destroy(this.gameObject,1.5f);
           
        }

        if (Cooldown <= 10) 
        {
            puntosVida = 10;
        }
        if (Cooldown <= 0) 
        {
            puntosVida = 0;
        }

        if (puntosVida <= 10)
        {
            anim.SetBool("protect", true);
        }
        if (puntosVida <= 0)
        {
            destroy = true;
        }
    }


}
