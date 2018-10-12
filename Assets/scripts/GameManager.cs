using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public BoardManager boardScript;
	public int playerFoodPoints = 100;
	[HideInInspector] public bool playersTurn = true;

	private bool doingSetup;
	private int level = 1;

	//subir txt variables
    public Text textoTxtAceptado;
	public GameObject ButtonContinuar;


    // Use this for initialization
    void Awake () {
		if(instance == null){
			instance = this;
		}else if(instance != this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);

		boardScript = GetComponent<BoardManager>();
		InitGame();
	}

   

	private void OnLevelWasLoaded(int index){
		level++;
		InitGame();
	}

	void InitGame(){
		doingSetup = true;
		
		boardScript.SetupScene();
	}

	public void GameOver(){
		enabled = false;
		// levelText.text = "Tardaste tanto en recorrer todo el laberinto";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // SUBIR TXT
    public void isTxtGood(bool resultado, string[] filas, string[] columnas, int terrenos)
    {
        if (resultado)
        {
            textoTxtAceptado.text = "Tu laberinto es de " + filas.Length + "x" + columnas.Length + "\nIncluye " + terrenos + " tipos de terrenos";
            ButtonContinuar.SetActive(true);
        }
        else
        {
            Debug.Log("El archivo txt no contiene un terreno rectangular");
            textoTxtAceptado.text = "El archivo txt no contiene un terreno rectangular";
            ButtonContinuar.SetActive(false);
        }

    }
    // CAMBIAR DE ESCENA 
	public void cambiarEscena(){
        SceneManager.LoadScene(+1);
	}



}