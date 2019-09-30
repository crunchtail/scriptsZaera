using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Estas líneaas se llaman "metadato", porque no están para que se jecuten en tiempo de ejecución, sirven para darle información a otra cosa
//que este uilizando este recurso
[System.Serializable]// <<-- Este informa al sistema de .Net de como debe "serializar" este recurso
[CreateAssetMenu(fileName = "New Heroe", menuName = "Character/New Character")] //<-- esta informando al editor de Unity

//3.- Scriptable Objects: Es un script, que se trata como  un asset --> se guarda en el disco duro como un fichero
public class Heroe : ScriptableObject
{
    public GameObject Model;


    public int AnimatorIndex;


}