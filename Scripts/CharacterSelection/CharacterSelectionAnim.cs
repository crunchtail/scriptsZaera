using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionAnim : MonoBehaviour {

    public Animator anim;
    public int HeroIndex;
    public CharacterSelectionManager ruleta1;
    public Character2SelectionManager ruleta2;
    public bool FirstPlayer;
    public bool SecondPlayer;
    public bool Selected;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        Selected = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Selected) 
        {
            anim.SetBool("IsSelected", true);
        }
        else
        {
            anim.SetBool("IsSelected", false);
        }

        if ((ruleta1.currentHeroIndex == HeroIndex) && (FirstPlayer))
        {
            if (ruleta1.OneIsSelected)
            {
                Selected = true;
            }
        }

       


        if ((ruleta2.currentHeroIndex == HeroIndex) && (SecondPlayer))
        {
            if (ruleta2.TwoIsSelected)
            {
                Selected = true;
            } 
        }


    }
}
