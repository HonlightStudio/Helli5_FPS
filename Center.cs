using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Center : MonoBehaviour
{
    public Objectpool pool;
    public TextMeshProUGUI text;
    public Image flashImage;
    public float lives = 5;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter" + other.name);
        if (other.CompareTag("Enemy"))
        {
            lives--;
            flashImage.color = Color.red;
            text.text = "Lives: " + lives;
            pool.ReleaseObject(other.gameObject);
        }
    }
}
