using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement playerMovementComponent;
    public ParticleSystem boom;
    public Text CoinsText;
    int coins;
    Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            playerMovementComponent.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            Instantiate(boom, playerMovementComponent.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider colliderInfo)
    {
        if (colliderInfo.tag == "Finish")
        {
            FindObjectOfType<GameManager>().LoadNextLevel();
        }
    }



    private void OnTriggerEnter(Collider colliderInfo)
    {
        if(colliderInfo.tag == "Coin")
        {
            Destroy(colliderInfo.gameObject);
            coins++;
            CoinsText.text = "Coins: " + coins.ToString();
        }
        if (colliderInfo.tag == "Boost")
        {
            Destroy(colliderInfo.gameObject);
            _rigidbody.AddForce(Vector3.forward * 2000 * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (colliderInfo.tag == "Slower")
        {
            Destroy(colliderInfo.gameObject);
            _rigidbody.AddForce(Vector3.back * 2000 * Time.deltaTime, ForceMode.VelocityChange);
        }
    }


}
