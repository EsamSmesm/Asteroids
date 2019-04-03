using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour
{
    // thrust and rotation support
    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 5;
    const float RotateDegreesPerSecond = 180;

    [SerializeField]
    GameObject PrefabBullet;
    [SerializeField]
    GameObject Hud;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// saved for efficiency
        rb2D = GetComponent<Rigidbody2D>();
       
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // check for rotation input
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0) {

            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0) {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);

            
           
        }
        // make ship fire bullets
        Vector3 ShipPosition = gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject bullet = Instantiate(PrefabBullet, ShipPosition, Quaternion.identity) as GameObject;
            bullet.transform.position = ShipPosition;
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);
            //play Audio Effects
            AudioManager.Play(AudioClipName.AsteroidHit);
        }

        
    }

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // thrust as appropriate
        if (Input.GetAxis("Thrust") != 0)
        {
            rb2D.AddForce(ThrustForce * thrustDirection,
                ForceMode2D.Force);
        }

        
    }

    void OnCollisionEnter2D( Collision2D obj)
    {
        if (obj.gameObject.tag == "Astroid")
        {
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(gameObject);
            Hud.GetComponent<Hud>().StopGameTimer();
            
        }
    }
}
