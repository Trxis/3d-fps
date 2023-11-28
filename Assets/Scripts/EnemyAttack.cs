using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    
    public Transform player;
    public float attackRange = 10f;

    private Enemy enemyScript;

    public Material defaultMaterial;
    public Material alertMaterial;

    public Renderer ren;

    private bool foundPlayer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyScript = GetComponent <Enemy>();
        ren = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            ren.sharedMaterial = alertMaterial;
            enemyScript.badGuy.SetDestination(player.position);
            foundPlayer = true;
        }
        else if (foundPlayer)
        {
            ren.sharedMaterial = defaultMaterial;
            enemyScript.newLocation();
            foundPlayer = false;
        }
    }
}
