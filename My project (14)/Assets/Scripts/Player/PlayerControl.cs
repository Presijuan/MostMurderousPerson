using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float movementSpeed;
    public Vector2 sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }
    private void UpdateMovement()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 speed = Vector3.zero;

        if (hor != 0.0f || ver != 0.0f)
        {
            Vector3 dir = (transform.forward * ver + transform.right * hor).normalized;
            speed = dir * movementSpeed;

            speed.y = rigidbody.velocity.y;
            rigidbody.velocity = speed;

        }
    }
    private void UpdateMouseLook()
    {
        float hor = Input.GetAxis("MouseX");
        float ver = Input.GetAxis("MouseY");
        if (hor != 0);
        {
            transform.Rotate(0,hor * sensitivity.x,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement(); 
        UpdateMouseLook();
                
    }

}
