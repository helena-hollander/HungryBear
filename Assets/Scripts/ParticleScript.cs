using UnityEngine;

public class ParticleScript : MonoBehaviour
{
public Vector2 velocity;   // Partiklens hastighed
    public float rotationSpeed; // Hastighed af rotation
    private float angle;        // Den aktuelle vinkel

    void Start()
    {
        // Start-hastighed kan f.eks. sættes her
        velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(5f, 10f));
    }

    void Update()
    {
        // Bevæg partiklerne baseret på hastigheden
        transform.position += (Vector3)velocity * Time.deltaTime;

        // Opdater vinklen baseret på x-hastighed
        rotationSpeed = velocity.x * 100f; // Hvis du vil have proportional rotation
        angle += rotationSpeed * Time.deltaTime; // Øg vinklen

        // Anvend rotationen
        transform.rotation = Quaternion.Euler(0, 0, angle); // Rotation på Z-aksen (2D)
    }
}
