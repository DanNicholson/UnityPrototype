using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class Controller2D : MonoBehaviour {

	const float skinWidth = .015f;

	BoxCollider2D collider;
	RayCastOrigins raycastOrigins;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D>();
	}

	void UpdateRayCastOrigins(){
		Bounds bounds = collider.bounds;
		bounds.Expand (skinWidth * -2);

		raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
	}

	//This will hold positions for our RayCasts
	struct RayCastOrigins {
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}

	// Update is called once per frame
	void Update () {

	}
}
