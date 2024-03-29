﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagicBulletController : MonoBehaviour {

    
    
    public GameObject explosion;
    public MagicBullet magicBullet;
    private Rigidbody2D body;
    public bool isRight = false;
    public int speed = 400;



	// Use this for initialization
	void Start () {
        magicBullet = new MagicBullet();
        magicBullet.speed = speed;
        magicBullet.collided = false;
        

        if (!isRight)
        {
            magicBullet.speed = -magicBullet.speed;
        }

        body = GetComponent<Rigidbody2D>();
        if (magicBullet.collided)
        {
            body.velocity = Vector3.zero;
        }
        else
        {
            body.velocity = new Vector2(magicBullet.speed, body.velocity.y);
        }
        
        StartCoroutine("timeToLive");
        gameObject.GetComponent<Collider2D>().isTrigger = true;
	}

	
	// Update is called once per frame
	void Update () {
        if (magicBullet.collided)
        {
            body.velocity = Vector3.zero;
            
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.ToString().Equals("Enemy"))
        {
            gameObject.GetComponent<Animator>().SetBool("Explode", true);
            magicBullet.collided = true;
            changeSize();

            StopCoroutine("timeToLive");
            StartCoroutine("collision");
        }
        else if (coll.tag.ToString().Equals("Ground") || coll.tag.ToString().Equals("Platform"))
        {
            magicBullet.collided = true;
            gameObject.GetComponent<Animator>().SetBool("Explode", true);
            StartCoroutine("collision");
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag.ToString().Equals("Enemy"))
        {
            transform.position = coll.transform.position;
        }
        
    }

    IEnumerator collision()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }


    IEnumerator timeToLive()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }


    private void changeSize()
    {
        gameObject.transform.localScale = new Vector2(128f, 128f);
    }

    

}


