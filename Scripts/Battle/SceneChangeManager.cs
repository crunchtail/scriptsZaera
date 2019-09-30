using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour {

    //referenciar el script que almacena los puntos de vida de cada personaje y cambiar el booleano segun quien llegue a 0.
    public bool PlayerOneWin;
    public bool PlayerTwoWin;
	public static bool cambioScena;
    public static bool freezCamera;

    // Use this for initialization
    void Start () {
        PlayerOneWin = false;
        PlayerTwoWin = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerOneWin)
        {
            
            if(StageManager.CurrentLevel != 4)
            {
                HealManager.P1Muerto = false;
                HealManager.P2Muerto = false;
                StageManager.CurrentLevel++;

				FindObjectOfType<postProcessingLibrary> ().changePostProcessor (StageManager.CurrentLevel);
				cambioScena = true;
                freezCamera = true;
            }
            else
            {
                //SceneManager.LoadScene("");
            }
            PlayerOneWin = false;
        }

        if (PlayerTwoWin)
        {

            if (StageManager.CurrentLevel != 0)
            {
                HealManager.P1Muerto = false;
                HealManager.P2Muerto = false;
                StageManager.CurrentLevel--;
				FindObjectOfType<postProcessingLibrary> ().changePostProcessor (StageManager.CurrentLevel);
				cambioScena = true;
                freezCamera = true;

            }
            else
            {
                //SceneManager.LoadScene("");
            }
            PlayerTwoWin = false;
        }
		if(HealManager.vidaP1 <=0)
		{
			PlayerTwoWin = true;
		}
		if (HealManager.vidaP2 <= 0)
		{
			PlayerOneWin = true;
		}

	}
	

}
