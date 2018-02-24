using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMobility : MonoBehaviour
{

    public float speed = 3;
    public float smooth = 10;

    Rigidbody2D rigid2D;

    float delta = 0;
    void FixedUpdate()
    {

        Vector3 dir = GameObject.Find("Spaceship").transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var targetRotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        // Lerp to target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
        rigid2D.AddForce(gameObject.transform.up * speed);


    }

    // Use this for initialization
    void Start()
    {

        rigid2D = GetComponent<Rigidbody2D>();

    }

}
