using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityStandardAssets.CrossPlatformInput;


public class KarakterKontrol : MonoBehaviour
{
    
    public Sprite[] beklemeAnim;
    public Sprite[] ziplamaAnim;
    public Sprite[] yürümeAnim;
    public Text canText;
    public Text gold;
   
    public Image SiyahPlan;
    int can = 100;
    int altın = 0;
   
    SpriteRenderer spriteRendere;

    int beklemeanimsayac=0;
    int yürümeanimsayac=0;

    Rigidbody2D fizik;
   
    
    Vector3 vec;
    Vector3 sonhiz;
    Vector3 kamerasonpos;
    Vector3 kamerailkpos;
    
    float horizontal = 0;
    float beklemeanimzaman=0;
   
    float yürümeanimzaman = 0;
    float siyahplansayac;
    float anamenuzaman=0;

    
    bool tekzip = true;
    GameObject kamera;
  
    
    
    
    void Start()
    {
       
        SiyahPlan.gameObject.SetActive(false);
        spriteRendere = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();

     
        kamera = GameObject.FindGameObjectWithTag("MainCamera");

        if (SceneManager.GetActiveScene().buildIndex>PlayerPrefs.GetInt("kacincilevel"))
        {
            PlayerPrefs.SetInt("kacincilevel", SceneManager.GetActiveScene().buildIndex);
        }

        
        
        kamerailkpos = kamera.transform.position - transform.position;
        canText.text = "HEALTH   " + can;
        gold.text = "GOLD  " + altın;
    }
     void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetButton("Jump"))
        {
            if (tekzip)
            {
                fizik.AddForce(new Vector2(0, 500));
                tekzip = false;
            }
        }
        
    }
    void FixedUpdate()
    {
        karakterHareket();
        Animasyon();
        if (can<=0)
        {
            Time.timeScale = 0.4f;
            sonhiz = new Vector3(0, 0, 0);
            fizik.velocity = sonhiz;
            transform.Rotate(0,0,1.5f);
            beklemeanimsayac = 1;
            yürümeanimsayac = 1;

            canText.enabled = false;
            siyahplansayac += 0.03f;
            SiyahPlan.gameObject.SetActive(true);
            SiyahPlan.color = new Color(0, 0, 0, siyahplansayac);
            anamenuzaman += Time.deltaTime;
            if (anamenuzaman>1)
            {
                SceneManager.LoadScene("Ana Menü");
            }
        }
    }
     void LateUpdate()
    {
        kamerakontrol();
    }
    void karakterHareket()
    {

        //horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        //vec = new Vector3(horizontal * 10,fizik.velocity.y, 0);  
        //fizik.velocity = vec;

        horizontal = Input.GetAxis("Horizontal");
        vec = new Vector3(horizontal * 10, fizik.velocity.y, 0);
        fizik.velocity = vec;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        tekzip = true;
    }
     void OnTriggerEnter2D(Collider2D col)
    {
      

        if (col.gameObject.tag == "kursun")
        {
            can -= 5;
            canText.text = "HEALTH   " + can;
            Destroy(col.gameObject, 0.01f);
        }
        if (col.gameObject.tag=="düşman")
        {
            can -= 10;
            canText.text = "HEALTH   " + can;
        }
        if (col.gameObject.tag == "Saw")
        {
            can -= 10;
            canText.text = "HEALTH   " + can;
        }

        if (col.gameObject.tag == "levelbitsin")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        if (col.gameObject.tag == "portalbitis")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (col.gameObject.tag == "canver")
        {
            if (can<=90)
            {
                can += 10;
                canText.text = "HEALTH   " + can;
                col.GetComponent<BoxCollider2D>().enabled = false;
                col.GetComponent<canver>().enabled = true;
                Destroy(col.gameObject, 1);
            }
            else
            {
                can = 100;
                canText.text = "HEALTH   " + can;
                col.GetComponent<BoxCollider2D>().enabled = false;
                col.GetComponent<canver>().enabled = true;
                Destroy(col.gameObject, 1);
            }
        }
        if (col.gameObject.tag == "altın")
        {
            
            altın += 2;
            
            gold.text = "GOLD  "+altın;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "su")
        {
            
            can = 0;
        }
        if (col.gameObject.tag == "sonalt")
        {
            can = 0;
            
        }
    }
    void kamerakontrol()
    {
        kamerasonpos = kamerailkpos + transform.position;
        kamera.transform.position =Vector3.Lerp(kamera.transform.position, kamerasonpos,0.1f) ;
    }
    void Animasyon()
    {
        if (tekzip)
        {
            if (horizontal == 0)
            {
                beklemeanimzaman += Time.deltaTime;
                if (beklemeanimzaman > 0.05)
                {
                    spriteRendere.sprite = beklemeAnim[beklemeanimsayac++];
                    if (beklemeanimsayac == beklemeAnim.Length)
                    {
                        beklemeanimsayac = 0;
                    }
                    beklemeanimzaman = 0;
                }

            }
            else if (horizontal > 0)
            {
                yürümeanimzaman += Time.deltaTime;
                if (yürümeanimzaman > 0.01f)
                {
                    spriteRendere.sprite = yürümeAnim[yürümeanimsayac++];
                    if (yürümeanimsayac == yürümeAnim.Length)
                    {
                        yürümeanimsayac = 0;
                    }
                    yürümeanimzaman = 0;
                }
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                yürümeanimzaman += Time.deltaTime;
                if (yürümeanimzaman > 0.01f)
                {
                    spriteRendere.sprite = yürümeAnim[yürümeanimsayac++];
                    if (yürümeanimsayac == yürümeAnim.Length)
                    {
                        yürümeanimsayac = 0;
                    }
                    yürümeanimzaman = 0;
                }
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (fizik.velocity.y>0)
            {
               
                spriteRendere.sprite = ziplamaAnim[0];
                
            }
            else
            {
                spriteRendere.sprite = ziplamaAnim[1];
            }
            if (horizontal>0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal<0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
    
}
