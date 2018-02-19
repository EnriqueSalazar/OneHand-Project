using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour {

	public float speed;
	public float smooth = 5;

	Rigidbody2D rigid2D;

    void FixedUpdate(){

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var targetRotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        // Lerp to target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
        rigid2D.AddForce(gameObject.transform.up * speed);


    }

    // Use this for initialization
    void Start () {

		rigid2D = GetComponent<Rigidbody2D> ();

    }

    // Update is called once per frame
    void Update () {
       
        
    }
}
