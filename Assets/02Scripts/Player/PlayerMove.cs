using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3;
    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Debug.Log($"h: {h}, v: {v}");

        Vector2 direction = new Vector2(h, v);
        Debug.Log($"direction: ({direction.x}, {direction.y})");

        Vector2 position = transform.position;
        Vector2 newPosition = position + direction * (speed * Time.deltaTime);

        transform.position = newPosition;
    }
}
