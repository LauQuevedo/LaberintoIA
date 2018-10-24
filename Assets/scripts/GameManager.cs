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
	//variables referentes a terreno
	private subirMapa subirMapa;
    public static int columnasG, filasG, numeroTerrenosG;
    //variables para colocar casilla inicio, fin
    public static int xFinal, xInicio, yFinal, yInicio; 

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

	void Start(){
        //inicializar variables
        columnasG = 0;
        filasG = 0;
        numeroTerrenosG = 0;
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
	
    // ----------------------------------------------------------------------------------
    // ---------------------------------- SUBIR TXT -------------------------------------
    // ----------------------------------------------------------------------------------

    public void isTxtGood(bool resultado, string[] filas, string[] columnas, int terrenos)
    {
        if (resultado)
        {
            //asignación de variables obtenidas a variable global de gameManager
            filasG = filas.Length;
            columnasG = columnas.Length;
            numeroTerrenosG = terrenos;
			//asignación de texto informativo en escena subirTxt
            textoTxtAceptado.text = "Tu laberinto es de " + filasG + "x" + columnasG + "\nIncluye " + numeroTerrenosG + " tipos de terrenos";
            ButtonContinuar.SetActive(true);
        }
        else
        {
            //asignación de texto informativo en escena subirTxt
            textoTxtAceptado.text = "El archivo txt no contiene un terreno rectangular";
            ButtonContinuar.SetActive(false);
        }
    }

    // ----------------------------------------------------------------------------------
    // -------------------------- COORDENADAS INICIO Y FIN ------------------------------
    // ----------------------------------------------------------------------------------
	public void isInicioFinGood(){
		
	}





    // ----------------------------------------------------------------------------------
    // -------------------------------- CAMBIAR ESCENA ----------------------------------
    // ----------------------------------------------------------------------------------
    public void cambiarEscena(){
        SceneManager.LoadScene(+1);
	}



}