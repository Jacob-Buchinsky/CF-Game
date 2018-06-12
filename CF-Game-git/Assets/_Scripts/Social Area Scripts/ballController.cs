using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour {
    public GameObject goal;
    int Force = 100;
    private float MovSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "Goal 1" || other.gameObject.name != "Goal 2" || other.gameObject.name != "Plane") {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            var locVel = transform.InverseTransformDirection(rigidbody.velocity);
            locVel.z = MovSpeed;
            rigidbody.velocity += transform.forward * MovSpeed * 30 ;
            Debug.Log("collison with: " + other.gameObject.name);
            
        }
        if (other.gameObject.name == "ThirdPersonController")
        {
            Debug.Log("playercollide");
            GetComponent<Rigidbody>().AddForce(Vector3.up * Force);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Goal 1" || other.gameObject.name == "Goal 2")
        {
            other.GetComponent<GoalController>().AddScore();
            Debug.Log("GOOOOOOAAAAAAALLLLL");
            Destroy(this.gameObject);
            
        }
    }
}
