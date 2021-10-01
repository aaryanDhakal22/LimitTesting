
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CandyCrush : MonoBehaviour
{
    [SerializeField] private GameObject[] candies;

    public static GameObject one;
    public static Color onemat;
    public static GameObject two;
    public static Color twomat;
    public static int[] one_cord= new int[2];
    public static int[] two_cord = new int[2];
    public static GameObject temp_cord;


    GameObject[,] level = new GameObject[5,5];
    Vector3 transTemp;
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
        Exchange();
    }
    void Exchange()
    {
        if (one)
        {
            if (two)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (level[i, j] == one)
                        {
                            one_cord[0] = i;
                            one_cord[1] = j;

                        }
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (level[i, j] == two)
                        {
                            two_cord[0] = i;
                            two_cord[1] = j;

                        }
                    }
                }
                
                transTemp = one.transform.position;
                one.transform.position = two.transform.position;
                two.transform.position = transTemp;


                temp_cord = level[one_cord[0], one_cord[1]];


                Debug.Log(level[one_cord[0], one_cord[1]]);
                Debug.Log(level[two_cord[0], two_cord[1]]);


                level[one_cord[0], one_cord[1]] = level[two_cord[0], two_cord[1]];
                level[two_cord[0], two_cord[1]] = temp_cord;


                Debug.Log(level[one_cord[0], one_cord[1]]);
                Debug.Log(level[two_cord[0], two_cord[1]]);



                one.transform.localScale = new Vector3(1f, 1f, 1);
                one.GetComponent<MeshRenderer>().material.color = onemat;
                two.transform.localScale = new Vector3(1f, 1f, 1);
                two.GetComponent<MeshRenderer>().material.color = twomat;
                one = null;
                two = null;
                checkfor3();
            }
        }
    }

    void checkfor3() 
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (j<3 && level[i,j].tag == level[i, j + 1].tag)
                {
                    if (level[i, j].tag == level[i, j + 2].tag) //right
                    {
                        level[i, j].transform.localScale = new Vector3(0, 0, 0);
                        level[i, j+1].transform.localScale = new Vector3(0, 0, 0);
                        level[i, j+2].transform.localScale = new Vector3(0, 0, 0);
                        Debug.Log("match right");
                    }
                    
                }
                if (j > 2 && level[i, j - 1].name == level[i, j - 1].name) //left
                {
                    if (level[i, j].name == level[i, j - 2].name) //left
                    {
                        level[i, j].transform.localScale = new Vector3(0, 0, 0);
                        level[i, j - 1].transform.localScale = new Vector3(0, 0, 0);
                        level[i, j - 2].transform.localScale = new Vector3(0, 0, 0);
                        Debug.Log("match left");
                    }
                }
                if (i > 2 && level[i, j].name == level[i - 1, j].name) //up
                {
                    if (level[i, j].name == level[i - 2, j].name) //up
                    {
                        level[i, j].transform.localScale = new Vector3(0, 0, 0);
                        level[i-1, j ].transform.localScale = new Vector3(0, 0, 0);
                        level[i-2, j ].transform.localScale = new Vector3(0, 0, 0);
                        Debug.Log("match up");
                    }
                }
                if (i < 3 && level[i, j].name == level[i + 1, j].name) //dowm
                {
                    if (level[i, j].name == level[i + 2, j].name) //dowm
                    {
                        level[i, j].transform.localScale = new Vector3(0, 0, 0);
                        level[i+1, j].transform.localScale = new Vector3(0, 0, 0);
                        level[i+2, j ].transform.localScale = new Vector3(0, 0, 0);
                        Debug.Log("match down");
                    }
                }

            }
        }
    }
}
