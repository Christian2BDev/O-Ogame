using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody PlayerRigidbody;
    CapsuleCollider col;
    public float speed = 1;
    public float camSpeed = 10;
    public float camYSpeed = 3;
    public float jumpHeight = 10;
    public GameObject cam;
    public GameObject floor;
    public bool is_grounded = false;
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && is_grounded)
        {
            PlayerRigidbody.velocity += jumpHeight * Time.timeScale * transform.up;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2;
        }
        else {
            speed = 1;
        }

        Vector3 moveDirection = Vector3.zero;
        
    
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection += transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection -= transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection -= transform.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection += transform.right;
            }
            moveDirection.Normalize();
        
        PlayerRigidbody.velocity += moveDirection * speed * Time.timeScale;







        transform.Rotate(camSpeed * Time.timeScale * new Vector3(0, Input.GetAxis("Mouse X"), 0));
        cam.transform.Rotate(camYSpeed * Time.timeScale * new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));
    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == floor)
        {
            is_grounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == floor)
        {
            is_grounded = false;
        }
    }
}
