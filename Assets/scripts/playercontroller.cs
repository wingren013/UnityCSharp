using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

namespace player
{
    //for our players
    public class playercontroller : MonoBehaviour
    {

        GameObject player;
        Rigidbody rb;
        int score;
        int mv;
        string enemy;
        int t;
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("p1");
            rb = GetComponent<Rigidbody>();
            rb.mass = 1;
            rb.AddForce(Vector3.forward * 100);
            rb.useGravity = true;
            score = 0;
            mv = 2;
            rb.drag = 0.4f;
            enemy = "p2";
            t = 0;
        }

        private void OnGUI()
        {
            GUI.Box(new Rect(10, 10, 100, 90), "Score: " + score);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                forwardmove();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                backmove();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                leftmove();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rightmove();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                incrementmove();
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                decrementmove();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            rb.velocity = Vector3.Reflect(collision.relativeVelocity * -1, collision.contacts[0].normal);
            rb.AddForce(Vector3.down * rb.velocity.z);
            if (collision.gameObject.name == enemy)
                score += 100;
        }

        private void FixedUpdate()
        {
            if (t + 1 < Time.realtimeSinceStartup)
            {
                score -= 10;
                t += (int)Time.deltaTime;
            }
        }

        void jump()
        {
            if (rb.velocity.y < 1)
            {
                rb.AddForce(Vector3.up * 400);
            }
        }

        void leftmove()
        {
            rb.AddForce(Vector3.left * mv);
        }

        void rightmove()
        {
            rb.AddForce(Vector3.right * mv);
        }

        void   forwardmove()
        {
            rb.AddForce(Vector3.forward * mv);
        }
        
        void    backmove()
        {
            rb.AddForce(Vector3.back * mv);
        }

        void    incrementmove()
        {
            if (mv < 10)
                mv++;
        }

        void    decrementmove()
        {
            if (mv > 1)
                mv--;
        }
    }
}
