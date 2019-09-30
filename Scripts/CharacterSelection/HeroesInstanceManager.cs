using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class HeroesInstanceManager : MonoBehaviour {

    //1.- Patron singleton

    //el patron singleton es un truco de magia de programación, para acceder mas facilmente a este componente desde otros scripts

    //Se basa en el hechizo de nivel 1 "static". Una clase estática no se puede instanciar, porque significa que siempre va a haber una instancia creada de esta clase, solo una.

    public static HeroesInstanceManager instance; //<-- Esta referencia es el acceso al script "estatico"

    public GameObject playerOne;
    public GameObject playerTwo;

    public string playerOneName;
    public string playerTwoName;

    public GameObject Winner;
    public GameObject Loser;

    public string WinnerName;
    public string LoserName;


    #region SingleTon
    //public static SpawnManager instance;


    // Use this for initialization
    private void Awake()
    {
        //Establecer el valor de la referencia estatica
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }

        //2. GameObject.DontDestroyOnLoad() -- Marca el gameObject para que no se destruya cuando "flushee" la escena
        DontDestroyOnLoad(this.gameObject);



       // DontDestroyOnLoad(player2);
    }
    #endregion
    //public Heroe player;
    //public Heroe player2;
    //public CharacterSelectionManager playerOne;
    //public Character2SelectionManager playerTwo;

    //public void Start()
    //{
    //    player = playerOne.ChosenOne;
    //    player2 = playerTwo.ChosenTwo;

        
        
    //}

}
