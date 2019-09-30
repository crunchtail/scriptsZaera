using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public HeroesInstanceManager PlayerOne;
    public HeroesInstanceManager PlayerTwo;
    public Transform spawn;
    public Transform spawn2;
    public Heroe ChosenOne;
    public Heroe ChosenTwo;

    // Use this for initialization
    void Start () {
       // ChosenOne = PlayerOne.player;
       // ChosenTwo = PlayerTwo.player2;
    }
	
	// Update is called once per frame
	void Update () {
        ChosenOne.Model.transform.position = spawn.position;
        ChosenTwo.Model.transform.position = spawn2.position;


        //Este metodo de buscar objetos es incomodo, puede dar fallos

        //HeroesInstanceManager script = FindObjectOfType<HeroesInstanceManager>();
        //if (script != null)
        //{
        //    //script.playerTwo = ..;
        //}

        //Asi accedemos a la instancia estática del script
        //HeroesInstanceManager.instance.playerTwo = loquesea;

    }
}
