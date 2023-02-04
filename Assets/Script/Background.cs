using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Vector3 backPos; public float width = 14.22f; public float height = 0f; private float X; private float Y;


    Renderer m_Renderer;

    public float speed = 1.0f;
    public bool moveRight = false;  // scroll to left by default.
    private GameObject dupeSprite;

    private float spriteWidth;
    private float initPos;
    // Use this for initialization
    void Start()
    {
        initPos = transform.position.y;
        spriteWidth = this.GetComponent<SpriteRenderer>().bounds.size.x;
        m_Renderer = GetComponent<Renderer>();
    }

    bool spawn = false;

    // Update is called once per frame
    //void Update()
    //{
    //    if (m_Renderer.isVisible)
    //    {
    //        Debug.Log("Object is visible");
    //    }
    //    else Debug.Log("Object is no longer visible");
    //    if(!spawn)
    //        StartCoroutine(OnBecameInvisible());
    //}

    private void Update()
    {
        if (moveRight)
        {
            float currentPos = transform.position.y;
            if (currentPos - initPos > spriteWidth)
            {
                // if distance traversed is greater than width of this sprite,
                // then reposition to original position.
                transform.position = new Vector3(transform.position.x, initPos + speed, transform.position.z);
            }
            else
                transform.position = new Vector3(transform.position.x, currentPos + speed, transform.position.z);
        }
        else
        {
            float currentPos = transform.position.y;
            if (initPos - currentPos > spriteWidth)
            {
                transform.position = new Vector3(transform.position.x, initPos - speed, transform.position.z);
            }
            else
                transform.position = new Vector3(transform.position.x, currentPos - speed, transform.position.z);
        }
    }
}
