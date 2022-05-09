using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [SerializeField] Rigidbody2D rb;
     [SerializeField] float moveXForce;
     [SerializeField] float moveYForce;
     [SerializeField] float maxXSpeed;
     [SerializeField] float maxYSpeed;
     [SerializeField] UIController uiController;
     [SerializeField] GameSFXManager gameSFXManager;
     private float inclination = 0.2f;

    private void FixedUpdate() {
        // Player's speed
        float xSpeed = Mathf.Abs(rb.velocity.x);
        float ySpeed = Mathf.Abs(rb.velocity.y);

        // Move
        if(Input.acceleration.x > this.inclination && xSpeed < maxXSpeed){
        // if(Input.GetKeyDown(KeyCode.RightArrow) && xSpeed < maxXSpeed){
            rb.AddForce(new Vector2(moveXForce, 0), ForceMode2D.Impulse);
        }
        else if(Input.acceleration.x < -this.inclination && xSpeed < maxXSpeed){
        // else if(Input.GetKeyDown(KeyCode.LeftArrow) && xSpeed < maxXSpeed){
            rb.AddForce(new Vector2(-moveXForce, 0), ForceMode2D.Impulse);
        }
        else if(Input.acceleration.y > this.inclination && ySpeed < maxYSpeed){
        // else if(Input.GetKeyDown(KeyCode.UpArrow) && ySpeed < maxYSpeed){
            rb.AddForce(new Vector2(0, moveYForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Game Clear
        if(other.transform.CompareTag("Goal")){
            gameSFXManager.PlaySFX("SFXClear");
            uiController.ActivateGameClearScreen();
        }
        // Game Over
        else if(other.transform.CompareTag("Gameover")){
            uiController.ActivateGameOverScreen();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Drops")){
            gameSFXManager.PlaySFX("SFXArrowCollision");
            uiController.breakHearts();
        }else if(other.transform.CompareTag("Wall")){
            gameSFXManager.PlaySFX("SFXWallCollision");
        }
    }
}
