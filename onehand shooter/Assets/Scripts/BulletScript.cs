using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        { // check if it's the player, if you want
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
