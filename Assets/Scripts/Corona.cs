using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona : MonoBehaviour
{
    //
    public float minSpeed;
    public float maxSpeed;
    public int damage;

    float speed;
    Bolsonaro bolsoScript;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        bolsoScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Bolsonaro>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime); 
    }

    void OnTriggerEnter2D(Collider2D coronaObj) {
        if(coronaObj.tag == "Player") {
            bolsoScript.TakeDamage(damage);
            Destroy(gameObject);
        }

        if(coronaObj.tag == "Ground") {
            Destroy(gameObject);
        }
    }
}
