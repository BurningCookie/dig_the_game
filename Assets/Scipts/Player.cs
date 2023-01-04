﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float distancetoground;
    private float gravity = 1f;
    public CharacterController crcon;
    public Transform groundcheck;
    public GameObject raycaster;
    public Rigidbody rb;
    public Animator picAnimator;
    public Animator cameraAnimator;
    public LayerMask groundLayerMask;
    Vector3 velocity;
    bool isGrounded;
    RaycastHit Orehit;

    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        //Ore-mining
        if (Input.GetButton("Fire1"))
        {
            
            if (picAnimator.GetBool("mine") != true)
            {
                picAnimator.SetBool("mine", true);
            }

            if (Physics.Raycast(raycaster.transform.position, raycaster.transform.forward, out Orehit, 4))
            {
                //Debug.Log(Orehit.collider.gameObject.name);
                GameObject ore = Orehit.collider.gameObject;
                if (ore.tag == "Ore")
                {
                    OreData d = ore.GetComponent<OreData>();
                    inventory.Add(d.GetId(), d.GetDropAmount());
                    Destroy(ore);
                }
            }
        }
        else
        {
            
            if (picAnimator.GetBool("mine") != false)
            {
                picAnimator.SetBool("mine", false);
            } 
        }

        isGrounded = Physics.CheckSphere(groundcheck.position, distancetoground, groundLayerMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        crcon.Move(move * speed * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        crcon.Move(velocity);

        //Moving Animation

        if(Input.GetKey("w") == true || Input.GetKey("s") == true || Input.GetKey("a") == true || Input.GetKey("d") == true)
        {
            cameraAnimator.SetBool("run", true);
        }
        else
        {
            cameraAnimator.SetBool("run", false);
        }

    }
}