using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    static public float mobhp = 3.0f;
    public GameObject mob;
    public GameObject spawnpoint;
    private Vector3 position;
    private float spawn = 0.0f;
    private float rate = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }
//
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawn){
            spawn = Time.time + rate;
            Instantiate(mob,spawnpoint.gameObject.transform.position,spawnpoint.gameObject.transform.rotation);
        }
    }
    
}
