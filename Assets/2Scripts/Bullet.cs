using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public bool isMelee;
    public bool isRock;

    void OnCollisionEnter(Collision collision)
    {
        if (!isRock && collision.gameObject.tag == "Floor") {
            Destroy(gameObject, 3);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!isMelee && collision.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
    }
}
