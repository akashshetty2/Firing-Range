using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curse : MonoBehaviour
{

    public bool visibility;
    [SerializeField] private Pause pause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	visibility = pause.getMenuStatus();

	if (visibility == false)
        {
           Cursor.lockState = CursorLockMode.Locked;
        } 
	else
	{
	   Cursor.lockState = CursorLockMode.None;
	}
    }

     public void CursorStatus()
     {
	
     }
}
