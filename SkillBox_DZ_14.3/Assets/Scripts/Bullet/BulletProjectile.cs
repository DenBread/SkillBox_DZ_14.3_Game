using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;


    private Rigidbody bulletRigidbody;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 40f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BulletTarget>() != null)
        {
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            if (other.GetComponent<Rigidbody>())
            {
                other.GetComponent<Rigidbody>().AddForce(transform.forward * 5000f);
            }
        }
        else
        {
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }

        if (other.GetComponent<BreakableWindow>())
        {
            other.GetComponent<BreakableWindow>().breakWindow();
        }
        

        Destroy(gameObject);
    }

}
