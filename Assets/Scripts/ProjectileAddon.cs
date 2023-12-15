using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int damage;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if you hit an enemy
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            // Apply damage to the enemy
            enemy.TakeDamage(damage);

            // Make sure projectile moves with target (enemy)
            transform.SetParent(collision.transform);
        }
        else
        {
            // If it's not an enemy, check if it's the player or camera
            if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("MainCamera"))
            {
                // If it's neither an enemy, player, nor camera, destroy the projectile
                Destroy(gameObject);
            }
        }

        // Make sure projectile sticks to surface
        rb.isKinematic = true;
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NewBehaviourScript : MonoBehaviour
//{
//    public int damage;

//    private Rigidbody rb;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        // Check if you hit an enemy
//        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

//        if (enemy != null)
//        {
//            // Apply damage to the enemy
//            enemy.TakeDamage(damage);
//        }

//        // Make sure projectile sticks to surface
//        rb.isKinematic = true;

//        // Make sure projectile moves with target only if it's an enemy
//        if (enemy != null)
//        {
//            transform.SetParent(collision.transform);
//        }
//        else
//        {
//            // If it's not an enemy, destroy the projectile
//            Destroy(gameObject);
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NewBehaviourScript : MonoBehaviour
//{
//    public int damage;

//    private Rigidbody rb;

//        private bool targetHit;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }


//    private void OnCollisionEnter(Collision collision)
//    {
//        if (targetHit)
//            return;
//        else
//            targetHit = true;

//        //check if you hit an enemy
//        if(collision.gameObject.GetComponent<EnemyHealth>() != null)
//        {
//            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

//            enemy.TakeDamage(damage);

//            Destroy(gameObject);
//        }

//        //make sure projectile sticks to surface
//        rb.isKinematic = true;

//        // make sure projectile moves with target
//        transform.SetParent(collision.transform);
//    }
//}
