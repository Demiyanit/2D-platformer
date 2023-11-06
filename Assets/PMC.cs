using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PMC : MonoBehaviour {

    public Rigidbody2D plr_rb;

    public float max_speed = 5.0f;
    public float jump_force = 1.0f;

    public int max_jump_count = 1;
    private int jump_count = 0;


    public void Start() {
        plr_rb = GetComponent<Rigidbody2D>();
        
    }

    public void Update() {
        if(Input.GetButtonDown("Jump") && max_jump_count > jump_count) {
            plr_rb.velocity = new Vector2(plr_rb.velocity.x, jump_force);
            jump_count++;
        }

    }

    public void FixedUpdate() {
        float move_horizontal = Input.GetAxis("Horizontal");

        plr_rb.velocity = new Vector2(move_horizontal * max_speed, plr_rb.velocity.y);

    }


    void OnCollisionEnter2D(Collision2D collision) {
        var relativePosition = transform.InverseTransformPoint(collision.transform.position);

        Debug.Log(relativePosition.y);
        if(relativePosition.y < 0) {
            jump_count = 0;
        }
    }

    public bool GetPressUp() {
        if(Input.GetKey(KeyCode.Space)) {
            return true;
        }

        return false;
    }
}
