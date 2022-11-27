using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class fruit : MonoBehaviour
{

    public GameObject fruitslices;
    Rigidbody2D _rigidbody2D;
    public float startforce = 15;
    

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(transform.up*startforce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "blade")
        {
            Vector3 rotation=(collision.transform.position - transform.position).normalized;
            Quaternion quart=Quaternion.LookRotation(rotation);
            Destroy(this.gameObject);
            Instantiate(fruitslices,transform.position,quart);
            spawner.score += 1;
            spawner.scoretext.text = "score : " + spawner.score;
        }

    }
}
