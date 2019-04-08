using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SibScript : MonoBehaviour
{
    //Set movespeed variables
    private float forwardSpeed = 10.0f;
    private float sideSpeed = 5.0f;
    private float upSpeed = 4.0f;

    //Link camera to mouse for view
    private float viewXRotation = 0.0f;
    private float viewYRotation = 0.0f;
    private float xViewSpeed = 1.0f;
    private float yViewSpeed = 1.5f;

    public Rigidbody rb;
    public float[] velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocity = new float[3];
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        float leftRight = Input.GetAxis("Horizontal");
        float forwardBack = Input.GetAxis("Vertical");
        float upDown = Input.GetAxis("Up");

        transform.Translate(new Vector3(leftRight * forwardSpeed, upDown * upSpeed, forwardBack * sideSpeed) * Time.deltaTime);
    }

    void HandleRotation()
    {
        viewXRotation -= Input.GetAxis("Mouse Y");
        viewYRotation += Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(viewXRotation * xViewSpeed, viewYRotation * yViewSpeed, 0.0f);
    }

    void HandleInteraction()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(transform.position, transform.forward * 10.0f, Color.red);
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10.0f))
            {

                if (hit.collider.tag == "Flower")
                {
                    //Handle flower interaction
                }
                else if (hit.collider.tag == "Water")
                {
                    //Handle water interaction
                }
            }
            //Cast ray, interact with things
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.isKinematic = true;
        rb.isKinematic = false;
    }
}
