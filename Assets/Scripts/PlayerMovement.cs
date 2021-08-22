using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell
{
    public class PlayerMovement : MonoBehaviour
    {
        public GameObject[] guns;
        public float MoveSpeed,jumpForce;
        private float input;
        private Vector2 mousePos;
        private Animator animator;
        private Rigidbody2D rigidbody;
        public BoxCollider2D myFeet;
        private int gunNum;
        private bool isGround;
        void Start()
        {
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
            guns[0].SetActive(true);
        }

        void Update()
        {
            SwitchGun();
            isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
            input = Input.GetAxisRaw("Horizontal");
            //input.y = Input.GetAxisRaw("Vertical");

             rigidbody.velocity = new Vector2(input * MoveSpeed, rigidbody.velocity.y);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }

            if (Input.GetButtonDown("Jump") && isGround == true)
            {
                rigidbody.velocity = new Vector2(0, jumpForce);
                animator.SetTrigger("Jump");
            }

            if (input != 0)
                animator.SetBool("isMoving", true);
            else
                animator.SetBool("isMoving", false);
        }

        void SwitchGun()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                guns[gunNum].SetActive(false);
                if (--gunNum < 0)
                {
                    gunNum = guns.Length - 1;
                }
                guns[gunNum].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                guns[gunNum].SetActive(false);
                if (++gunNum > guns.Length - 1)
                {
                    gunNum = 0;
                }
                guns[gunNum].SetActive(true);
            }
        }

        public void GetHit()
        {
             animator.SetTrigger("Hurt");
        }
    }
}