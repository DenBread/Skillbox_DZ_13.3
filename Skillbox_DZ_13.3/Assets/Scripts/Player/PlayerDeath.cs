using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DeathZone>())
        {
            gameObject.GetComponent<Animator>().Play("Death");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<DeathZone>())
        {
            gameObject.GetComponent<Animator>().Play("Idle");
        }
    }
}
