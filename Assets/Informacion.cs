using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informacion : MonoBehaviour {
	
	public string peso;
	public TextMesh tm;
	
	// Update is called once per frame
	void Update () {
		BoardManager InfodeMapa = GetComponent<BoardManager>();
		peso = InfodeMapa.texto;
		
		tm = (TextMesh)GameObject.Find("Text_Reciver").GetComponent<TextMesh>();
		tm.text = ""+peso;

	}
}
