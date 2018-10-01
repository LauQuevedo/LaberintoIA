using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

public static GameManager instance = null;
public BoardManager boardScript;
public int playerFoodPoints = 0;
[HideInInspector] public bool playersTurn = true;

private bool doingSetup;
private int level = 1;

    // Use this for initialization
    void Awake () {
		if(instance == null){
			instance = this;
		}else if(instance != this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);

		boardScript = GetComponent<BoardManager>();
		InitGame();
	}

	private void OnLevelWasLoaded(int index){
		level++;
		InitGame();
	}

	void InitGame(){
		doingSetup = true;
		
		boardScript.SetupScene();
	}

	public void GameOver(){
		enabled = false;
		// levelText.text = "Tardaste tanto en recorrer todo el laberinto";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
