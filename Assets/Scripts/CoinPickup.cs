using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            //PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
