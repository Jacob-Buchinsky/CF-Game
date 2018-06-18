using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneControllerTest : MonoBehaviour {
    public Button returnButton; 
    public int enemyUnits = 0;
    public int playerUnits = 0;
    public GameObject [] PlayerUnitsArray;
    public GameObject[] EnemyUnitsArray;
    public Transform ReportScreen;
    public Text missionstate;

	// Use this for initialization
	void Start () {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Social Hub"));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestMission"));
        PlayerUnitsArray = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject unit in PlayerUnitsArray) {
            playerUnits++;
        }
        PlayerUnitsArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject unit in EnemyUnitsArray)
        {
            enemyUnits++;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (enemyUnits == 0) {
            LevelComplete();
        }
        if (playerUnits == 0) {
            LevelFailed();
        }
	}

    void TaskOnClickReturn()
    {
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
        SceneManager.LoadSceneAsync("Social Hub", LoadSceneMode.Additive);
    }
    int GetPlayerUnitsNumber() {
        return playerUnits;
    }
    int GetEnemyUnitsNumber()
    {
        return enemyUnits;
    }
    public void DecrementPU() {
        playerUnits--;
        Debug.Log("Player Unit has died. " + playerUnits + " remaining");
    }
    public void DecrementEU()
    {
        enemyUnits--;
        Debug.Log("Enemy Unit has died. " + enemyUnits + " remaining");
    }
    void LevelComplete()
    {
        Debug.Log("Level Complete");
        Button btn = returnButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClickReturn);
        //display message
        //show report screen
        ReportScreen.gameObject.SetActive(true);
        //return to social hub

    }
    void LevelFailed()
    {
        Debug.Log("Level Failed");
        //display message
        //show report screen
        //get less rewards
        
        ReportScreen.gameObject.SetActive(true);
        missionstate.text = "MISSION FAILED";
        //return to social hub

    }
}
