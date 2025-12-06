using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 5f;
    public float damage = 10f;

    private Transform target;

    private void Start()
    {
        target = GameObject.Find("center").transform;
    }


    private void FixedUpdate()
    {
        Vector3 direction = target.position - transform.position;
        
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        
        
    }


    public void GetDamage(float damage)
    {
        
    }

    public void Damage(float damage)
    {
        
    }
}
