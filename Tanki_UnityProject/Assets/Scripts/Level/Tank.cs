using System;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float MovementSpeed;
    public Color TankColor;

    private LookingDirection _lookingDirection;

    public event EventHandler OnMove, OnMoveStop;
    
	// Use this for initialization
	void Start ()
	{
	    PaintTank();
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

        bool moved = false;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _lookingDirection = LookingDirection.Forward;
            y += MovementSpeed;
            rotation = Quaternion.AngleAxis(0, Vector3.forward);
            moved = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _lookingDirection = LookingDirection.Backward;
            y -= MovementSpeed;
            rotation = Quaternion.AngleAxis(180, Vector3.forward);
            moved = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _lookingDirection = LookingDirection.Right;
            x += MovementSpeed;
            rotation = Quaternion.AngleAxis(270, Vector3.forward);
            moved = true;
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _lookingDirection = LookingDirection.Left;
            x -= MovementSpeed;
            rotation = Quaternion.AngleAxis(90, Vector3.forward);
            moved = true;
        }

        if (moved && OnMove != null)
            OnMove(this, new EventArgs());
        else if (OnMoveStop != null)
            OnMoveStop(this, new EventArgs());

        this.transform.SetPositionAndRotation(new Vector3(x, y, z), rotation);
    }

    private void PaintTank()
    {
        foreach (var childSpriteRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            childSpriteRenderer.color = TankColor;
        }
    }
}
