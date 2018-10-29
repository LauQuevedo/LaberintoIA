using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

//Equipo 7

public class BoardManager : Seleccion {
    
    [Serializable]
    public class Count{
        public int minimo;
        public int maximo;

        //constructor asignable
        public Count(int min, int max){ 
            minimo = min;
            maximo = max;
        }
    }

    //inicialización de variables para dimensión de gameboard
   
   
   public string texto;
   
    public VariablesGlobales variablesGlobales;
    public int tam = 0; //variable enviada a Variables globales al inicio

    public int numTerrenos = 0;
    public int personajeSeleccionado = 0;
    //VARIABLES to hold los prefabs que irán en el tablero
    public GameObject exit;
    public GameObject inicio;
    public GameObject[] player;
    public GameObject paredExterior;
    //escoger terrenos
    public GameObject lava;
    public GameObject agua;
    public GameObject campo;
    public GameObject muro;
    public GameObject tierra;
    public GameObject hielo;
    public GameObject madera;
    public GameObject montana;
    public GameObject ladrillo;
    public GameObject[] terrenosRandom;
    public GameObject[] floors;
    public GameObject Info;
    
    //delimitar el board
    private Transform boardHolder;


    ///// de subirMapa.cs
    public int columnas;
    public int filas;
    // public bool isGood = false;
    public List<int> listaTerrenosId = new List<int>();
    List<int> listaTerrenosCoord = new List<int>();


    ////////////
    //especificar rango para paredes
    public Count wallCount = new Count(5, 9);
    //track de todas las posibles posiciones, y si un objeto está en esa posición o no
    private List<Vector3> gridPositions = new List<Vector3>();


    protected int personajeSelection;

    
    // -----------------------------------  ESCENA SELECCIÓN DE TERRENOS   ----------------------------------- 

    // public Dropdown dropdown;

    // public void Dropdown_IndexChanged(int index)
    // {

    // }
    // void Start()
    // {
    //     PopulateList();
    // }

    // void PopulateList()
    // {
    //     List<string> terrenos = new List<string>() { "lava", "agua", "campo", "muro", "tierra", "hielo", "madera", "montana", "ladrillo" };
    //     dropdown.AddOptions(terrenos);
    // }

    // ----------------------------  ESCENA SELECCION DE PISO   ----------------------------------- 
    public Text noPisos;
    public InputField noFilas;

    //public void Awake(){
        //setValuesInfo();
        // setPersonajeValue();
        // Debug.Log("characterValue: " + myCharacterValue);
   // }
   
    void setValuesInfo(){
        noPisos.text = "holaaa";
    }








    // -----------------------------------  INSTANCIA DE TABLERO   ----------------------------------- 

    void InicializarLista(){
        gridPositions.Clear();
        //llenar lista con posibles posiciones para el tablero
        for (int x = 1; x < columnas -1; x++){
            for (int y = 1; y < filas -1; y++){
                //posibles posiciones para poner cosas
                gridPositions.Add(new Vector3(x, y, 0f)); //añadir valores de x,y a la lista
            }
         }
    }



    //definición de pared exteriores y floor
    void BoardSetup(){
        boardHolder = new GameObject("Board").transform;
        //valores negativos y suma para pintar borde   
        Debug.Log("columnas: "+columnas+", filas:"+filas);


        for (int x = -1; x < columnas + 1; x++){
            for (int y = -1; y < filas + 1; y++ ){
                //instanciar terrenos como piso
                GameObject toInstantiate = terrenosRandom[Random.Range(0, terrenosRandom.Length)];
                
                foreach(int coord in listaTerrenosCoord){

                }   
                //checar e instanciar paredes exteriores
                if (x == -1 || x == columnas || y == -1 || y == filas ){
                    //instanciar randomly paredes
                    toInstantiate = paredExterior;
                    //toInstantiate = paredes[Random.Range(0, paredes.Length)];
                }
                //quaternion signfica sin rotación
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    //posicionar objetos en el tablero
    void LayoutTerrenos(GameObject tipoTerreno){

        //Instantiate(tipoTerreno)

    }

	// Use this for initialization
    public void SetupScene(){
        BoardSetup();
        InicializarLista();
        //LayoutTerrenos(); //falta implementarlo

        //posicionar el final
        Instantiate(inicio, new Vector3(0, 0, 0f), Quaternion.identity);
        Instantiate(exit, new Vector3(columnas - 1, filas - 1, 0f), Quaternion.identity);
    }

     void Update(){
        // tam=variablesGlobales.Tam;
        // listaTerrenosId=variablesGlobales.IdTerrenos;
        // personajeSeleccionado=variablesGlobales.Personaje;
        // Debug.Log("helloo"+listaTerrenosId[2]);
    }
}