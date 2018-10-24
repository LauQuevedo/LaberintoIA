using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariablesGlobales : MonoBehaviour {
	public BoardManager broadManager; 

	public int Tam;
	public int Personaje;
	public List<int>IdTerrenos=new List<int>();


	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	void Update() {
		//Personaje=broadManager.personajeSeleccionado;
		//Tam=broadManager.tam;
		//IdTerrenos=broadManager.listaTerrenosId;
		//Debug.Log("helloo"+broadManager.listaTerrenosId[2]);
    
	}

}