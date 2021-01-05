using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float duration = 4f;

    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        // Spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //****************************************************************

        // Apply effect to the player
        
        // Make player bigger
        player.transform.localScale *= multiplier;
        
        // Add health to player
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.health *= multiplier;

        // Disable the MeshRenderer and Collider for the power up
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //****************************************************************

        // Wait x amount of seconds
        yield return new WaitForSeconds(duration);

        // Reverse the effect on our player
        stats.health /= multiplier;

        //****************************************************************

        // Remove power up object
        Destroy(gameObject);
    }
}
