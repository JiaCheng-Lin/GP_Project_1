using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase] 
public class Bird : MonoBehaviour
{
    // serializeField: can modify the value in unity
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 2; 
    private Vector2 _startPosition; 
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRender;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRender = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _rigidbody2D.position; // get current 2d position.
        _rigidbody2D.isKinematic = true; // just user can control it
    }

    void OnMouseDown()
    {
        _spriteRender.color = Color.red;
    }
    void OnMouseUp()
    {
        Vector2 currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _rigidbody2D.isKinematic = false; // dynamic
        _rigidbody2D.AddForce(direction * _launchForce);

        _spriteRender.color = Color.white;
    }
      
    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);// get mouse position
        Vector2 desiredPosition = mousePosition;
        
        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize(); // unit 2d vector
            desiredPosition = _startPosition + (direction * _maxDragDistance);
        }

        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        _rigidbody2D.position = desiredPosition;
        //transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z); // ignore z position
    }

    // Update is called once per frame
    void Update()
    {

    }

    // when collision happens(sprites, birds)
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay()); // ¨óµ{ 
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3); // 3 seconds
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
