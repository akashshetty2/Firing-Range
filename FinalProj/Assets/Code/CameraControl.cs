using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float sensitivity = 1;
    public float rate = 1;

    [SerializeField] private GameObject user;
    private Vector2 interVel;
    private Vector2 currPos; 


    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxisRaw("Mouse X");
        float vert = Input.GetAxisRaw("Mouse Y");
        Vector2 moveData = Vector2.Scale(new Vector2(horiz, vert), new Vector2(sensitivity * rate, sensitivity * rate));

        interVel.x = Mathf.Lerp(interVel.x, moveData.x, 1f / rate);
        interVel.y = Mathf.Lerp(interVel.y, moveData.y, 1f / rate);

        currPos = currPos + interVel; 

        transform.localRotation = Quaternion.AngleAxis(Mathf.Clamp(-currPos.y, -100, 100), Vector3.right);
        user.transform.localRotation = Quaternion.AngleAxis(currPos.x, user.transform.up); 
    }

    public void changeSensitivity(float sens)
    {
        sensitivity = sens;
    }
}
