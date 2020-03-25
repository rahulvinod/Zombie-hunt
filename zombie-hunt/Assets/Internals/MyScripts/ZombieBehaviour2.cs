﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour2 : MonoBehaviour
{
    public bool Killed;
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D Col;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Col = GetComponent<BoxCollider2D>();
        Killed = false;
        
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        { 
            Killed = true;
            anim.enabled = false;
            RemoveRigidbody();
            StartCoroutine(WaitTime());
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public void RemoveRigidbody()
    {
        Col.enabled = false;
        rb.freezeRotation = false;
    }
}
