using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

}
