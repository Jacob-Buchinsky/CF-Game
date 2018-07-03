using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {
    public GameObject player;
    // Use this for initialization
        void Start () {
        player = GameObject.Find("ThirdPersonController");

	}
	
	// Update is called once per frame
	void Update () {
       
        RaycastHit hit;
        Ray cameraRay = new Ray(player.transform.position + new Vector3(0f, 1.75f, 0f), (transform.forward *-1));
        Debug.DrawRay(player.transform.position + new Vector3(0f, 1.75f, 0f), (transform.forward * -1));
        if (Physics.Raycast(cameraRay, out hit, 3.6f))
        {
            Vector3 temp = hit.point;
            temp.y = 2f;
            this.gameObject.transform.position = temp - (transform.forward * -1f);
            
            Debug.Log(hit.point);
        }
        




    }
}
