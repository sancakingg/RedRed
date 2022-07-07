using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altın : MonoBehaviour
{
    public Sprite[] animasyonkareleri;
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
        if (zaman > 0.05f)
        {
            spriteRenderer.sprite = animasyonkareleri[animasyonkaresayac++];
            if (animasyonkareleri.Length == animasyonkaresayac)
            {
                animasyonkaresayac =0;
            }
            zaman = 0;
        }
    }
}
