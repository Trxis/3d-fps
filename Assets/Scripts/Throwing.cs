using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{

    [Header("references")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpForce;
    private Animation anim;
    public GameObject Beerbottle;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;

        anim = Beerbottle.GetComponent<Animation>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
    }


    private void Throw()
    {
        readyToThrow = false;
        anim.Play();
        Debug.Log(cam.rotation);
        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // get rigidbody component
        Rigidbody projectilerb = projectile.GetComponent<Rigidbody>();

        //calculate direction
        Vector3 forceDirection = cam.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpForce;

        projectilerb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

}



