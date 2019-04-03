using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    const float BulletLife = 1;
    Timer DeathTime;

	// Use this for initialization
	void Start () {
        DeathTime = gameObject.AddComponent<Timer>();
        DeathTime.Duration = BulletLife;
        DeathTime.Run();
	}
    public void ApplyForce(Vector2 forceDirction)
    {
        const float ForceMagnitude = 80;
        GetComponent<Rigidbody2D>().AddForce(ForceMagnitude * forceDirction,ForceMode2D.Impulse);
       
    }
	
	// Update is called once per frame
	void Update () {
        if (DeathTime.Finished)
        {
            Destroy(gameObject);
        } 
	}
}
