using UnityEngine;
public class CoinScript : MonoBehaviour
{
    private float minOffset = 40f;   
    private float minDistance = 100f; 
    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character")
        {
            Vector3 newPosition;
            do
            {
                newPosition = this.transform.position + new Vector3(
                    Random.Range(-minDistance, minDistance),
                    this.transform.position.y,
                    Random.Range(-minDistance, minDistance)
                );
            } while (
                Vector3.Distance(newPosition, this.transform.position) < minDistance
                || newPosition.x < minOffset
                || newPosition.z < minOffset
                || newPosition.x > 1000 - minOffset
                || newPosition.z > 1000 - minOffset
            );
            float terrainHeight = Terrain.activeTerrain.SampleHeight(newPosition);
            newPosition.y = terrainHeight + Random.Range(2f, 20f - terrainHeight);
            this.transform.position = newPosition;
        }
    }
}