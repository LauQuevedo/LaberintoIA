using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class GetCoordenadas : MonoBehaviour {
	//variables globales
    public int v_filaInicio = 0;
    public int v_columnaInicio = 0;
    public int v_filaFinal = 0;
    public int v_columnaFinal = 0;
    public int v_filaBus = 0;

    private GameManager gameManager;

    void Awake(){
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    // Use this for initialization
    void Start () {
        	
	}

    // ----------------------------  ESCENA SELECCIÓN DE INICIO Y FINAL   ----------------------------------- 
    public InputField filaBuscar;
    public InputField ColBuscar;
    public InputField filaInicio;
    public InputField columnaInicio;
    public InputField filaFinal;
    public InputField columnaFinal;
    public Text textoPermiso; //muestra 
    // public Text textoSimetria;

    List<string> columnasAbc = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" };

    public void setgetCoordenadas(){
        bool coincide = true;
        int filaInt = 0, filaFinalInt = 0;

        if (filaInicio.text != "" && columnaInicio.text != "" && filaFinal.text != "" && columnaFinal.text != "")
        {
            //definir coordenadas
            filaInt = Int32.Parse(filaInicio.text);
            v_filaInicio = filaInt;

            filaFinalInt = Int32.Parse(filaFinal.text);
            v_filaFinal = filaFinalInt;
            //corroborar que se pueda pisar ese terreno
            Debug.Log("inicio: " + v_filaInicio + "," + columnaInicio.text + "\ncoordenadas final: " + v_filaFinal + "," + columnaFinal.text);

            //mostrar valores si son correctos
            // if((v_filaInicio != v_filaFinal) && (columnaInicio.text != columnaFinal.text)){
                coincide = true;
                textoPermiso.text = "Coordenadas inicio: " + v_filaInicio + "," + columnaInicio.text + "\nCoordenadas final: " + v_filaFinal + "," + columnaFinal.text;
                gameManager.isInicioFinGood(coincide, v_filaInicio, v_filaFinal, columnaInicio.text, columnaFinal.text);

            // }else{
            //     coincide = false;
            //     textoPermiso.text = "Es la misma coordenada, elige otra";
            //     gameManager.isInicioFinGood(coincide, 0, 0, "A", "A");

            // }
			
            //mostrar botón para continuar


            // SceneManager.LoadScene(4);
        }else{
            textoPermiso.text = "Tienes que ingresar todos los datos";
            coincide = false;
            gameManager.isInicioFinGood(coincide, v_filaInicio, v_filaFinal, columnaInicio.text, columnaFinal.text);

        }
    }

    public void cambiarEscenaC(){
        SceneManager.LoadScene(4); //cambiar a la implementación del Board
    }

    /* MISSING:
    - Aceptar en columnas valores alfabeticos y castearlos a numerico
    - Corroborar con datos del personaje si es posible que esas coordenadas sean inicio y final
    */
 public void Buscar()
    {

        if (filaBuscar.text != "" && ColBuscar.text != "")
        {
            //definir coordenadas
            int filaIntBus = Int32.Parse(filaBuscar.text);
            v_filaBus = filaIntBus;
            //columnas

            //corroborar que los valores sean válidos



            //mostrar valores si son correctos
            textoPermiso.text = "coordenadas Ingresadas: " + v_filaBus + "," + ColBuscar.text ;
			
            //mostrar botón para continuar


            // SceneManager.LoadScene(4);



        }
        else
        {
            textoPermiso.text = "Tienes que ingresar todos los datos";
        }

    }

}
