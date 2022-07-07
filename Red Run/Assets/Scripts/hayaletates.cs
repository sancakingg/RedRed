using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hayaletates : MonoBehaviour
{
    hayalet hayalet;
    Rigidbody2D fizik;

    void Start()
    {
        hayalet = GameObject.FindGameObjectWithTag("hayalet").GetComponent<hayalet>();
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(hayalet.getYon() * 1500);
    }

 
  
}
