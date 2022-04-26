using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TankAI : MonoBehaviour
{
    Animator anim;
    [SerializeField] private GameObject player;
    public GameObject Player { get { return player; } set { player = value; } }

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject turret;

    public Health Health { get; set; }

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        Health = GetComponent<Health>();
        Health.Initialize(100);
    }

    private void Update()
    {
        if(player != null)
        {
            anim.SetFloat("distance", Vector3.Distance(this.transform.position, player.transform.position));
        }
        // This means Player is dead
        else
        {
            anim.SetFloat("distance", 100);
        }

        // Setting HP on FSM
        anim.SetFloat("health", Health.CurrentHealth);

        if (Health.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
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
