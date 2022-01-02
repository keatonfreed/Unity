using System.Collections;
using System.Collections.Generic;
using UnityEngine;

        // Debug.Log("toe");


public class sphereController : MonoBehaviour
{

    Rigidbody rb;
    Renderer rbRenderer;

    public float moveForce;
    public bool zMove = false;
    public float ballScore = 0;
    public float gravityInc = 2;

    // float maxVel = 10;
    public bool moveEnabled;

    // public GameObject gameController;
    private gameController controller;
    void Awake() {
        rb = gameObject.GetComponent<Rigidbody>();
        rbRenderer = rb.GetComponent<Renderer>();
        // gameScript = gameController.GetComponent<gameController>();
         controller = GameObject.Find("GameController").GetComponent<gameController>();

    // StartCoroutine(waiter());
}


    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("started");
        // Instantiate(prefab, new Vector3(0f,8f,0f),transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(controller);

        if(rb.position.y <= -10) {
            controller.Die(gameObject);
        }

    if(zMove) {

        if(Input.GetKey("w")) {
            force(0,0,moveForce);
        }
        if(Input.GetKey("s")) {
            force(0,0,-moveForce);
        }
                }
        if(Input.GetKey("a")) {
            force(-moveForce,0,0);
        }
        if(Input.GetKey("d")) {
            force(moveForce,0,0);
        }

    }

    void FixedUpdate() {
        rb.AddForce(Physics.gravity * gravityInc, ForceMode.Acceleration);
    }

    public void force(float moveX, float moveY, float moveZ) {
        if(moveEnabled) {
        rb.AddForce(moveX, moveY, moveZ);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        // Debug.Log(collision.gameObject.tag);
    }
    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.tag == "Coin") {
            controller.collected++;
            ballScore++;
            Destroy(collision.gameObject);
        }
    }


    public void dieAnim() {
        rbRenderer.material.SetColor("_Color",Color.red);
    }


}
