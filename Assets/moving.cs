using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float speed = 4.0f;
    static public float atk = 2.0f;
    public GameObject fireball;
    public GameObject firepoint;
    static public Vector2 mouse;
    static public Vector3 player;
    private Animator anime;
    private SpriteRenderer sr;
    private float fire = 0.0f;
    private float rate = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent <Animator>();
        sr = GetComponent <SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        player = gameObject.transform.position;
        Debug.Log(mouse);
        if (player.x - mouse.x < 0){
            sr.flipX = false;
        }
        if (player.x - mouse.x > 0){
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.D)){
            transform.localPosition += new Vector3(speed,0,0)*Time.deltaTime;
            anime.SetBool("move",true);
            //sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.A)){
            transform.localPosition += new Vector3(-speed,0,0)*Time.deltaTime;
            anime.SetBool("move",true);
            //sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.W)){
            transform.localPosition += new Vector3(0,speed,0)*Time.deltaTime;
            anime.SetBool("move",true);
        }
        if (Input.GetKey(KeyCode.S)){
            transform.localPosition += new Vector3(0,-speed,0)*Time.deltaTime;
            anime.SetBool("move",true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.UpArrow)||Input.GetKeyUp(KeyCode.DownArrow)){
            anime.SetBool("move",false);
        }
        if (Input.GetKey(KeyCode.Mouse0)){
            if (Time.time >= fire){
            fire = Time.time + rate;
            Instantiate(fireball,firepoint.gameObject.transform.position,firepoint.gameObject.transform.rotation);
        }
    }
}}

