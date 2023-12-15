using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPopup : MonoBehaviour
{ 

public class Enemy : MonoBehaviour
{
    public bool defeated = false;
}

public class GameManager : MonoBehaviour
{
    public GameObject portal;

    private Enemy[] enemies;

    private void Start()
    {
        // Populate the enemies array with references to your enemy objects
        enemies = FindObjectsOfType<Enemy>();
    }

    private bool AreAllEnemiesDefeated()
    {
        foreach (Enemy enemy in enemies)
        {
            if (!enemy.defeated)
            {
                return false;
            }
        }
        return true;
    }

    private void Update()
    {
        // Check if all enemies are defeated and show the portal
        if (AreAllEnemiesDefeated())
        {
            ShowPortal();
        }
    }

    private void ShowPortal()
    {
        // Your code to show the portal goes here
        portal.SetActive(true);
        Debug.Log("Portal is now visible!");
    }
}

}
