using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seleccion : MonoBehaviour {
	Vector3 targetRot;
	Vector3 currentAngle;
	public int currentSelection;
	public int totalCharacters = 6;
	public Button button;

	// Use this for initialization
	void Start () 
	{
		currentSelection=1;
		button.onClick.AddListener (Select);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.RightArrow))
			Rotate (Direction.Right);
		
		if(Input.GetKeyDown(KeyCode.LeftArrow))
			Rotate (Direction.Left);
	}

	private void Rotate (Direction direction)
	{
		float rotation = 360 / totalCharacters;
		// Operador ternario //
		transform.eulerAngles += new Vector3 (0, direction == Direction.Right ? rotation : -rotation, 0);

		currentSelection += direction == Direction.Right ? 1 : -1;

		if (currentSelection > totalCharacters)
			currentSelection = 1;
		else if (currentSelection < 1)
			currentSelection = 6;
	}

	private void Select()
	{
		print ("You selected " + currentSelection);
	}

}

enum Direction
{
	Right,
	Left
}
