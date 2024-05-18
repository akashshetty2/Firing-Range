using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1; 
    public float jump = 1; 
    private Rigidbody body; 

    private void Start() 
    { 
        body = GetComponent<Rigidbody>(); 
    }


    private void Update()
    {
        // jumping 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(0, jump, 0, ForceMode.Impulse);
        }


        float horVal = Input.GetAxisRaw("Horizontal");
        float vertVal = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(horVal, 0, vertVal) * speed * Time.deltaTime;
        Vector3 dest = body.position + body.transform.TransformDirection(move);

        body.MovePosition(dest);


    }

    public void changeSpeed(float speedChanged)
    {
     	speed = speedChanged;
    }

    public void changeJump(float jumpChanged)
    {
     	jump = jumpChanged;
    }
}
