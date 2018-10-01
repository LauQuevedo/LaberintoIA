using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Seleccion : MonoBehaviour
{
    Vector3 targetRot;
    Vector3 currentAngle;
    public int currentSelection;
    public int totalCharacters = 6;
    public Button button;
    int sel = 1;
    // Use this for initialization
    void Start()
    {
        currentSelection = 1;
        sel = 1;
        //button.onClick.AddListener(Select);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Rotate(Direction.Right);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Rotate(Direction.Left);

        //Debug.Log(currentSelection);

    }

    private void Rotate(Direction direction)
    {
        float rotation = 360 / totalCharacters;
        // Operador ternario //
        transform.eulerAngles += new Vector3(0, direction == Direction.Right ? rotation : -rotation, 0);

        currentSelection += direction == Direction.Right ? 1 : -1;

        if (currentSelection > totalCharacters)
            currentSelection = 1;
        else if (currentSelection < 1)
            currentSelection = 6;
    }

    private void Select()
    {
        print("You selected " + currentSelection);
		ChangeScene();

    }

    public void ChangeScene()
    {
        // if (sel == 1)
        // {
			Debug.Log("Cambio de escena");
            SceneManager.LoadScene(3);
        // }
    }

}

enum Direction
{
    Right,
    Left
}