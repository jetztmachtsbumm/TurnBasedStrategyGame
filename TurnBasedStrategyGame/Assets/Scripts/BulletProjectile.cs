using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    
    public static BulletProjectile Instance { get; private set; }

    private GameObject trail;
    private GameObject bulletHitVFX;
    private Vector3 targetPosition;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        gameObject.SetActive(false);
        trail = transform.Find("Trail").gameObject;
        bulletHitVFX = transform.Find("BulletHitVFX").gameObject;
    }

    private void Update()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;

        float distanceBeforeMoving = Vector3.Distance(transform.position, targetPosition);

        float moveSpeed = 200f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float distanceAfterMoving = Vector3.Distance(transform.position, targetPosition); 

        if(distanceBeforeMoving < distanceAfterMoving)
        {
            transform.position = targetPosition;
            trail.transform.parent = null;
            bulletHitVFX.transform.parent = null;
            bulletHitVFX.SetActive(true);
            bulletHitVFX.GetComponent<ParticleSystem>().Play();
            gameObject.SetActive(false);
        }
    }

    public void Setup(Vector3 shootPointPosition, Vector3 targetPosition)
    {
        gameObject.SetActive(true);
        trail.transform.parent = transform;
        bulletHitVFX.transform.parent = transform;
        transform.position = shootPointPosition;
        this.targetPosition = targetPosition;
    }

}
