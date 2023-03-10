using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerupID; // 0 = Triple shot 1= Speed up 2= Shield
    [SerializeField]
    private AudioClip _clip;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -7.0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (_powerupID == 0)
                {
                    player.TripleShotPowerUpOn();
                }
                else if (_powerupID == 1)
                {
                    player.SpeedUpPowerUpOn();
                }
                else if (_powerupID == 2)
                {
                    player.ShieldPowerUpOn();
                }
            }
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        
    }
}
