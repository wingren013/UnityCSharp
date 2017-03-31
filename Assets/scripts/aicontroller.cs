using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class aicontroller : MonoBehaviour
    {
        Rigidbody rb;
        int score;
        int mv;
        int seed;
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.mass = 5;
            rb.AddForce(Vector3.forward * 400);
            rb.useGravity = true;
            mv = 2;
            seed = System.DateTime.Now.Millisecond / 1297;
            rb.drag = 0.4f;
        }

        // Update is called once per frame
        void Update()
        {
            this.seed += System.DateTime.Now.Second * 5;
            Random.InitState(this.seed);
            int rand = Random.Range(0, 6);
            if (rand == 0)
            {
                forwardmove();
            }
            if (rand == 1)
            {
                backmove();
            }
            if (rand == 2)
            {
                leftmove();
            }
            if (rand == 3)
            {
                rightmove();
            }
            if (rand == 4)
            {
                incrementmove();
            }
            else if (rand == 5)
            {
                decrementmove();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            rb.velocity = Vector3.Reflect(collision.relativeVelocity * -1, collision.contacts[0].normal);
            rb.AddForce(Vector3.down * rb.velocity.z);
        }

        void leftmove()
        {
            rb.AddForce(Vector3.left * mv);
        }

        void rightmove()
        {
            rb.AddForce(Vector3.right * mv);
        }

        void forwardmove()
        {
            rb.AddForce(Vector3.forward * mv);
        }

        void backmove()
        {
            rb.AddForce(Vector3.back * mv);
        }

        void incrementmove()
        {
            if (mv < 10)
                mv++;
        }

        void decrementmove()
        {
            if (mv > 1)
                mv--;
        }
    }
}
