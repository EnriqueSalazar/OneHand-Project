using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour
{

    public float speed = 0.001f;
    public float bulletSpeed = 10;
    public float smooth = 5;

    Rigidbody2D rigid2D;
    public GameObject bulletPrefab;
    public float fireFrecuency = 0.5f;

    float delta = 0;
    void FixedUpdate()
    {

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float distance = Vector2.Distance(pos, Input.mousePosition);
        // Debug.unityLogger.Log(distance);
        var targetRotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        // Lerp to target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
        Debug.Log(distance);
        Debug.Log(speed);
        Debug.Log(distance * speed);
        // rigid2D.velocity = gameObject.transform.up * speed * distance;
        if (distance < 100){
            distance = distance * -5;
        }
        rigid2D.AddForce(gameObject.transform.up * speed * distance);


    }

    // Use this for initialization
    void Start()
    {

        rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta >= fireFrecuency)
        {
            Fire();
            delta = 0;
        }
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
