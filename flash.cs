using System;
using UnityEngine;
using UnityEngine.UI;

public class flash : MonoBehaviour
{
    private Image flashImage;

    private void Start()
    {
        flashImage = GetComponent<Image>();
    }

    void Update()
    {
        flashImage.color = new Color(1f, 0, 0, Mathf.SmoothStep(flashImage.color.a, 0f,0.05f));
    }
}
