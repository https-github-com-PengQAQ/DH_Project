using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject explosionPrefab;
    new private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        exp.transform.position = transform.position;

        // Destroy(gameObject);

        if(other.gameObject.layer == 11 || other.gameObject.layer == 9)
        //LayerMask("Ground")
            ObjectPool.Instance.PushObject(gameObject);
        // if(other.layer == "Ground" || other.CompareTag == "Enemy")
        //     ObjectPool.Instance.PushObject(gameObject);
        // if()
        if(other.gameObject.layer == 11)
            other.GetComponent<FSM>().GetHit(Vector2.right);
    }
    
}
