using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character2SelectionManager : MonoBehaviour
{

    //public GameObject right, left, current;
    public CharacterSelectionManager selection;
    public GameObject ruleta;
    public Vector3 targetRotation;
    public Vector3 curRotation;
    Vector3 velocity = Vector3.zero;

    public Material unselected;
    public Material selected;

    public Heroe[] Heroes;
    public Image[] names;
    public GameObject[] HeroImage;
    public int currentHeroIndex;
    public bool CanPress;
    public bool OneIsSelected;
    public bool TwoIsSelected;
    public float velocidadGiro;
	bool selected2;
    public Heroe ChosenTwo;

    public Scene FirstScene;
    public string nextScene;
	float axisValue = 0;

	public AudioSource miAudio, vozLobo, vozBonsito, vozPanda, vozZaera;
    // Use this for initialization
    void Start()
    {
        currentHeroIndex = 0;
        CanPress = true;
        TwoIsSelected = false;
        curRotation = new Vector3(0, ruleta.transform.localEulerAngles.y, 0);
        targetRotation = transform.localEulerAngles;
        UpdateHero();
       
    }

    // Update is called once per frame
    void Update()
    {
        OneIsSelected = selection.OneIsSelected;
        curRotation = new Vector3(ruleta.transform.rotation.x, ruleta.transform.rotation.y, ruleta.transform.rotation.z);

        
		if (!selected2)
		{
			 axisValue = Input.GetAxisRaw("P2-DPad_Hor");
		}
        if (axisValue != 0)
        {
            if ((axisValue > 0) && (CanPress))
            {
                miAudio.Play();
                CanPress = false;
                turnRight();

                if (targetRotation.y == 270)
                {
                    targetRotation.y = 0;
                }
                else
                {
                    targetRotation = new Vector3(0, targetRotation.y + 90, 0);
                }


            }
            else if ((axisValue < 0) && (CanPress))
            {
                miAudio.Play();
                CanPress = false;
                turnLeft();

                if (targetRotation.y == 0)
                {
                    targetRotation.y = 270;
                }
                else
                {
                    targetRotation = new Vector3(0, targetRotation.y - 90, 0);
                }


            }
        }
        else
        {
            CanPress = true;
        }
        if (transform.localEulerAngles.y == targetRotation.y)
        {
            curRotation = targetRotation;

        }
        else
        {
            transform.localEulerAngles = Vector3.SmoothDamp(transform.localEulerAngles, targetRotation, ref velocity, velocidadGiro * Time.deltaTime);
        }
        if (Input.GetButtonDown("P2-X"))
        {
            TwoIsSelected = true;
			selected2 = true;
            if(currentHeroIndex == 3)
            {
                vozLobo.Play();
            }
            if(currentHeroIndex == 1)
            {
                vozBonsito.Play();
            }
			if (currentHeroIndex == 2)
			{
				vozPanda.Play();
			}
			if (currentHeroIndex == 0)
			{
				vozZaera.Play();
			}
			if ((TwoIsSelected) && (OneIsSelected))
            {
                ChosenTwo = Heroes[currentHeroIndex];

                StartCoroutine(ChargeScene());
            }
        }


    }

    public void FixedUpdate()
    {
        Vector3 pointToLookAt = new Vector3(ruleta.transform.position.x, ruleta.transform.position.y, ruleta.transform.position.z);

        if (pointToLookAt != ruleta.transform.position)
            ruleta.transform.rotation = Quaternion.Slerp(ruleta.transform.rotation, Quaternion.LookRotation(pointToLookAt - ruleta.transform.position, Vector3.up), 1f);
    }


    public void turnLeft()
    {
        currentHeroIndex = rightIndex(); 
        UpdateHero();

    }

    public void turnRight()
    {
        currentHeroIndex = leftIndex();
        UpdateHero();
    }



    public int rightIndex()
    {
        return (currentHeroIndex == Heroes.Length - 1) ? 0 : currentHeroIndex + 1;

    }

    public int leftIndex()
    {
        return (currentHeroIndex == 0) ? Heroes.Length - 1 : currentHeroIndex - 1;
    }

    public void UpdateHero()
    {
        for (int i = 0; i < HeroImage.Length; i++)
        {
            HeroImage[i].GetComponent<Renderer>().material = unselected;
            names[i].enabled = false;
        }

        HeroImage[currentHeroIndex].GetComponent<Renderer>().material = selected;
        names[currentHeroIndex].enabled = true;

        HeroesInstanceManager.instance.playerTwo = Heroes[currentHeroIndex].Model;
    }

    public IEnumerator ChargeScene() 
    {
        yield return new WaitForSeconds(2.5f);
        
          SceneManager.LoadScene(nextScene);
        
    }
}
