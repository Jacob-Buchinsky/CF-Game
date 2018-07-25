using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour {
    public Transform canvas;
    public Transform canvasE;
    bool collided = false;
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerStay(Collider other)
    {
        GameObject varGameObject = GameObject.FindWithTag("Player");
        collided = true;
        canvasE.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E)) {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);

                varGameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                varGameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                varGameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
                varGameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;


            }
            else
            {
                canvas.gameObject.SetActive(false);
                varGameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
                varGameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
            }
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.gameObject.SetActive(false);
        canvasE.gameObject.SetActive(false);
    }
}
