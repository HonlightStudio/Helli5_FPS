using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 5f;
    public float damage = 10f;
    public GameObject deathEffect;
    private Transform target;
    private Objectpool pool;
    private void Start()
    {
        target = GameObject.Find("center").transform;
        pool = GameObject.Find("ObjectPool").GetComponent<Objectpool>();
    }


    private void FixedUpdate()
    {
        Vector3 direction = target.position - transform.position;
        
        transform.Translate((direction * speed * Time.deltaTime)/Mathf.Sqrt(direction.magnitude) , Space.World);
        
        
    }


    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            pool.ReleaseObject(gameObject);
        }
    }

    public void Damage(float damage)
    {
        
    }
}
