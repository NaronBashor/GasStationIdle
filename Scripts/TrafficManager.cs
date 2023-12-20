using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
        [SerializeField] private Transform spawnLocation;
        [SerializeField] private float initialSpawnTime;

        public List<GameObject> vehicles = new List<GameObject>();

        private int index;
        private float spawnTimer;

        private void Update()
        {
                // Set spawn timer, pick random spawn time between two values
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0)
                {
                        spawnTimer = Random.Range(4, initialSpawnTime);
                        int randomNumber = Random.Range(0 , vehicles.Count);
                        GameObject car = Instantiate(vehicles[randomNumber] , spawnLocation.position , Quaternion.identity);
                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                // When vehicle reaches this point destroy it
                if (collision != null)
                {
                        if (collision.CompareTag("Car"))
                        {
                                Destroy(collision.gameObject);
                        }
                }
        }
}
