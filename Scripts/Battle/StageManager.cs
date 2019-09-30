using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StageManager : MonoBehaviour {
    public float t;
    public GameObject MainCam;
    public GameObject CameraCube;
    
    public static int CurrentLevel = 2;
	public GameObject[] spawns;
    public Transform[] cameraPositions;
	public GameObject P1;
	public GameObject P2;
    Animator animP1;
    Animator animP2;

    public GameObject spawnParticles1;
    public GameObject spawnParticles2;

	float tiempoRandom;
    public Transform generador;

    public Vector3 spawn1;
    public Vector3 spawn2;

    Rigidbody rbGenerador;
    GameObject currentPowerUp;
    public GameObject[] powerUps;

    bool canSpawn = false;
	// Use this for initialization
	void Start () {
        
        rbGenerador = generador.GetComponent<Rigidbody>();
        spawn1 = spawns[CurrentLevel].transform.Find("spawnP1").transform.position;
        spawn2 = spawns[CurrentLevel].transform.Find("spawnP2").transform.position;
        generador.position = spawn1;
        rbGenerador.velocity = new Vector3(6, 0, 0);
		tiempoRandom = Random.Range(3, 10);

	}
	
	// Update is called once per frame
	void Update () {
        P1 = GameObject.FindGameObjectWithTag("P1");
        P2 = GameObject.FindGameObjectWithTag("P2");
        //animP1 = P1.GetComponent<Animator>();
        //animP2 = P2.GetComponent<Animator>();

        GenerarPowerUp();
       MoverGenerador();
        //MainCam.transform.position = Vector3.Slerp(MainCam.transform.position, cameras[CurrentLevel].transform.position, t);
		for(int i = 0; i < spawns.Length; i++)
		{
			if(i == CurrentLevel)
			{
				spawns[i].SetActive(true);
			}
			else
			{
				spawns[i].SetActive(false);
			}
		}
        if (SceneChangeManager.freezCamera)
        {
            CameraCube.transform.position = Vector3.Lerp(CameraCube.transform.position, cameraPositions[CurrentLevel].position, t);
        }
		if (SceneChangeManager.cambioScena)
		{
            Debug.Log("CambaEscena");
            HealManager.vidaP1 = HealManager.vidaMaxima;
            HealManager.vidaP2 = HealManager.vidaMaxima;
            spawn1 = spawns[CurrentLevel].transform.Find("spawnP1").transform.position;
            spawn2 = spawns[CurrentLevel].transform.Find("spawnP2").transform.position;
            generador.position = spawn1;
            rbGenerador.velocity = new Vector3(6, 0, 0);
            P1.transform.position = new Vector3(0, -100, 0);
            P2.transform.position = new Vector3(0, -100, 0);
			SceneChangeManager.cambioScena = false;
            if (currentPowerUp != null)
            {
                PowerUpsBase pb = currentPowerUp.GetComponent<PowerUpsBase>();
                if (pb.isParented == false)
                {
                    Destroy(currentPowerUp);
                }
                currentPowerUp = null;
            }
           
            Invoke("SpawnPlayers", 1.5f);
           
            
            
            
		}

	}
    void MoverGenerador()
    {
		generador.position = new Vector3(generador.position.x, 26, 0);
        if (generador.position.x >= spawn2.x)
        {
            rbGenerador.velocity = new Vector3(-6, 0, 0);
        }
        else if (generador.position.x <= spawn1.x)
        {
            rbGenerador.velocity = new Vector3(6, 0, 0);
        }
    }
    void GenerarPowerUp()
    {

		if(currentPowerUp == null)
		{
			tiempoRandom -= Time.deltaTime;
		}
        
        int indicePowerUp = Random.Range(0, 3);
        if(tiempoRandom < 0)
		{
			if (currentPowerUp == null)
			{
				currentPowerUp = Instantiate(powerUps[indicePowerUp], generador.transform.position, Quaternion.identity);
			}
			tiempoRandom = Random.Range(7, 15);
		}

       
    }
    void SpawnPlayers()
    {
       // P1 =
        Debug.Log("spawn");
       
        P1.transform.position = spawn1;
        P2.transform.position = spawn2;
        Instantiate(spawnParticles1, P1.transform.position + new Vector3(0,-1.5f,0), spawnParticles1.transform.rotation);
        Instantiate(spawnParticles2, P2.transform.position + new Vector3(0, -1.5f, 0), spawnParticles1.transform.rotation);
        SceneChangeManager.freezCamera = false;
    }
    
}
