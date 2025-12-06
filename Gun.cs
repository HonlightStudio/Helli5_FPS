using UnityEngine;

public class Gun : MonoBehaviour
{
    public RectTransform aim;
    public float range;
    public float damage;
    public ParticleSystem muzzleFlash;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

   
    public void Shoot()
    {
        muzzleFlash.Play();
        Vector3 aimpos = mainCamera.ScreenToWorldPoint(aim.position);
        bool hited = Physics.Raycast(aimpos, mainCamera.transform.forward, out RaycastHit hit,range);
        if (hited)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<Enemy>().GetDamage(damage);
            }
        }
    }
}
