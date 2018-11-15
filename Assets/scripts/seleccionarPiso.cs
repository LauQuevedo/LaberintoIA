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

    public InputField peso0;

    void Awake(){
        string text_codigos = "";
        //mostrar número de terrenos
        numeroTerrenos = GameManager.numeroTerrenosG;
        //mostrar código
        listaTerrenosId = GameManager.listaTerrenosId;
        // Debug.Log(listaTerrenosId);
        
        //texto para mostrar en pantalla
        textoMostrar.text = numeroTerrenos + " tipos de terrenos encontrados ";
        // mostrar números de códigos de terrenos
        foreach (int numero in listaTerrenosId){
            text_codigos += numero + "\n";
            Debug.Log(numero);
        }
        numero_codigos.text = text_codigos; //"1\n2\n3\n4\n";
        // Debug.Log

    }


    // Use this for initialization
    void Start () {
        Debug.Log("Start");
        
        //mostrar, rellenar y listener dropdowns 
        mostrarDropdown(numeroTerrenos);

        peso0.onValueChanged.AddListener(delegate{
            obtenerValorPesos(peso0, "peso 0");
        });
    }

	void mostrarDropdown(int numeroTerrenos){
        Debug.Log("Mostrar dropdown");
		for(int i=0; i<numeroTerrenos; i++){
			switch(i){
				case 0:
                    dropdown0.gameObject.SetActive(true);
                    dropdown0.AddOptions(terrenos);
                    //Añadir listener para valor de dropdowns
                    dropdown0.onValueChanged.AddListener(delegate{
                        obtenerValorDropdown(dropdown0, "dropdown 0");
                    });
                    
                    break;
                case 1:
					dropdown1.gameObject.SetActive(true);
                    dropdown1.AddOptions(terrenos);
                    //Añadir listener para valor de dropdowns
                    dropdown1.onValueChanged.AddListener(delegate{
                        obtenerValorDropdown(dropdown1, "dropdown 1");
                    });
                    break;
				case 2:
					dropdown2.gameObject.SetActive(true);
                    dropdown2.AddOptions(terrenos);
                    //Añadir listener para valor de dropdowns
                    dropdown2.onValueChanged.AddListener(delegate{
                        obtenerValorDropdown(dropdown2, "dropdown 2");
                    });
					break;
				case 3:
					dropdown3.gameObject.SetActive(true);
                    dropdown3.AddOptions(terrenos);
                    //Añadir listener para valor de dropdowns
                    dropdown3.onValueChanged.AddListener(delegate{
                        obtenerValorDropdown(dropdown3, "dropdown 3");
                    });
                    break;
                case 4:
					dropdown4.gameObject.SetActive(true);
                    dropdown4.AddOptions(terrenos);
                    //Añadir listener para valor de dropdowns
                    dropdown4.onValueChanged.AddListener(delegate{
                        obtenerValorDropdown(dropdown4, "dropdown 4");
                    });
                    break;	
				case 5:
                    dropdown5.gameObject.SetActive(true);
                    dropdown5.AddOptions(terrenos);
                    //Añadir listener para valor de dropdowns
                    dropdown5.onValueChanged.AddListener(delegate{
                        obtenerValorDropdown(dropdown5, "dropdown 5");
                    });
                    break;
                case 6:
                    dropdown6.gameObject.SetActive(true);
                    dropdown6.AddOptions(terrenos);
                    //Añadir listener para valor de dropdowns
                    dropdown6.onValueChanged.AddListener(delegate{
                        obtenerValorDropdown(dropdown6, "dropdown 6");
                    });
                    break;
                case 7:
                    dropdown7.gameObject.SetActive(true);
                    dropdown7.AddOptions(terrenos);
                    //Añadir listener para valor de dropdowns
                    dropdown7.onValueChanged.AddListener(delegate{
                        obtenerValorDropdown(dropdown7, "dropdown 7");
                    });
                    break;
                case 8:
                    dropdown8.gameObject.SetActive(true);
                    dropdown8.AddOptions(terrenos);
                    //Añadir listener para valor de dropdowns
                    dropdown8.onValueChanged.AddListener(delegate{
                        obtenerValorDropdown(dropdown8, "dropdown 8");
                    });
                    break;
                case 9:
                    dropdown9.gameObject.SetActive(true);
                    dropdown9.AddOptions(terrenos);
                    //Añadir listener para valor de dropdowns
                    dropdown9.onValueChanged.AddListener(delegate{
                        obtenerValorDropdown(dropdown9, "dropdown 9");
                    });
                    break;

				default: break;
			}
		}
	}

    public void obtenerValorDropdown(Dropdown change, string name){
        Debug.Log("Value from " + name + " :" + change.value);
    }

    public void obtenerValorPesos(InputField change, string name)
    {
        Debug.Log("Value from " + name + " :" + change.text);
    }

    public void setGetPesos(){
        if(peso0.text != ""){
            Debug.Log("No vacío: "+peso0.text);
        }
    }


    public void cambiarEscena(){
        //cambiar a coordenadas
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
	


}
