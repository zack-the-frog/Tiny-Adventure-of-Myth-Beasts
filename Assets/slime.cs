using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public float speed = 1.0f;
    private Animator anime;
    private SpriteRenderer sr;
    private Vector3 aim;
    static public Vector3 mobposition;
    public float hp;
    private float dying = 1.8f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(5.5f,2,-2);
        anime = GetComponent <Animator>();
        sr = GetComponent <SpriteRenderer>();
        hp = box.mobhp;
    }
    // Update is called once per frame
    void Update()
    {
        aim = moving.player;
        mobposition = gameObject.transform.position;
        if (hp > 0){
            if (aim.x - mobposition.x > 0) {
            transform.localPosition += new Vector3(speed,0,0)*Time.deltaTime;
            sr.flipX = true;
            }
            if (aim.x - mobposition.x < 0) {
                transform.localPosition += new Vector3(-speed,0,0)*Time.deltaTime;
                sr.flipX = false;
            }
            if (aim.y - mobposition.y > 0) {transform.localPosition += new Vector3(0,speed,0)*Time.deltaTime;}
            if (aim.y - mobposition.y < 0) {transform.localPosition += new Vector3(0,-speed,0)*Time.deltaTime;}
        }
        else {
            anime.SetBool("die",true);
            Invoke("destroy",dying);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "fireball(Clone)"){
            hp -= moving.atk;
        }
    }
    void destroy(){
        Destroy(gameObject);
    }
}
