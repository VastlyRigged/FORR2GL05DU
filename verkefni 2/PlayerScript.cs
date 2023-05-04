using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public int hp;
    private ScoreScript ss;
    [ReadOnly] public bool isDead; 
    // Start is called before the first frame update
    void Start()
    {
        ss = GameObject.Find("Lives").GetComponent<ScoreScript>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    bool fix = false;
    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {

            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new(speed, rb.velocity.y, rb.velocity.z);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                rb.velocity = new(0, rb.velocity.y, rb.velocity.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new(-speed, rb.velocity.y, rb.velocity.z);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                rb.velocity = new(0, rb.velocity.y, rb.velocity.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new(rb.velocity.x, rb.velocity.y, speed);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                rb.velocity = new(rb.velocity.x, rb.velocity.y, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new(rb.velocity.x, rb.velocity.y, -speed);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = new(rb.velocity.x, rb.velocity.y, 0);
            }
        }
        else if (fix == false)
        {
            RunAftermath();
            fix = true;
        }
        if (fix == false && hp <= 0)
        {
            isDead = true;
        }
        ss.Score = hp;
    }
    void RunAftermath()
    {
        GameFunction gf = GameObject.FindWithTag("Events").GetComponent<GameFunction>();
        gf.GameOver();
    }
}
