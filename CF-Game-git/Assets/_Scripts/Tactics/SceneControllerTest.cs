using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Social Hub"));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestMission"));

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
