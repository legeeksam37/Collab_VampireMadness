using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchBullet(Transform position)
    {
        GameObject newBall = Instantiate(this.gameObject, position.position, transform.rotation);
        newBall.transform.SetPositionAndRotation(position.position, newBall.transform.rotation);
        newBall.GetComponent<Rigidbody>().AddForce(position.forward * 1000);
    }
}
