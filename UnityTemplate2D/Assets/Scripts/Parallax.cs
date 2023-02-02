using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;

    [SerializeField]
    float parallaxContinuousEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector2.left * parallaxContinuousEffect * Time.deltaTime);

        if (transform.position.x < startPos - length)
            transform.position = new Vector2(startPos, transform.position.y);
    }
}
