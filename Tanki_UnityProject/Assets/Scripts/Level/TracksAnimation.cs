using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracksAnimation : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	    var animator = transform.GetComponent<Animator>();
	    var tank = transform.parent.GetComponent<Tank>();

	    if (tank != null)
	    {
	        tank.OnMove += (o, e) =>
	        {
                animator.Play("TracksMovement");
	        };

	        tank.OnMoveStop += (o, e) =>
	        {
                animator.Play("Idle");
	        };
	    }
	}
}
