using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
   
    void Start()
    {
       // XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //grabbable.activated.AddListner(FireBullet);
    }

    public void FireBullet()
    {
    GameObject spawnedBullet = Instantiate(bullet);
    spawnedBullet.transform.position =spawnPoint.position;
    spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward *fireSpeed;
    Debug.Log("bullllllllllllllllllllllllllllllleeeeeeeeeeet");
    Destroy(spawnedBullet, 5f);
    }
}
