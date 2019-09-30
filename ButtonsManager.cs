using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour {
    public GameObject TittleButtons;
    public GameObject SoundCanvas;
    public Slider Music;
	public Button botonMenuPrincipal;
	public Slider botonMenuOpciones;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
	public void Exit()
	{
		Application.Quit();
	}

    public void OnlyEnableSoundManager()
    {
        TittleButtons.SetActive(false);
        SoundCanvas.SetActive(true);
		botonMenuOpciones.Select();
        Music.Select();
    }

    public void OnlyDisableSoundManager()
    {
		
        TittleButtons.SetActive(true);
        SoundCanvas.SetActive(false);
		botonMenuPrincipal.Select();
	}


}
