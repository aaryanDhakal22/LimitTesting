using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Rotation")]
    private Transform target;
    public float range = 15f;
    public string PlayerTag = "Player";

    public Transform partToRotate;

       [Header("Shooting")]
    //shooting
    
    public float fireRate = 1f; //1 bullet each sec
    float fireCountDown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget(){

        GameObject[] players = GameObject.FindGameObjectsWithTag(PlayerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;


        foreach (GameObject player in players){
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToPlayer < shortestDistance ){
                shortestDistance = distanceToPlayer;
                nearestPlayer = player;
            }
        }

        if(nearestPlayer != null && shortestDistance <= range){
            target = nearestPlayer.transform;
        } else{
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            return;
        }

          Vector3 dir = target.position - transform.position;
          Quaternion lookRotation = Quaternion.LookRotation(dir);
          Vector3 rotation = lookRotation.eulerAngles;
          partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


          
          //shooting
          if(fireCountDown <= 0f){
              Shoot();
              fireCountDown = 1f/fireRate;
          }

          fireCountDown -= Time.deltaTime;


    }
    void Shoot(){
       GameObject BulletGO = (GameObject) Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
       Bullet bullet = BulletGO.GetComponent<Bullet>();

       if(bullet != null){
           bullet.Seek(target);
       }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range); 
    }
}
