using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GetCoordenadas : MonoBehaviour {
	//variables globales
    public int v_filaInicio = 0;
    public int v_columnaInicio = 0;
    public int v_filaFinal = 0;
    public int v_columnaFinal = 0;
    public int v_filaBus = 0;
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

    public void setgetCoordenadas()
    {

        if (filaInicio.text != "" && columnaInicio.text != "" && filaFinal.text != "" && columnaFinal.text != "")
        {
            //definir coordenadas
            int filaInt = Int32.Parse(filaInicio.text);
            v_filaInicio = filaInt;
            int filaFinalInt = Int32.Parse(filaFinal.text);
            v_filaFinal = filaFinalInt;
            //columnas

            //corroborar que los valores sean válidos



            //mostrar valores si son correctos
            textoPermiso.text = "coordenadas inicio: " + v_filaInicio + "," + columnaInicio.text + "\ncoordenadas final: " + v_filaFinal + "," + columnaFinal.text;
			
            //mostrar botón para continuar


            // SceneManager.LoadScene(4);



        }
        else
        {
            textoPermiso.text = "Tienes que ingresar todos los datos";
        }

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
