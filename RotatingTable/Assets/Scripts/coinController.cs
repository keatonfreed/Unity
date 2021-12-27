using System.Collections;
using System.Collections.Generic;
using UnityEngine;

        // Debug.Log("toe");


public class coinController : MonoBehaviour
{



    public bool rotateConstantly = true;

    public float RotateAmount = 1;
 

    Rigidbody rb;
    GameObject gameController;
    void Awake() {
        gameController = GameObject.Find("GameController");
        rb = gameObject.GetComponent<Rigidbody>();
        Debug.Log(rb);

        // quaternionToVector = startQuaternion.eulerAngles;
    }

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void FixedUpdate() {

        // Rotate the cube by converting the angles into a quaternion.
        if(rotateConstantly) {
           // transform.Rotate(Vector3.up * RotateAmount);
            transform.RotateAround(rb.worldCenterOfMass, Vector3.up, RotateAmount);
        }
    
    }



}


