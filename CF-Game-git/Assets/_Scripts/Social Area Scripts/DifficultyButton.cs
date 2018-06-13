using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DifficultyButton : MonoBehaviour
{
    public Button easybutton;
    public Button mediumbutton;
    public Button hardbutton;
    public GameObject Mission;
    void Start()
    {
        
        Button btnE = easybutton.GetComponent<Button>();
        Button btnM = mediumbutton.GetComponent<Button>();
        Button btnH = hardbutton.GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btnE.onClick.AddListener(TaskOnClickEasy);
        btnM.onClick.AddListener(TaskOnClickMedium);
        btnH.onClick.AddListener(TaskOnClickHard);

    }

    void TaskOnClickEasy()
    {
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
        Mission.SetActive(true);
        }
        
    void TaskOnClickMedium()
{
    //Output this to console when the Button is clicked
    Debug.Log("You have clicked the button!");
    Mission.SetActive(false);
}
    void TaskOnClickHard()
    {
    //Output this to console when the Button is clicked
    Debug.Log("You have clicked the button!");
    Mission.SetActive(false);
    }

}


