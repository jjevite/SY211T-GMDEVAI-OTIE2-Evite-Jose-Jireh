using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject turret;

    public Health Health { get; set; }

    private void Start()
    {
        Health = GetComponent<Health>();
        Health.Initialize(100);
    }
    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            StartFiring();
        }
        else if(Input.GetButtonUp("Jump"))
        {
            StopFiring();
        }

        if(Health.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(Health.CurrentHealth);
    }

    private void Fire()
    {
        GameObject iBullet = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        iBullet.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }
    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }
}
