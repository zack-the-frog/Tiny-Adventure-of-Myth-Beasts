using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody2D rd;
    private Vector2 movedir;
    private Animator anime;
    private SpriteRenderer sr;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            movedir.x = speed;
            anime.SetFloat("speed",1);
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            movedir.x = -speed;
            anime.SetFloat("speed",1);
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            movedir.y = speed;
            anime.SetFloat("speed",1);
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            movedir.y = -speed;
            anime.SetFloat("speed",1);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.UpArrow)||Input.GetKeyUp(KeyCode.DownArrow)){
            movedir = Vector2.zero;
            anime.SetFloat("speed",0);
        }
        rd.velocity = movedir;
    }
} 
