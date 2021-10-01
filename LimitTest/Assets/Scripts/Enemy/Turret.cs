using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Range and Fire")]
    public float range = 15f;

    /* //shooting
    public float fireRate = 1f;
    float fireCountDown = 0f; */

    [Header("Player setup")]
    public string PlayerTag = "Player";

    //rotation
    public Transform RotatingPart;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget(){
        GameObject[] players = GameObject.FindGameObjectsWithTag(PlayerTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        //find player
        foreach (GameObject player in players){
            float distanceToPLayer = Vector3.Distance(transform.position, player.transform.position);

            if(distanceToPLayer < shortestDistance){
                shortestDistance = distanceToPLayer;
                nearestPlayer = player;
            }
        }

        if (nearestPlayer != null && shortestDistance <= range){
            target = nearestPlayer.transform;
        }else{
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            return;
        }
        
        //rotate the turret 
        Vector3 dir = target.position - transform.position;
        Quaternion lookAround = Quaternion.LookRotation(dir);
        Vector3 rotation = lookAround.eulerAngles;
        RotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);


    }
         private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
