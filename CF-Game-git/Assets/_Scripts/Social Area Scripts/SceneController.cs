using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("TestMission"));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SocialHub"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadTestMission() {
        SceneManager.LoadSceneAsync("TestMission", LoadSceneMode.Additive);


    }
}
