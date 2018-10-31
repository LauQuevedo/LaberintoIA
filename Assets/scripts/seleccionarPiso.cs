using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seleccionarPiso : MonoBehaviour {

	//texto informativo
    public Text textoMostrar;
    public Text numero_codigos;
    public int numeroTerrenos;
    public List<int> listaTerrenosId = new List<int>();
    //dropdowns
    List<string> terrenos = new List<string>() { "Selecciona", "Lava", "Agua", "Campo", "Muro", "Tierra", "Hielo", "Madera", "Montaña", "Ladrillo" };

    public Dropdown dropdown0;
    public Dropdown dropdown1;
    public Dropdown dropdown2;
    public Dropdown dropdown3;
    public Dropdown dropdown4;
    public Dropdown dropdown5;
    public Dropdown dropdown6;
    public Dropdown dropdown7;
    public Dropdown dropdown8;
	public Dropdown dropdown9;


    // Use this for initialization
    void Start () {
		//mostrar número de terrenos
		numeroTerrenos = GameManager.numeroTerrenosG;
        textoMostrar.text = numeroTerrenos + " tipos de terrenos encontrados ";
        //mostrar código
        listaTerrenosId = GameManager.listaTerrenosId;
        Debug.Log(listaTerrenosId);
        foreach (int el in listaTerrenosId){
			Debug.Log(el);
    	}

	


        numero_codigos.text = "1\n2\n3\n4\n";
		//mostrar dropdowns 
		mostrarDropdown(numeroTerrenos);
        //rellenar dropdowns
        rellenarDropdowns();


        //Añadir listener para valor de dropdowns
        dropdown0.onValueChanged.AddListener(delegate{
            obtenerValorDropdown(dropdown0);
        });

 

    }

	void mostrarDropdown(int numeroTerrenos){

		for(int i=0; i<numeroTerrenos; i++){
			switch(i){
				case 0:
                    dropdown0.gameObject.SetActive(true);
                    break;
                case 1:
					dropdown1.gameObject.SetActive(true);
                    break;
				case 2:
					dropdown2.gameObject.SetActive(true);
					break;
				case 3:
					dropdown3.gameObject.SetActive(true);
                    break;
                case 4:
					dropdown4.gameObject.SetActive(true);
                    break;	
				case 5:
                    dropdown5.gameObject.SetActive(true);
                    break;
                case 6:
                    dropdown6.gameObject.SetActive(true);
                    break;
                case 7:
                    dropdown7.gameObject.SetActive(true);
                    break;
                case 8:
                    dropdown8.gameObject.SetActive(true);
                    break;
                case 9:
                    dropdown9.gameObject.SetActive(true);
                    break;

				default: break;
			}
			
			
			// Debug.Log(text);
		}
        // ButtonContinuar.SetActive(true);
	}

    void obtenerValorDropdown(Dropdown change){
		Debug.Log("New Value : " + change.value);
    }


	

	void rellenarDropdowns(){
		dropdown0.AddOptions(terrenos);
		
	}

	
	
	
	


}
