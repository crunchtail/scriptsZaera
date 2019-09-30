using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.PostProcessing;

public class postProcessingLibrary : MonoBehaviour {

	public PostProcessingProfile[] processingIndex;

	PostProcessingBehaviour postprocesador;


	// Use this for initialization
	void Start () {
		postprocesador = GetComponent<PostProcessingBehaviour> ();


	}
	


	public void changePostProcessor(int index){

		try{
			postprocesador.profile = processingIndex [index];

		}catch (System.Exception ex){
			Debug.LogError (ex.Message);
		}
	}
}
