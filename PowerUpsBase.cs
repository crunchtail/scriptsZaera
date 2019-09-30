using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PowerUpsBase : MonoBehaviour {


	protected Transform Player;
	PlayerController controlPersonaje;
	protected LayerMask whatIsHittable;
	public int numeroDeUsos = 3;
	protected GameObject emiter;
	protected string jugadorAfectado;
    public GameObject Hijo;

    public bool isParented;
	
	GameObject parentate;
	bool isParent;

	public virtual void Usar()
	{
		Debug.Log("Usar Base");
		
	}
	public void Coger(Transform playerTransform, string jugadorContrario, PlayerController playerControl, GameObject emisor)
	{
        
        if (!isParented)
        {
            isParented = true;
            Hijo.SetActive(false);
            Player = playerTransform;
            jugadorAfectado = jugadorContrario;
            controlPersonaje = playerControl;
            emiter = emisor;

            parentate = playerTransform.gameObject;



            PowerUpHandler fo = playerTransform.gameObject.GetComponentInChildren<PowerUpHandler>();
            if (fo)
            {
                transform.parent = fo.transform;
            }
            else
            {
                Debug.LogError("No se encuentra el objeto a emparentar");
            }
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            //this.transform.rotation = zero;
            isParent = true;
            // P1Parented = true;
			
        }
       
		
	}
	public void Soltar()
	{
		//rellenar
	}
	public void devolverControl()
	{
		controlPersonaje.canUse(true);
	}
}
