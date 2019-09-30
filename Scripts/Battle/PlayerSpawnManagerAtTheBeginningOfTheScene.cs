using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerSpawnManagerAtTheBeginningOfTheScene : MonoBehaviour {

    public Transform spawnPlayer1;
    public Transform spawnPlayer2;
    public Transform J1;
    public Transform J2;
    public Transform loser;
    public string jumpButtonPlayer1 = "X";
	public string jumpButtonPlayer2 = "P2-X";
	public string axeNamePlayer1 = "L_Hor";
	public string axeNamePlayer2 = "P2-L_Hor";
	public string tagP1 = "P1";
	public string tagP2 = "P2";
	public string espadaTagP1 = "weaponP1";
	public string espadaTagP2 = "weaponP2";
	public string attackButtonP1 = "Cuadrado";
	public string attackButtonP2 = "P2-Cuadrado";
    public string shieldButtonP1 = "L1";
    public string shieldButtonP2 = "P2-L1";
    public string shieldButton2P1 = "R1";
    public string shieldButton2P2 = "P2-R1";
    public string FireButtonP1 = "Circulo";
    public string FireButtonP2 = "P2-Circulo";


    // Use this for initialization
    void Start () {
        GameObject player1 = Instantiate(HeroesInstanceManager.instance.playerOne, spawnPlayer1.position, spawnPlayer1.rotation);
        HeroesInstanceManager.instance.playerOneName = player1.name;

		PlayerController scriptControl = player1.GetComponent<PlayerController> ();
		if (scriptControl != null)
		{
            scriptControl.FireButton = FireButtonP1;
			scriptControl.axename = axeNamePlayer1;
			scriptControl.jumpButton = jumpButtonPlayer1;
			scriptControl.tag = tagP1;
			scriptControl.AttackButton = attackButtonP1;
            scriptControl.ShieldButton = shieldButtonP1;
            scriptControl.ShieldButton2 = shieldButton2P1;
            scriptControl.espada.tag = espadaTagP1;
            scriptControl.espada2.tag = espadaTagP1;
		}

		GameObject player2 = Instantiate(HeroesInstanceManager.instance.playerTwo, spawnPlayer2.position, spawnPlayer2.rotation);
		PlayerController scriptControl2 = player2.GetComponent<PlayerController> ();
        HeroesInstanceManager.instance.playerTwoName = player2.name;
		if(scriptControl2 != null)
		{
            scriptControl2.FireButton = FireButtonP2;
			scriptControl2.jumpButton = jumpButtonPlayer2;
			scriptControl2.axename = axeNamePlayer2;
			scriptControl2.tag = tagP2;
			scriptControl2.AttackButton = attackButtonP2;
            scriptControl2.ShieldButton = shieldButtonP2;
            scriptControl2.ShieldButton2 = shieldButton2P2;
            scriptControl2.espada.tag = espadaTagP2;
            scriptControl2.espada2.tag = espadaTagP2;
        }

        J1 = player1.transform;
        J2 = player2.transform;

        HealManager.P1Muerto = false;
        HealManager.P2Muerto = false;

    }
}
