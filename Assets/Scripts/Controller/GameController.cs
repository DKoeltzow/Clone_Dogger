using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public double GametimerSec;
    public double GametimerMin;
    public Text text;

    public GameObject Player;


	// Use this for initialization
	void Start () {
        GametimerSec = 0;
        GametimerMin = 0;
        Player.GetComponent<PlayerController>().OnContact += Loadscene;
    }
	
	// Update is called once per frame
	void Update () {

        GametimerSec += Time.deltaTime;
        if(GametimerSec >=59.9)
        {
            GametimerMin += 1;
            GametimerSec = 0;
        }

        double roundedGametime = System.Math.Floor(GametimerSec); 

        string time = ("GameTime : " + GametimerMin + " min " + roundedGametime +" sec");

        text.text = time;
	}

    void Loadscene()
    {
        SceneManager.LoadScene(1);
    }
    
}
