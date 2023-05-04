using UnityEngine;

public class Racket : MonoBehaviour
{
    //public KeyCode sprintKey;
    public float speed = 300f;
    public string axis;

    private void FixedUpdate()
    {
        //float speed = Input.GetKey(sprintKey) ? this.speed * 2 : this.speed;
        float value = Input.GetAxisRaw(this.axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, value) * speed;
    }

}
