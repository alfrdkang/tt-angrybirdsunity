using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public float timeAlive = 5f;
    private float createTime;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - createTime > timeAlive)
        {
            Destroy(gameObject);
        }
    }
}
