using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    public int hp;
    [ReadOnly] public bool isDead;
    private AudioSource a;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        a = gameObject.GetComponent<AudioSource>();
    }
    bool fix = false;
    // Update is called once per frame
    void Update()
    {

        if (fix == false && isDead == true)
        {
            RunAftermath();
            fix = true;
        }
        if (fix == false && hp <= 0)
        {
            isDead = true;
        }
    }
    void RunAftermath()
    {
        GameFunction gf = FindObjectOfType<GameFunction>();
        Debug.Log(gf.gameObject.name);
        a.Play();   
        gf.GameOver();
    }
}
