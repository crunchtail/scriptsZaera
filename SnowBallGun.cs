using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallGun : PowerUpsBase
{

    public GameObject bolaNieve;
    public float snowBallSpeed;
    public float numBolas;
     float Cooldown;
	public AudioSource sonido;
    public float Cadencia = 1f;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        Cooldown = Cadencia;
        numBolas = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown -= Time.deltaTime;
       
    }

    public override void Usar()
    {
        if (Cooldown < 0)
        {
            if (numBolas > 0)
            {
				sonido.Play();
                Hijo.SetActive(true);
                GameObject go = Instantiate(bolaNieve, emiter.transform.position + Player.forward, Quaternion.identity);
                Rigidbody rb = go.GetComponent<Rigidbody>();
                anim = Player.gameObject.GetComponent<Animator>();
                anim.SetLayerWeight(1, 1);
                rb.velocity = Player.forward * snowBallSpeed;
                numBolas--;
                Invoke("dejarDeApuntar", 2f);
                Cooldown = Cadencia;
            }
        }

    }
    public void dejarDeApuntar()
    {
        anim.SetLayerWeight(1, 0);
        Hijo.SetActive(false);
        if (numBolas <= 0)
        {
            devolverControl();
            Destroy(this.gameObject);
        }
    }
}

