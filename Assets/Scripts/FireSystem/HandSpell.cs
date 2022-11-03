using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HandSpell : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float launchForce;

    private PlayerStats stats;

    public PhotonView view;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            stats = player.GetComponent<PlayerStats>();
        }
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        damage *= stats.SpellsPower;
    }

    public void LaunchBullet(Transform position)
    {
        GameObject _newBall = PhotonNetwork.Instantiate(gameObject.name, position.position, position.rotation);
        _newBall.GetComponent<Rigidbody>().AddForce(position.forward * launchForce);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null && view.IsMine == true)
        {
            PhotonNetwork.Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(damage, stats);
        }
    }
}
