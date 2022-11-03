using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSpell : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float launchForce;

    private PlayerStats stats;

    void Start()
    {
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
        GameObject _newBall = Instantiate(gameObject, position.position, position.rotation);
        _newBall.GetComponent<Rigidbody>().AddForce(position.forward * launchForce);
        _newBall.gameObject.transform.SetParent(GameObject.Find("GameObjects").gameObject.transform);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Vampire" || collision.gameObject.tag == "Zombie")
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            enemyStats.PV -= damage;
        }
    }
}
