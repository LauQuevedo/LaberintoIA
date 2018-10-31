using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoPer : MonoBehaviour {
	
	Animator anim;
	Vector3 TargetPosition;
	Direction direction;
	public float speed = 3;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		TargetPosition=transform.position;
		//direction=Direction.down;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 axisDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if(axisDirection != Vector2.zero && TargetPosition == transform.position)
		{
			if(Mathf.Abs(axisDirection.x) > Mathf.Abs(axisDirection.y))
			{
				
				if(axisDirection.x > 0)
				{
					//direction = Direction.right;
					TargetPosition += Vector3.right;
				}
				else{
					//direction = Direction.left;
					TargetPosition-=Vector3.right;
				}
			
			}
			else
			{
				if(axisDirection.y>0)
				{
					//direction = Direction.up;
					TargetPosition += Vector3.up;
				}
				else
				{
					//direction = Direction.up;
					TargetPosition -= Vector3.up;	
				}
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);
	}
}
