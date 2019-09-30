using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIcon : MonoBehaviour {
    public HeroesInstanceManager Players;
    public PlayerSpawnManagerAtTheBeginningOfTheScene EachPlayer;
    public GameObject[] PowerUpicons1;
    public GameObject[] PowerUpicons2;
    public GameObject P1;
    public GameObject P2;
    public GameObject Cur_Power1;
    public GameObject Cur_Power2;
   
    void Start()
    {


        for (int i = 0; i < PowerUpicons1.Length; i++)
        {
            PowerUpicons1[i].SetActive(false);
        }

        for (int i = 0; i < PowerUpicons2.Length; i++)
        {
            PowerUpicons2[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        GameObject objetoconscript = GameObject.Find("Game Manager");
        GameObject objetoconscript2 = GameObject.Find("GameManager");
        Players = objetoconscript.GetComponent<HeroesInstanceManager>();
        EachPlayer = objetoconscript2.GetComponent<PlayerSpawnManagerAtTheBeginningOfTheScene>();
        //P1 = Players.playerOne;
        //P2 = Players.playerTwo;

        P1 = EachPlayer.J1.gameObject;
        P2 = EachPlayer.J2.gameObject;

        DetectObject1();
        DetectObject2();
      
    }

    public void DetectObject1()
    {
        try
        {
            Cur_Power1 = P1.GetComponentInChildren<PowerUpsBase>().gameObject;
        }
        catch
        {
            for (int i = 0; i < PowerUpicons1.Length; i++)
            {
                PowerUpicons1[i].SetActive(false);

            }




        }


        if (Cur_Power1 != null)
        {
            switch (Cur_Power1.name)
            {
                case "Ventilador(Clone)":
                    for (int i = 0; i < PowerUpicons1.Length; i++)
                    {
                        PowerUpicons1[i].SetActive(false);
                        PowerUpicons1[0].SetActive(true);
                    }

                    break;

                case "SnowBallGun(Clone)":
                    for (int i = 0; i < PowerUpicons1.Length; i++)
                    {
                        PowerUpicons1[i].SetActive(false);
                        PowerUpicons1[1].SetActive(true);
                    }
                    break;

                case "bomba(Clone)":
                    for (int i = 0; i < PowerUpicons1.Length; i++)
                    {
                        PowerUpicons1[i].SetActive(false);
                        PowerUpicons1[2].SetActive(true);
                    }
                    break;

            }
        }
        
    }

    public void DetectObject2()
    {
        
        try
        {
            Cur_Power2 = P2.GetComponentInChildren<PowerUpsBase>().gameObject;
        }
        catch
        {
            for (int i = 0; i < PowerUpicons2.Length; i++)
            {
                PowerUpicons2[i].SetActive(false);

            }
           


        }
        if (Cur_Power2 != null)
        {
            switch (Cur_Power2.name)
            {
                case "Ventilador(Clone)":
                    for (int i = 0; i < PowerUpicons2.Length; i++)
                    {
                        PowerUpicons2[i].SetActive(false);
                        PowerUpicons2[0].SetActive(true);
                    }

                    break;

                case "SnowBallGun(Clone)":
                    for (int i = 0; i < PowerUpicons2.Length; i++)
                    {
                        PowerUpicons2[i].SetActive(false);
                        PowerUpicons2[1].SetActive(true);
                    }
                    break;

                case "bomba(Clone)":
                    for (int i = 0; i < PowerUpicons2.Length; i++)
                    {
                        PowerUpicons2[i].SetActive(false);
                        PowerUpicons2[2].SetActive(true);
                    }
                    break;

            }
        }

    }
}

