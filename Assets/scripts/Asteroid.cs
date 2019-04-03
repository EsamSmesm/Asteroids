using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    [SerializeField]
    Sprite Asteroid1;
    [SerializeField]
    Sprite Asteroid2;
    [SerializeField]
    Sprite Asteroid3;

    const float MinImpulseForce = 3f;
    const float MaxImpulseForce = 4f;
    float angle;

    // Use this for initialization
    void Start () {

        // Make moving asteroid a random sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = Asteroid1;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = Asteroid2;
        }
        else
        {
            spriteRenderer.sprite = Asteroid3;
        }
    }
    
    public void initialize( Direction dir , Vector3 Location)
    {
        // apply impulse force to get game object moving
       
        if (dir == Direction.Up)
        {
            angle = Random.Range(75 * Mathf.Deg2Rad, 105 * Mathf.Deg2Rad);
            Vector2 moveDirection = new Vector2(
           Mathf.Cos(angle), Mathf.Sin(angle));
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(
                moveDirection * magnitude,
                ForceMode2D.Impulse);
        }
            
        else if (dir == Direction.Down)
        {
            angle = Random.Range(265 * Mathf.Deg2Rad, 285 * Mathf.Deg2Rad);
            Vector2 moveDirection = new Vector2(
           Mathf.Cos(angle), Mathf.Sin(angle));
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(
                moveDirection * magnitude,
                ForceMode2D.Impulse);
        }
            
        else if (dir == Direction.Right)
        {
            angle = Random.Range(-15 * Mathf.Deg2Rad, 15 * Mathf.Deg2Rad);
            Vector2 moveDirection = new Vector2(
           Mathf.Cos(angle), Mathf.Sin(angle));
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(
                moveDirection * magnitude,
                ForceMode2D.Impulse);
        }
            
        else if (dir == Direction.Left)
        {
            angle = Random.Range(165 * Mathf.Deg2Rad, 195 * Mathf.Deg2Rad);
            Vector2 moveDirection = new Vector2(
           Mathf.Cos(angle), Mathf.Sin(angle));
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(
                moveDirection * magnitude,
                ForceMode2D.Impulse);
        }


    }

    public void StartMoving()
    {
        angle = Random.Range(0 , 2 * Mathf.PI);
        Vector2 moveDirection = new Vector2(
       Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D obj )
    {
        if (obj.gameObject.tag == "Bullet")
        {
           
            AudioManager.Play(AudioClipName.PlayerShot);         
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * 1 / 2;
            CircleCollider2D red = GetComponent<CircleCollider2D>();
            red.radius *= 0.5f;
            Destroy(obj.gameObject);
            if (transform.localScale.x < (0.5f))
            {
                Destroy(gameObject);
            }
           
            else
	        {
                GameObject astroid = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
                GameObject astroid1 = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;

                astroid.GetComponent<Asteroid>().StartMoving();
                astroid1.GetComponent<Asteroid>().StartMoving();
                astroid.transform.position = transform.position;
                astroid1.transform.position = transform.position;
            }
            Destroy(gameObject);
           
           
        }
    }

}
