using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damageDone;
    public float moveSpeed;
    public float lifespan;
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        //Move forward
        rb.MovePosition(transform.position + (transform.up * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageDone);
        }

        Destroy(gameObject);
    }
}
