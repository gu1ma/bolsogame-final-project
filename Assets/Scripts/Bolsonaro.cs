using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bolsonaro : MonoBehaviour
{
    public Text healthDisplay;

    public float speed;
    private float input;

    public int health;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthDisplay.text = health.ToString();
    }

    private void Update() {
        if(input > 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //store player input
        input = Input.GetAxisRaw("Horizontal");
        
        //Move the player
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damageAmount) {
        health -= damageAmount;
        if(health <= 0) {
            health = 0;
        }
        healthDisplay.text = health.ToString();

        if(health == 0) {
            // Bolso died
            Destroy(gameObject);
        }
    }
}
