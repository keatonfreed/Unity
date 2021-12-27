using System.Collections;
using System.Collections.Generic;
using UnityEngine;

        // Debug.Log("toe");


public class coinController : MonoBehaviour
{



    public Quaternion startQuaternion;
    public bool rotateConstantly = true;

    public float RotateAmount = 1;
 


    GameObject gameController;
    void Awake() {
        gameController = GameObject.Find("GameController");
        startQuaternion = transform.rotation;
        // quaternionToVector = startQuaternion.eulerAngles;
    }

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update() {
        // Smoothly tilts a transform towards a target rotation.
        float shouldTiltZ = -Input.GetAxis("Horizontal");
        float shouldTiltX = Input.GetAxis("Vertical");

        // Rotate the cube by converting the angles into a quaternion.
        if(rotateConstantly) {
            transform.Rotate(Vector3.up * RotateAmount);
        }
    
    }



}


