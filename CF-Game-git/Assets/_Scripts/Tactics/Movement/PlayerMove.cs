using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code adapted from Game Programming Academy's Tactics Movement Tutorial

public class PlayerMove : TacticsMove {
   public GameObject Controller;
    public float HP;
    public int ATK;
    public int DEF;
    public int range;


    // Use this for initialization
    void Start() {
        init();
        Controller = GameObject.Find("SceneController");
    }

    // Update is called once per frame
    void Update() {
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();
        }
        else
        {
            Move();
        }
    }
    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        MoveToTile(t);
                    }
                }
            }
        }
    }
    void TakeDamage(float damage) {
        HP = (HP - damage);
        Debug.Log("damage has been dealt: Current HP is " + HP);
        if (HP <= 0) {
            Die();
        }


    }
    void SelectTarget(GameObject target) {
        if (Input.GetMouseButtonUp(1)) {
            GameObject e = null;



            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit[] hits;
                hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);
                foreach (RaycastHit hit in hits) {
                    if (hit.collider.tag == "enemy") {
                        e = hit.collider.GetComponent<GameObject>();
                    }
                    if (hit.collider.tag == "Tile")
                    {
                        Tile t = hit.collider.GetComponent<Tile>();
                        if (t.selectable)
                        {
                            Attack(e);
                        }
                    }
                }


            }
        }
    }

        

    void Attack(GameObject enemy) {
           float damage = Random.Range(ATK - (ATK * .2f), ATK + (ATK * .2f));
           TakeDamage(damage);
    }
    void Die() {
        //play death animation
        if (this.tag == "Player")
        {
            Controller.GetComponent<SceneControllerTest>().DecrementPU();
        }
        else Controller.GetComponent<SceneControllerTest>().DecrementEU();
        Destroy(this);

    }
}

