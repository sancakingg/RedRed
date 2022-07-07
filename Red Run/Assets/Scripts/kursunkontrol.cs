using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kursunkontrol : MonoBehaviour
{
    DüşmanKontrol dusman;
    Rigidbody2D fizik;
    
    void Start()
    {
       
        dusman = GameObject.FindGameObjectWithTag("düşman").GetComponent<DüşmanKontrol>();
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(dusman.getYon()*1000);
    }

    

}
