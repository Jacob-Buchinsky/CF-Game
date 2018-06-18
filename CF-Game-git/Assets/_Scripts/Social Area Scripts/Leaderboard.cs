using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Leaderboard : MonoBehaviour {
    public Text[] Highscores;
    int[] highscoresValues;
	// Use this for initialization
	void Start () {
        highscoresValues = new int[Highscores.Length];
        for (int x = 0; x < Highscores.Length; x++) {
            highscoresValues[x] = PlayerPrefs.GetInt("highscoreValues" + x);
        }
        DrawScores();
		
	}
    void SaveScores() {
        for (int x = 0; x < Highscores.Length; x++) {
            PlayerPrefs.SetInt( "highscoreValues" + x , highscoresValues[x] );
        }

    
   
    }

    public void CheckForHighScore(int _value) {
        for (int x = 0; x < Highscores.Length; x++) {
            if (_value > highscoresValues[x]) {
                for (int y = Highscores.Length - 1; y > x; y--) {
                    Highscores[y] = Highscores[y - 1];
                }
                highscoresValues[x] = _value;
                DrawScores();
                SaveScores();
                break;
            }
        }
    }

    void DrawScores()
    {
        for (int x = 0; x < Highscores.Length; x++) {
            Highscores[x].text = highscoresValues[x].ToString();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
