using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;


public class subirMapa : MonoBehaviour {

    //instancia de GameManager.cs
	private GameManager gameManager;
    public int tam = 0; //variable enviada a Variables glovales al inicio
    public int columnas, filas, numeroTerrenos;
    public List<int> listaTerrenosId = new List<int>();
    List<int> listaTerrenosCoord = new List<int>();

	void Awake(){
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}

    // -----------------------------------  LECTURA DE TXT   ----------------------------------- 

    //explorer para seleccionar el txt desde el botón de una escena
    public void OpenExplorer()
    {


        //inicializar lista
        if(listaTerrenosId.Any()){
            listaTerrenosId.Clear();
        }
        

        string path = EditorUtility.OpenFilePanel("Overwrite with txt", "", "txt");
        if (path != null)
        {
            //Debug.Log(path);
            comprobarTamTablero(path);
        }
    }

    void comprobarTamTablero(string path)
    {
        StreamReader reader = new StreamReader(path);
        string textColumnas = " ";
        string[] tamColumnas;
    	string[] tamColumnasBase; //usada por verificarTamTablero()
		bool coincide = true;
        Debug.Log("Ruta: " + path);
        //leer filas
        string[] filas = File.ReadAllLines(path);
        // leer primera fila y obtener tamaño
        textColumnas = reader.ReadLine();
        tamColumnasBase = textColumnas.Split(',');

        //leer filas de todo el archivo
        while (textColumnas != null)
        {
            //dividir según delimitador
            tamColumnas = textColumnas.Split(',');
            //coincidencia entre tamaño de lineas
            if (tamColumnas.Length != tamColumnasBase.Length)
			{
                coincide = false;
                break;
            }
            //leer siguiente línea
            textColumnas = reader.ReadLine();
        }

        //si coincide tamaño rectangular
        if (coincide)
        { 
            Debug.Log("Si es rectangular: " + filas.Length + "x" + tamColumnasBase.Length);
            LecturaTxt(path);
            //tamanoTablero(filas.Length);
            // textoPermiso.text = "Tienes que ingresar todos los datos";
            //retornar # de terrenos 
            numeroTerrenos = numTerrenosMetodo();
            gameManager.isTxtGood(coincide, filas, tamColumnasBase, numeroTerrenos, listaTerrenosId);

            //SceneManager.LoadScene(+1);
        }
        else
        {
            // textoPermiso.text = "Tienes que ingresar todos los datos";
            gameManager.isTxtGood(coincide, filas, tamColumnasBase, 0, listaTerrenosId);
            
            Debug.Log("No coinciden dimensiones de terreno, intentelo de nuevo");
        }
    }

    

    //retornar valor de fila y columna
    int tamanoTablero(int tamano)
    {
        //asignación a variables globales
        columnas = tamano;
        filas = tamano;
        tam = tamano;
        //Debug.Log("el tamaño es" + tam);
        return tamano;
    }


    //Método obtiene id y número de terrenos 
    void LecturaTxt(string path)
    {
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

}
