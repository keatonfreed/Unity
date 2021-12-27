using System.Collections;
using System.Collections.Generic;
using UnityEngine;

        // Debug.Log("toe");


public class cameraController : MonoBehaviour
{


    public bool followBall;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        if(followBall) {
        GameObject[] ballList = GameObject.FindGameObjectsWithTag("Player");
        if(ballList.Length >= 1) {
        GameObject ball = ballList[0];
        transform.position = new Vector3(0,ball.transform.position.y + 10f,ball.transform.position.z - 7f);
        // Debug.Log(ball.transform.position); 
        } else {
            transform.position = new Vector3(0,10f,-3);
        }
        }
    }

    // if()

    void OnCollisionEnter(Collision collision){
        // collision.gameObject.GetComponent<sphereController>().dieAnim();
    }
}
