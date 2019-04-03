using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour {
    
    [SerializeField]
    GameObject PrefabAsteroid;

    

   

    // Use this for initialization
    void Start () {

        
        GameObject astroid = Instantiate(PrefabAsteroid , transform.position, Quaternion.identity) as GameObject;
        GameObject astroid1 = Instantiate(PrefabAsteroid, transform.position, Quaternion.identity) as GameObject;
        GameObject astroid2 = Instantiate(PrefabAsteroid, transform.position, Quaternion.identity) as GameObject;
        GameObject astroid3 = Instantiate(PrefabAsteroid, transform.position, Quaternion.identity) as GameObject;



        astroid.GetComponent<Asteroid>().initialize(Direction.Right,new Vector3(-50,0,0));
        astroid.transform.position = new Vector3(-50,0,0);

        astroid1.GetComponent<Asteroid>().initialize(Direction.Up, new Vector3(0, -30, 0));
        astroid1.transform.position = new Vector3(0, -30, 0);

        astroid2.GetComponent<Asteroid>().initialize(Direction.Down, new Vector3(0,30, 0));
        astroid2.transform.position = new Vector3(0, 30, 0);

        astroid3.GetComponent<Asteroid>().initialize(Direction.Left, new Vector3(50, 0, 0));
        astroid3.transform.position = new Vector3(50, 0, 0);





    }


	
}
