using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody PlayerRigidbody;
    CapsuleCollider col;
    public double speed = 1;
    public float camSpeed = 10;
    public float camYSpeed = 3;
    public double jumpHeight = 1;
    public static float modi = 1;
    public static float modij = 1;
    public static int jumpmodi = 1;
    public float modifier;
    public int jumps = 1;
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
        modifier = modi;
        //if (Input.GetKeyDown(KeyCode.Space) && is_grounded)
        //{
        //    PlayerRigidbody.velocity += (jumpHeight* modij) * Time.timeScale * transform.up;
        //}
        if (Input.GetKeyDown(KeyCode.Space) && jumps >= 1)
        {
            jumps--;
            PlayerRigidbody.velocity += ((float)jumpHeight * modij) * Time.timeScale * transform.up;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.6;
        }
        else {
            speed = 0.3;
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
        
        PlayerRigidbody.velocity += moveDirection * ((float)speed* modi) * Time.timeScale;







        transform.Rotate(camSpeed * Time.timeScale * new Vector3(0, Input.GetAxis("Mouse X"), 0));
        cam.transform.Rotate(camYSpeed * Time.timeScale * new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));
    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor")
        {
            jumps = 1 * jumpmodi;
            
            is_grounded = true;
        }
    }
    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.gameObject == floor)
    //    {
            
    //        is_grounded = false;
    //    }
    //}
}
