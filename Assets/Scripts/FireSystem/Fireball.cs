using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float damage;
    private PlayerStats stats;

    void Start()
    {
        damage = 1;
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            stats = player.GetComponent<PlayerStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        damage *= stats.SpellsPower;
    }

    public void LaunchBullet(Transform position)
    {
        int _throwForce = 1000;
        GameObject _newBall = Instantiate(gameObject, position.position, position.rotation);
        _newBall.GetComponent<Rigidbody>().AddForce(position.forward * _throwForce);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Destroy(gameObject);
        }
    }
}
