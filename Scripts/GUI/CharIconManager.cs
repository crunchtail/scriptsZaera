using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharIconManager : MonoBehaviour {
    public HeroesInstanceManager Players;
    public GameObject[] icons;
    public bool playerTwo;
    public string name1;
    public string name2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GameObject objetoconscript = GameObject.Find("Game Manager");

        Players = objetoconscript.GetComponent<HeroesInstanceManager>();

        name1 = Players.playerOne.name;
        name2 = Players.playerTwo.name;


        if (!playerTwo)
        {
            for (int i = 0; i < icons.Length; i++)
            {
                if (name1 == "ZAERA_RIGGEADO")
                {
                    icons[i].SetActive(false);
                    icons[0].SetActive(true);
                }

                if (name1 == "BONSITO_RIGGEADO 1")
                {
                    icons[i].SetActive(false);
                    icons[1].SetActive(true);
                }

                if (name1 == "Panda BAMBU 1")
                {
                    icons[i].SetActive(false);
                    icons[2].SetActive(true);
                }

                if (name1 == "LOBO RAGNA 1")
                {
                    icons[i].SetActive(false);
                    icons[3].SetActive(true);
                }

            }

        }
        else
        {
            for (int i = 0; i < icons.Length; i++)
            {
                if (name2 == "ZAERA_RIGGEADO")
                {
                    icons[i].SetActive(false);
                    icons[0].SetActive(true);
                }

                if (name2 == "BONSITO_RIGGEADO 1")
                {
                    icons[i].SetActive(false);
                    icons[1].SetActive(true);
                }

                if (name2 == "Panda BAMBU 1")
                {
                    icons[i].SetActive(false);
                    icons[2].SetActive(true);
                }

                if (name2 == "LOBO RAGNA 1")
                {
                    icons[i].SetActive(false);
                    icons[3].SetActive(true);
                }

            }
        }
    }
}
