using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectcontrol : MonoBehaviour
{
    MeshRenderer rend;
    public int i_cord = 0;
    public int j_cord = 0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    private void OnMouseDown( )
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1);

        
        if (!CandyCrush.one)
        {
            CandyCrush.one = gameObject;
            CandyCrush.onemat = rend.material.color;
            rend.material.color = Color.cyan;
        }
        else
        {
            CandyCrush.two = gameObject;
            CandyCrush.twomat = rend.material.color;
            rend.material.color = Color.cyan;
        }

    }
}
