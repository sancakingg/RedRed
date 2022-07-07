using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class hayalet : MonoBehaviour
{
    GameObject[] gidilecekNoktalar;
    bool aradakiMesafeyiBirKereAl = true;
    Vector3 aradakiMesafe;
    int aradakiMesafeSayaci = 0;
    bool ilerimigerimi = true;
    GameObject karakter;
    RaycastHit2D ray;
    public LayerMask layermask;
    float hiz = 7;
    SpriteRenderer görüntü;
    public GameObject kursun;
    float ateszamani = 0;
    void Start()
    {
        gidilecekNoktalar = new GameObject[transform.childCount];
        karakter = GameObject.FindGameObjectWithTag("Player");
        görüntü = GetComponent<SpriteRenderer>();
        for (int i = 0; i < gidilecekNoktalar.Length; i++)
        {
            gidilecekNoktalar[i] = transform.GetChild(0).gameObject;
            gidilecekNoktalar[i].transform.SetParent(transform.parent);
        }

    }


    void FixedUpdate()
    {

        beniGordumu();
        if (ray.collider.tag == "Player")
        {
            hiz = 11f;
            
            ateset();
        }
        else
        {
            hiz = 3;
           
        }
        noktalaraGit();


    }

    void ateset()
    {
        ateszamani += Time.deltaTime;
        if (ateszamani > Random.Range(0.2f, 1))
        {
            Instantiate(kursun, transform.position, Quaternion.identity);
            ateszamani = 0;
        }
    }
    void beniGordumu()
    {
        Vector3 rayYonum = karakter.transform.position - transform.position;
        ray = Physics2D.Raycast(transform.position, rayYonum, 1000, layermask);
        Debug.DrawLine(transform.position, ray.point, Color.red);
    }

    void noktalaraGit()
    {
        if (aradakiMesafeyiBirKereAl)
        {
            aradakiMesafe = (gidilecekNoktalar[aradakiMesafeSayaci].transform.position - transform.position).normalized;
            aradakiMesafeyiBirKereAl = false;
        }
        float mesafe = Vector3.Distance(transform.position, gidilecekNoktalar[aradakiMesafeSayaci].transform.position);
        transform.position += aradakiMesafe * Time.deltaTime * hiz;
        if (mesafe < 0.5f)
        {
            aradakiMesafeyiBirKereAl = true;
            if (aradakiMesafeSayaci == gidilecekNoktalar.Length - 1)
            {
                ilerimigerimi = false;
            }
            else if (aradakiMesafeSayaci == 0)
            {
                ilerimigerimi = true;
            }
            if (ilerimigerimi)
            {
                aradakiMesafeSayaci++;
            }
            else
            {
                aradakiMesafeSayaci--;
            }
        }
    }
    public Vector2 getYon()
    {
        return (karakter.transform.position - transform.position).normalized;
    }



#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1);
        }
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);
        }
    }
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(hayalet))]
[System.Serializable]
class hayaletEditor : Editor
{
    public override void OnInspectorGUI()
    {
        hayalet script = (hayalet)target;
        if (GUILayout.Button("ÜRET", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            GameObject yeniObjem = new GameObject();
            yeniObjem.transform.parent = script.transform;
            yeniObjem.transform.position = script.transform.position;
            yeniObjem.name = script.transform.childCount.ToString();
        }
        EditorGUILayout.PropertyField(serializedObject.FindProperty("layermask"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("kursun"));
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();

    }
}
#endif
