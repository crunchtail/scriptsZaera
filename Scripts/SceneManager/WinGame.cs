using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(StageManager.CurrentLevel);
              
		if(((StageManager.CurrentLevel == 0)&&(HealManager.P1Muerto == true)))
        {
            HeroesInstanceManager.instance.Loser = HeroesInstanceManager.instance.playerOne;
            HeroesInstanceManager.instance.Winner = HeroesInstanceManager.instance.playerTwo;
            HealManager.P1Muerto = false;
            HealManager.P2Muerto = false;
			StageManager.CurrentLevel = 2;
			SceneManager.LoadScene("Victory");
        }

        if (((StageManager.CurrentLevel == 4) && (HealManager.P2Muerto == true)))
        {
            HeroesInstanceManager.instance.Winner = HeroesInstanceManager.instance.playerOne;
            HeroesInstanceManager.instance.Loser = HeroesInstanceManager.instance.playerTwo;
            HealManager.P1Muerto = false;
            HealManager.P2Muerto = false;
			StageManager.CurrentLevel = 2;

			SceneManager.LoadScene("Victory");
        }
        
	}
}
