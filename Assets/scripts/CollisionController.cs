using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreController scoreController;

    private void BounceFromRacket(Collision2D collision)
    {
        GameObject racket = collision.gameObject;    

        Vector3 ballPosition = this.transform.position;
        Vector3 racketPosition = racket.transform.position;

        float racketHeight = collision.collider.bounds.size.y;

        float x = racket.name == "Player1" ? 1 : -1;
        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string[] players = { "Player1", "Player2" };

        if (players.Contains(collision.gameObject.name))
        {
            this.BounceFromRacket(collision);
            return;
        }

        if (collision.gameObject.name == "WallRight")
        {
            this.scoreController.GoalPlayer1();
            this.StartCoroutine(this.ballMovement.StartBall(false));
            return;
        }

        if (collision.gameObject.name == "WallLeft")
        {
            this.scoreController.GoalPlayer2();
            this.StartCoroutine(this.ballMovement.StartBall(true));
            return;
        }
        
    }
}
