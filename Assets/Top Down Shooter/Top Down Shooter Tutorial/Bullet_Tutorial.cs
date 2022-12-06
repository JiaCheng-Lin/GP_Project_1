using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet_Tutorial : MonoBehaviour
{
    public float bullet_speed = 4;
    public float bullet_duration = 4;

    Rigidbody2D bullet_rigidbody;

    public GameObject explosionPrefab;

    private void Awake()
    {
        bullet_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("DestroyBullet", bullet_duration);
    }

    private void FixedUpdate()
    {
        bullet_rigidbody.MovePosition(transform.position + transform.right * bullet_speed * Time.fixedDeltaTime);
    }

    void DestroyBullet() 
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        exp.transform.position = transform.position;

        bullet_rigidbody.velocity = Vector2.zero;
        StartCoroutine(Push(gameObject, .1f));
    }

    IEnumerator Push(GameObject _object, float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPool.Instance.PushObject(_object);
    }
}
