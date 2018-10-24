using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seleccionarPiso : MonoBehaviour {

	//texto informativo
    public Text textoMostrar;
	public int numeroTerrenos;
	//dropdowns
	public Dropdown dropdown;
	List<string> terrenos = new List<string>() { "Selecciona","Lava", "Agua", "Campo", "Muro", "Tierra", "Hielo", "Madera", "Montaña", "Ladrillo" };


    // Use this for initialization
    void Start () {
		//mostrar número de terrenos
		numeroTerrenos = GameManager.numeroTerrenosG;
        textoMostrar.text = numeroTerrenos + " tipos de terrenos encontrados ";
        //rellenar dropdowns
        rellenarDropdowns();



    }

	void rellenarDropdowns(){
		dropdown.AddOptions(terrenos);
		
	}

	public void obtenerValorDropdown(int index){
		Debug.Log(terrenos[index]);
	}
	
	
	


}
