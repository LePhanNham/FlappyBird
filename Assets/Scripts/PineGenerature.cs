using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PineGenerature : MonoBehaviour
{
    List<GameObject> list = new List<GameObject>();
    public GameObject pinePrefab;
    private float countdown;
    public float timeduration;
    public bool check = false;
    GameObject getPine()
    {
        if (list.Count >=2)
        {
            foreach (var x in list)
            {
                x.transform.position = new Vector3(2, Random.Range(1f, 4.5f), 0);
                x.SetActive(true);
                return x;
            }
        }
        GameObject y = Instantiate<GameObject>(pinePrefab, new Vector3(2, Random.Range(1f, 4.5f), 0), Quaternion.identity);
        y.SetActive(true);
        list.Add(y);
        return y;
    }
    void Start()
    {
        countdown = timeduration;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            check = true;
        }
        if (check)
        {
            countdown -= Time.deltaTime;
            if (countdown < 0)
            {
                //Instantiate(pinePrefab, new Vector3(2, Random.Range(1f, 4.5f), 0), Quaternion.identity);
                getPine();
                countdown = timeduration;
            }
        }

    }
    
}
