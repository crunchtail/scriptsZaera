using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public string NextScene;
    // Use this for initialization
    void Start()
    {
        HealManager.P1Muerto = false;
        HealManager.P2Muerto = false;
        StartCoroutine(LoadingScreen());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(NextScene, LoadSceneMode.Single);
    }
}
