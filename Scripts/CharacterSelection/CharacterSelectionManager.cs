using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour {
	
    //public GameObject right, left, current;
    public Character2SelectionManager selection;
    public GameObject ruleta;
    public Vector3 targetRotation;
    public Vector3 curRotation;
    Vector3 velocity = Vector3.zero;

    public Material unselected;
    public Material selected;

    //Array de scriptable Objects --> A traves del SO, se accede al prefab a instanciar
    public Heroe[] Heroes;
    public Image[] names;
    public GameObject[] HeroImage;

    public int currentHeroIndex; //Heroe seleccionado

    public bool CanPress;
    public bool OneIsSelected;
    public bool TwoIsSelected;
    public float velocidadGiro;

    public Heroe ChosenOne;

    public Scene FirstScene;
    public string nextScene;
    public AudioSource miAudio, vozLobo, vozBonsito, vozZaera, vozPanda;

    public Animator[] charactersAnim;
	bool selected2;

    // Use this for initialization
    void Start () {
        currentHeroIndex = 0;
        CanPress = true;
        OneIsSelected = false;
        curRotation = new Vector3(0, ruleta.transform.localEulerAngles.y, 0);
        targetRotation = transform.localEulerAngles;
        UpdateHero();
       

    }
	
	// Update is called once per frame
	void Update () {
        TwoIsSelected = selection.TwoIsSelected;
        
        float axisValue = Input.GetAxisRaw("DPad_Hor");
        UpdateAnimations();
       if(selected2 == false)
		{
			if (axisValue != 0)
			{
				if ((axisValue > 0) && (CanPress))
				{
					miAudio.Play();
					CanPress = false;
					turnLeft();
					if (targetRotation.y == 270)
					{
						targetRotation.y = 0;
					}
					else
					{
						targetRotation = new Vector3(0, targetRotation.y + 90, 0);
					}

					//curRotation = targetRotation;
				}
				else if ((axisValue < 0) && (CanPress))
				{
					miAudio.Play();
					CanPress = false;
					turnRight();
					if (targetRotation.y == 0)
					{
						targetRotation.y = 270;
					}
					else
					{
						targetRotation = new Vector3(0, targetRotation.y - 90, 0);
					}



					//curRotation = targetRotation;

				}
			}
			else
			{
				CanPress = true;
			}
		}
       
        if(transform.localEulerAngles.y == targetRotation.y)
        {
            curRotation = targetRotation;
            
        }
        else
        {
            transform.localEulerAngles = Vector3.SmoothDamp(transform.localEulerAngles, targetRotation, ref velocity, velocidadGiro * Time.deltaTime);
        }
        if (Input.GetButtonDown("X"))
        {
            OneIsSelected = true;
			selected2 = true;
            if(currentHeroIndex == 3)
            {
                vozLobo.Play();
            }
            if (currentHeroIndex == 1)
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
                ChosenOne = Heroes[currentHeroIndex];
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
        currentHeroIndex = leftIndex();
        UpdateHero();

    }

    public void turnRight()
    {
        currentHeroIndex = rightIndex();

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

        //Le pasamos el objeto seleccionado al objeto persistente
        HeroesInstanceManager.instance.playerOne = Heroes[currentHeroIndex].Model;
        
    }
    void UpdateAnimations()
    {
        for (int i = 0; i < HeroImage.Length; i++)
        {
            if (i == currentHeroIndex)
            {
                charactersAnim[i].SetBool("isSelected", true);
            }
            else
            {
                charactersAnim[i].SetBool("isSelected", false);
            }
        }
    }

     public IEnumerator ChargeScene() 
    {
        yield return new WaitForSeconds(2.5f);
        
          SceneManager.LoadScene(nextScene);
        
    }
}
