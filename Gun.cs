using UnityEngine;

public class Gun : MonoBehaviour
{
    public RectTransform aim;
    public float range;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

   
    public void Shoot()
    {
        Vector3 aimpos = mainCamera.ScreenToWorldPoint(aim.position);
        bool hited = Physics.Raycast(aimpos, mainCamera.transform.forward, out RaycastHit hit,range);
        if (hited)
        {
            Debug.unityLogger.Log(hit.collider.name);
        }
    }
}
