using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informacion : MonoBehaviour {
	
	public string peso;
	public string visitas;
	public TextMesh tm;
	public TextMesh tr;
	
	// Update is called once per frame
	void Update () {
		GameManager InfodeMapa = GetComponent<GameManager>();
		peso = InfodeMapa.Peso;
		InfodeMapa = GetComponent<GameManager>();
		visitas = InfodeMapa.Visitas;

		
		tm = (TextMesh)GameObject.Find("PesoMapa").GetComponent<TextMesh>();
		tm.text = ""+peso;
		tr = (TextMesh)GameObject.Find("VisitasMapa").GetComponent<TextMesh>();
		tr.text = ""+visitas;


	}
}
