using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryAnimator : MonoBehaviour {
    public Animator anim1;
    public Animator anim2;
    public HeroesInstanceManager Players;
    public GameObject P1;
    public GameObject P2;
    public string name1;
    public string name2;
    public bool zaeraWin;
    public bool bonsitoWin;
    public bool pandaWin;
    public bool rangaWin;
	// Use this for initialization
	void Start () {
        //GameObject objetoconscript = GameObject.Find("Game Manager");
        //Players = objetoconscript.GetComponent<HeroesInstanceManager>();

        //name1 = Players.Winner.name;
        //name2 = Players.Loser.name;
   

        //P1 = GameObject.Find(Players.playerOneName) as GameObject;
        //P2 = GameObject.Find(Players.playerTwoName) as GameObject;

        VictorySceneManager scriptManagerVictoria = FindObjectOfType<VictorySceneManager>();



        anim1 = scriptManagerVictoria.winner.GetComponent<Animator>();
        anim2 = scriptManagerVictoria.loser.GetComponent<Animator>();

        
	}
	
	// Update is called once per frame
	void Update () {

        anim1.SetBool("zaeraWin", true);

        anim2.SetBool("lose", true);
           
                //if (name1 == "ZAERA_RIGGEADO")
                //{
                //    zaeraWin = true;
                //}

                //if (name1 == "BONSITO_RIGGEADO 1")
                //{
                //    zaeraWin = true;
                //}

                //if (name1 == "Panda BAMBU 1")
                //{
                //    zaeraWin = true;
                //}

                //if (name1 == "LOBO RAGNA 1")
                //{
                //    zaeraWin = true;
                //}

            }

        }
	

