using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monster_apple : MonoBehaviour
{
    // [SerializeField] Sprite _deadSprite;
    // [SerializeField] ParticleSystem _particleSystem;
    private bool _hasDied = false;
    public float speed ;

    void OnCollisionEnter2D(Collision2D collision)
    {
        ///Debug.Log("111");
        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        _hasDied = true;
        //GetComponent<SpriteRenderer>().sprite = _deadSprite;
        //_particleSystem.Play();  
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false); // monster disappear
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        if (_hasDied)
            return false;

        // if collision with bullets
        
        Rocket rocket = collision.gameObject.GetComponent<Rocket>();
        //Debug.Log("Rocket" + rocket);
        if (rocket != null)
            return true;

        return false;
        /*
        // if collision with bird.
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
            return true;

        if (collision.contacts[0].normal.y < -0.5)
            return true;

        return false;*/
    }
    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

}
