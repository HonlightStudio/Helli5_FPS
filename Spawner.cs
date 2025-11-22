using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    public float radius;
    public float spawnRate;
    public Objectpool pool;

    private float _timer;
    
    // X^2 + Z^2 = R^2
    // z = sqrt(R^2 - X^2)
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 1/spawnRate)
        {
            float X = Random.Range(-radius, radius);
            float Z = Mathf.Sqrt(radius * radius - X*X) * Mathf.Pow(-1,Random.Range(0,2));
            pool.GetObject(new Vector3(X + transform.position.x, transform.position.y , Z + transform.position.z), transform.rotation);
            _timer = 0;
        }
    }
}
