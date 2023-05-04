using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private bool fix = true;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && fix == true)
        {
            GameObject.Find("Scoreboard").GetComponent<ScoreScript>().Score += 1;
            SpawnCan sc = FindAnyObjectByType<SpawnCan>() as SpawnCan;
            sc.contemporaryCans -= 1;
            Destroy(gameObject);
            fix = false;
        }
        
    }
}
