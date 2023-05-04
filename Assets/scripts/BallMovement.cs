using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed = 400f;
    public float extraSpeedPerHit = 50f;
    public float maxExtraSpeed = 1000f; 

    private int hitCounter = 0;

    private void Start()
    {
        this.StartCoroutine(this.StartBall());
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);

        int direction = isStartingPlayer1 ? -1 : 1;
        this.MoveBall(new Vector2(direction, 0));
        //this.transform.Rotate(0, 0, 50 * Time.deltaTime); isso faz a bola rodar
    }

    private void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        int x = isStartingPlayer1 ? -60 : 60;
        int y = -30;

        this.gameObject.transform.localPosition = new Vector2(x, y);
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float speed = this.movementSpeed + (this.hitCounter * this.extraSpeedPerHit);

        Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * speed;
    }

    public void IncreaseHitCounter()
    {
        if (this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
            this.hitCounter++;
    }
}
