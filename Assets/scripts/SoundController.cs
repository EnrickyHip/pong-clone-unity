using System.Linq;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string[] players = { "Player1", "Player2" };

        if (players.Contains(collision.gameObject.name))
            this.racketSound.Play();
        else
            this.wallSound.Play();
        
    }
}
