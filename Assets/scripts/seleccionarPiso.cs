using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    Scene m_Scene;


    void Awake(){
        
        //mostrar número de terrenos
        numeroTerrenos = GameManager.numeroTerrenosG;


        //mostrar código
        listaTerrenosId = GameManager.listaTerrenosId;
        // Debug.Log(listaTerrenosId);
        // foreach (int el in listaTerrenosId){
        //     Debug.Log(el);
        // }
        textoMostrar.text = numeroTerrenos + " tipos de terrenos encontrados "; 
        numero_codigos.text = "1\n2\n3\n4\n";


        

        
    }


    // Use this for initialization
    void Start () {
        //mostrar dropdowns 
        mostrarDropdown(numeroTerrenos);
        //rellenar dropdowns
        rellenarDropdowns();

        //Añadir listener para valor de dropdowns
        dropdown0.onValueChanged.AddListener(delegate
        {
            obtenerValorDropdown(dropdown0);
        });

        m_Scene = SceneManager.GetActiveScene();
        Debug.Log(m_Scene.name);

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

    public void obtenerValorDropdown(Dropdown change){
		Debug.Log("New Value : " + change.value);
    }


	

	void rellenarDropdowns(){
		dropdown0.AddOptions(terrenos);
        dropdown1.AddOptions(terrenos);
        dropdown2.AddOptions(terrenos);
        dropdown3.AddOptions(terrenos);
        dropdown4.AddOptions(terrenos);
        dropdown5.AddOptions(terrenos);
        dropdown6.AddOptions(terrenos);
        dropdown7.AddOptions(terrenos);
        dropdown8.AddOptions(terrenos);
        dropdown9.AddOptions(terrenos);
	}

    public void cambiarEscena(){
        //cambiar a coordenadas
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
	
	
	


}
