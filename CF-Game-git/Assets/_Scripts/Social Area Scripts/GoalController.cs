using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalController : MonoBehaviour {
   public TextMeshPro Scoretext;
    int score;
    public GameObject ball;

	// Use this for initialization
	void Start () {
        score = 0;
        Scoretext.text = (score.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddScore() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        score++;
        Scoretext.text = (score.ToString());
        Instantiate(ball, new Vector3(-10, 1, -20), Quaternion.identity);

    }
}
