using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parenting_PowerUp : MonoBehaviour {
    public Collider colliderEffect;
    Quaternion zero = new Quaternion(0, 0, 0, 0);
    public bool IsParent;
    public GameObject parentate;
    public static bool P1Parented;
    public static bool P2Parented;
    

    public string playerParented = "";

    // Use this for initialization
    void Start () {
        colliderEffect.gameObject.SetActive(false);
        IsParent=false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Joystick1Button3)||((Input.GetKeyDown(KeyCode.Joystick2Button3))))
        {
            this.transform.parent = null;
            colliderEffect.gameObject.SetActive(false);
            this.gameObject.GetComponent<Collider>().enabled = false;
            IsParent = false;

        }
	}


    public void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("P1") || other.CompareTag("P2")))
        {
            parentate = other.gameObject;
            //colliderEffect.gameObject.SetActive(true);
            //Transform go = other.gameObject.transform.Find("RightHand");

            //if (go)
            //{
            //    transform.parent = go;

            //}
            //else
            //{
            //    Debug.LogError("No se encuentra el objeto a emparentar");
            //}

            PowerUpHandler fo = other.GetComponentInChildren<PowerUpHandler>();
            if (fo)
            {
                transform.parent = fo.transform;
            }
            else {
                Debug.LogError("No se encuentra el objeto a emparentar");
        }

        //this.transform.rotation = zero;
        IsParent = true;
            // P1Parented = true;
            playerParented = other.tag;
        }
      
    }
}
