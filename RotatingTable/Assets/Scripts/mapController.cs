using System.Collections;
using System.Collections.Generic;
using UnityEngine;

        // Debug.Log("toe");


public class mapController : MonoBehaviour
{



    public Quaternion startQuaternion;
    public float lerpTime = 1;
    public bool rotate;
    public bool rotateConstantly;
    public bool rotateKeys;
    public Vector3 quaternionToVector;
    public Vector3 reverseQuaternion;

    public float RotateAmount;
    public float RotateKeysModifier = 1;


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
        if(rotate) {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(reverseQuaternion), Time.deltaTime * lerpTime);
        }
        if(rotateConstantly && !rotate && !rotateKeys) {
            transform.Rotate(Vector3.left * RotateAmount);
        }
        if(rotateKeys && !rotateConstantly && !rotate) {
            if(Mathf.Abs(transform.rotation.z) >= 0.17f) {
                if(shouldTiltZ > 0 && transform.rotation.z > 0) {
                shouldTiltZ = 0;
                }
                if(shouldTiltZ < 0 && transform.rotation.z < 0) {
                shouldTiltZ = 0;
                }
            }
            if(Mathf.Abs(transform.rotation.x) >= 0.17f) {
                if(shouldTiltX > 0 && transform.rotation.x > 0) {
                shouldTiltX = 0;
                }
                if(shouldTiltX < 0 && transform.rotation.x < 0) {
                shouldTiltX = 0;
                }
            }

            transform.Rotate(new Vector3(Time.deltaTime * shouldTiltX*RotateKeysModifier,-transform.rotation.y,Time.deltaTime * shouldTiltZ*RotateKeysModifier));
        }
    
    }

}
