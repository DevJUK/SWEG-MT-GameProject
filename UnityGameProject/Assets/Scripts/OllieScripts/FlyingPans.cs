using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPans : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 randomDirection;

    public float MaxStrength = 5;
    public float MinStrength = 1;

    private float stregnth;

    public void Awake()
    {
      
    }

    public float speed = 5.0f;
    public void Start()
    {
        randomDirection = new Vector3(Random.value, Random.value, Random.value);
        stregnth = Random.Range(MinStrength, MaxStrength);

        if (!rb)
        {
            rb = GetComponent<Rigidbody>();
        }
        transform.Rotate(randomDirection);
        rb.AddForce(randomDirection * stregnth);


    }

}
