using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObjsControllers : MonoBehaviour
{

    private float timer;
    Rigidbody rb;
    public Transform pos1;
    public Transform pos2;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        timer += 1;

        if(timer == 150) {
            rb.velocity = Vector3.zero;
            transform.position = pos1.position;
            rb.AddForce(-750,1700,0);
        }
        if(timer == 300) {
            rb.velocity = Vector3.zero;
            transform.position = pos2.position;
            rb.AddForce(750,1700,0);
            timer = 0;
        }
    }
}
