using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

    //Variable For Object Lifetime
    public float lifetime;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Lifetime set is minus gametime
        lifetime -= Time.deltaTime;

        //If the lifetime becomes less than 0, destroy said object
        if(lifetime < 0)
        {
            Destroy(gameObject);
        }
	}
}
