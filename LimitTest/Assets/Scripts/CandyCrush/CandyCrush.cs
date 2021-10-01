using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCrush : MonoBehaviour
{
    [SerializeField] private GameObject[] candies;
    GameObject[,] level = new GameObject[5,5];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                level[i,j]= Instantiate(candies[Random.Range(0,4)]);
                level[i,j].transform.position = new Vector3(-4+(j*2), 4-(i*2), -1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
