using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision with " + col.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger with " + col.gameObject.name);
    }
}
