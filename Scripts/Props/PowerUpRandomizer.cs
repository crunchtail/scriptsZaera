using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRandomizer : MonoBehaviour {
    public GameObject[] powerUps;
    public int cur_index;
    public GameObject position;
    public bool puedoInstanciar = true;
    public float time;
	GameObject currentPowerUP;
	bool cooldown = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(cooldown && currentPowerUP!= null)
		{
			puedoInstanciar = true;
		}
        if(puedoInstanciar == true)
        StartCoroutine(GenerateRandom());
	}

    public IEnumerator GenerateRandom()
    {
        puedoInstanciar = false;

        yield return new WaitForSeconds(time);

        int dado = Random.Range(0, 5);

        cur_index = dado;

            for (int i = 0; i < 1; i++)
            {
              currentPowerUP = Instantiate(powerUps[cur_index], position.transform.position, Quaternion.identity);
            }

        cooldown = true;
        }
    }



