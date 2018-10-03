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
    public VariablesGlobales variablesGlobales; 

    public int tam=0; //variable enviada a Variables glovales al inicio
    public int columnas;
    public int filas;
    public int v_filaInicio = 0;
    public int v_columnaInicio = 0;
    public int v_filaFinal = 0;
    public int v_columnaFinal = 0;
    public int numTerrenos = 0;
    public bool isGood = false;
    public int personajeSeleccionado = 0;
    public string[] tamColumnas; //usada por verificarTamTablero()
    public List<int> listaTerrenosId = new List<int>();
    List<int> listaTerrenosCoord = new List<int>();
    //VARIABLES to hold los prefabs que irán en el tablero
    public GameObject exit;
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


    //delimitar el board
    private Transform boardHolder;

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

    // ----------------------------  ESCENA SELECCIÓN DE INICIO Y FINAL   ----------------------------------- 
    public InputField filaInicio;
    public InputField columnaInicio;
    public InputField filaFinal;
    public InputField columnaFinal;
    public Text textoPermiso; //muestra 
    public Text textoSimetria;

    List<string> columnasAbc = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O"};

    public void setgetCoordenadas(){

        if(filaInicio.text != "" && columnaInicio.text != "" && filaFinal.text != "" && columnaFinal.text != ""){
            //definir coordenadas
            int filaInt = Int32.Parse(filaInicio.text);
            v_filaInicio = filaInt;
            int filaFinalInt = Int32.Parse(filaFinal.text);
            v_filaFinal  = filaFinalInt;
            //columnas

            if(columnasAbc.Contains(columnaInicio.text)){ // Contains(InputEscena.text) columnaInicio y columnaFinal
                //evitar case sentivity para ponerlos mayusculas
                //comparar con lista columnasAbc para obtener su indice
                //y guardarlo en v_columnaFinal/Inicio el indice
            }

            // y después v_columnaFinal/Inicio = variableInt;

            //no hacer caso
            // int columnaInt = Int32.Parse(columnaInicio.text);
            // v_columnaInicio = columnaInt;

            // int columnaFinalInt = Int32.Parse(columnaFinal.text);
            // v_columnaFinal = columnaFinalInt;


            textoPermiso.text = "coordenadas inicio: " + v_filaInicio + "," + v_columnaInicio+ "\ncoordenadas final: " + v_filaFinal + "," + v_columnaFinal;
            SceneManager.LoadScene(4);

        }else{
            textoPermiso.text = "Tienes que ingresar todos los datos";
        }
        
    }

    /* MISSING:
    - Aceptar en columnas valores alfabeticos y castearlos a numerico
    - Corroborar con datos del persona si es posible que esas coordenadas sean inicio y final
    */

    


    // -----------------------------------  LECTURA DE TXT   ----------------------------------- 

    //explorer para seleccionar el txt desde el botón de una escena
    public void OpenExplorer(){
        string path = EditorUtility.OpenFilePanel("Overwrite with txt", "", "txt");
        if (path != null){
            //Debug.Log(path);
            comprobarTamTablero(path);
        }
    }

    void comprobarTamTablero(string path){
        StreamReader reader = new StreamReader(path);
        string text = " ";
        bool coincide = true;
        Debug.Log("Ruta: " + path);
        //leer filas
        string[] filas = File.ReadAllLines(path);
        // leer primera fila
        text = reader.ReadLine();

        //leer filas de todo el archivo
        while (text != null)
        {
            //dividir según delimitador
            tamColumnas = text.Split(',');
            //coincidencia
            if (tamColumnas.Length != filas.Length)
            {
                coincide = false;
                break;
            }
            //leer siguiente línea
            text = reader.ReadLine();
        }

        if (coincide)
        { //si coinciden filasXcolumnas
            Debug.Log("Si es simétrico: " + filas.Length + "x" + tamColumnas.Length);
            LecturaTxt(path);
            tamanoTablero(filas.Length);
           // textoPermiso.text = "Tienes que ingresar todos los datos";
            isGood = true;
            SceneManager.LoadScene(+1);
        }
        else
        {
           // textoPermiso.text = "Tienes que ingresar todos los datos";
            isGood = false;
            Debug.Log("No coinciden dimensiones de terreno, intentelo de nuevo");
        }
    }

    public void isTxtGood(){
        Debug.Log("helloo");
        if(isGood){
            Debug.Log("siiii");
            textoPermiso.text = "Todo bien";
        }
        else
        {
            Debug.Log("noooo");
            textoPermiso.text = "Tienes que ingresar todos los datos";
        }
        
    }

    //retornar valor de fila y columna
    int tamanoTablero(int tamano){
        //asignación a variables globales
        columnas = tamano;
        filas = tamano;
        tam=tamano;
         //Debug.Log("el tamaño es" + tam);
        return tamano;
    }


    //Método obtiene id y número de terrenos 
    void LecturaTxt(string path){
        //leer archivo
        StreamReader reader = new StreamReader(path);
        string text = " ";
        //Debug.Log(reader.ReadToEnd());
        //otras variables
        string[] celdas;

        // leer primera linea
        text = reader.ReadLine(); //primera fila
        //leer todo el archivo
        while (text != null)
        {
            //dividir según delimitador
            celdas = text.Split(',');
            //leer cada valor ya dividido por delimitador coma
            for (int i = 0; i < celdas.Length; i++)
            {
                int celdaCasteo = Int32.Parse(celdas[i]);
                //1. almacenar celda en lista total de los terrenos
                listaTerrenosCoord.Add(celdaCasteo);
                //2. almacenar id de terrenos (si no hay coincidencia previa)
                compararTerrenoId(celdaCasteo);
            }
            //leer siguiente línea
            text = reader.ReadLine();
        }
        //terminó de leer el archivo
        reader.Close();
        //retornar # de terrenos 
        numTerrenosMetodo();

        //convertir lista a arreglo
        // lista = listaColumnas.ToArray();
        // comprobarTamanoTablero(tamColumnas, filasTemp);
    }

    void compararTerrenoId(int id)
    {
        //insertar si no existe
        if (!listaTerrenosId.Contains(id))
            listaTerrenosId.Add(id);
    }

    int numTerrenosMetodo()
    {
        Debug.Log("Número de terrenos: " + listaTerrenosId.Count);
        return listaTerrenosId.Count;
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
        Instantiate(exit, new Vector3(columnas - 1, filas - 1, 0f), Quaternion.identity);
    }
     void Update(){
        tam=variablesGlobales.Tam;
        listaTerrenosId=variablesGlobales.IdTerrenos;
        personajeSeleccionado=variablesGlobales.Personaje;
        // Debug.Log("helloo"+listaTerrenosId[2]);
    }
}