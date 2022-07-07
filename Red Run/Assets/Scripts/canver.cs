using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canver : MonoBehaviour
{
    public Sprite []animasyonkareleri;
    SpriteRenderer spriteRenderer;
    float zaman = 0;
    int animasyonkaresayac = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman>0.1f)
        {
            spriteRenderer.sprite = animasyonkareleri[animasyonkaresayac++];
            if (animasyonkareleri.Length==animasyonkaresayac)
            {
                animasyonkaresayac = animasyonkareleri.Length-1;
            }
            zaman = 0;
        }
        
    }
}
