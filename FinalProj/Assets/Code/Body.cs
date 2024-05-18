using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class Body : MonoBehaviour
{
    public float speed = 0;
    public float resetTimer = 3;

    private Health health;
    private Transform rotTransform;
    private bool alive = true;
    float changeDirections = 1;

    private void Awake() 
    {
        health = GetComponent<Health>();    
        rotTransform = transform.parent.GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        changeDirections = Random.Range(-1, 1); //Randomly choose which direction the decoys start 

        if (changeDirections >= 0)
        {
            changeDirections = 1;
        }
        else if (changeDirections < 0)
        {
            changeDirections = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z <= -7)
        {
            changeDirections = 1;

        } else if (transform.position.z >= 7)
        {
            changeDirections = -1;
        }

        transform.Translate(changeDirections * Vector3.forward * speed * Time.deltaTime);

        if (health.GetHealth() <= 0)
            ResetDummy();
    }

    //This function allows the player to change the dummy's movement speed in the game menu
    public void changeSpeed(float speedValue)
    {
        speed = speedValue;
    }

    public void Reset(float resetValue)
    {
        resetTimer = resetValue;
    }

    // Make dummy fall and then reset
    private void ResetDummy()
    {
        if (!alive)
            return;
        
        alive = false;
        rotTransform.Rotate(-Vector3.forward * 90);
        StartCoroutine(Kill());
    }

    public IEnumerator Kill()
    {
        yield return new WaitForSeconds(resetTimer);
        rotTransform.Rotate(Vector3.forward * 90);
        health.resetHealth();
        alive = true;
    }
}
