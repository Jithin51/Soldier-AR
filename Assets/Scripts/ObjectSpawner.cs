using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject player;
    public GameObject canvas;
    private PlacementIndicator placementIndicator;
    bool portalPlaced = false;

    private void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }
    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !portalPlaced)
        {
            portalPlaced = true;
            GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            player.SetActive(true);
            canvas.SetActive(true);
            placementIndicator.gameObject.SetActive(false);
        }
    }
}
