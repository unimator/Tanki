using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float MovementSpeed;

    private LookingDirection _lookingDirection;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    HandleKeyboardInput();
	}

    private void HandleKeyboardInput()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        var z = transform.position.z;
        var rotation = transform.rotation;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _lookingDirection = LookingDirection.Forward;
            y += MovementSpeed;
            rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _lookingDirection = LookingDirection.Backward;
            y -= MovementSpeed;
            rotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _lookingDirection = LookingDirection.Right;
            x += MovementSpeed;
            rotation = Quaternion.AngleAxis(270, Vector3.forward);
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _lookingDirection = LookingDirection.Left;
            x -= MovementSpeed;
            rotation = Quaternion.AngleAxis(90, Vector3.forward);
        }

        this.transform.SetPositionAndRotation(new Vector3(x, y, z), rotation);
    }
}
