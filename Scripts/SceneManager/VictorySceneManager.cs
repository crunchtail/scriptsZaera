using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySceneManager : MonoBehaviour {
    public Transform winner;
    public Transform loser;
    public PlayerController locomotion;
	// Use this for initialization
	void Start () {
        GameObject player1 = Instantiate(HeroesInstanceManager.instance.Winner, winner.position, winner.rotation);
        GameObject player2 = Instantiate(HeroesInstanceManager.instance.Loser, loser.position, loser.rotation);

        player1.GetComponent<PlayerController>().RunningParticles.Stop();
        player2.GetComponent<PlayerController>().RunningParticles.Stop();
        player1.GetComponent<PlayerController>().espada.SetActive(false);
        player1.GetComponent<PlayerController>().espada2.SetActive(false);
        player2.GetComponent<PlayerController>().espada.SetActive(false);
        player2.GetComponent<PlayerController>().espada2.SetActive(false);
        player1.GetComponent<PlayerController>().enabled = false;
        player2.GetComponent<PlayerController>().enabled = false;

        winner = player1.transform;
        loser = player2.transform;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
