using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed = 1.0f;
    private SpriteRenderer sr;
    private Vector3 aim;
    private Vector3 source;
    private Vector3 route;
    public float damage;
    private float duration = 2.0f;
    private float explode = 1.8f;
    private Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent <SpriteRenderer>();
        aim = moving.mouse;
        source = moving.player;
        route = aim - source;
        duration += Time.time;
        rotate = new Vector3(0.0f,0.0f,Mathf.Atan(route.y/route.x)* Mathf.Rad2Deg);
        transform.rotation =  Quaternion.Euler(rotate);
        if (route.x > 0) {
            sr.flipX = false;
        }
        if (route.x < 0) {
            sr.flipX = true
            ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time <= duration) {
            transform.Translate(route * speed * Time.deltaTime);
        }
        if (Time.time > duration) {
            Invoke("destroy",explode);
        }
    }
    void destroy(){
        Destroy(gameObject);
    }
}

