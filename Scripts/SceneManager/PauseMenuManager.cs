using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour {
    public GameObject PauseCanvas;
    public GameObject TittleButtons;
    public GameObject SoundCanvas;
    public static bool IsPaused;
    public bool OtherCanvasEnabled;
    public Button firstSelected;
    public Slider Music;
	
	
    
	// Use this for initialization
	void Start () {
        PauseCanvas.SetActive(false);
        SoundCanvas.SetActive(false);
		
    }
	
	
	// Update is called once per frame
	void Update () {
        if (((Input.GetButtonDown("Start"))||(Input.GetButtonDown("P2-Start")) && (!OtherCanvasEnabled)))
        {
            if (!IsPaused)
            {
				
                IsPaused = true;
                Time.timeScale = 0;
                PauseCanvas.SetActive(true);
                firstSelected.Select();
            }
            else if (IsPaused)
            {
                Reanude();
            }
        }
      
	}

    public void EnableSoundManager()
    {
        PauseCanvas.SetActive(false);
        SoundCanvas.SetActive(true);
        OtherCanvasEnabled = true;
        Music.Select();
    }


    public void DisableSoundManager()
    {
        PauseCanvas.SetActive(true);
        SoundCanvas.SetActive(false);
        OtherCanvasEnabled = false;
		firstSelected.Select();
    }




    public void ChangeScene(string  sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
		IsPaused = false;
    }

    public void ResetGame()
    {

        //Cualquier otro parametro necesario para dejar el estado de partida como al principio

        ChangeScene("Battle Scene");
		IsPaused = false;
    }

    public void Reanude()
    {
        IsPaused = false;
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
    }





}
