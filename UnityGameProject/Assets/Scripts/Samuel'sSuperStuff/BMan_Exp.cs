using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMan_Exp : MonoBehaviour
{
    public float radius = 5.0f;
    public float power = 10.0f;
    public GameObject BurningMan;
    Rigidbody Rigid;

    private Vector3 explosivePos;

    void Update()
    {
        Rigid.velocity = new Vector2(radius * Time.deltaTime, -power * Time.deltaTime);
    }

    void Exp ()
    {
        explosivePos = transform.position;
        explosivePos += new Vector3();
        Instantiate(BurningMan, explosivePos, Quaternion.identity);
        Destroy(gameObject);
    }
}
