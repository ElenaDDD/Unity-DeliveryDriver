using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.1f;
    [SerializeField] Color32 hasPackageColor = new Color32(231,16,187,1);
    [SerializeField] Color32 noPackageColor = new Color32(226, 237, 14, 255);

    private bool hasPackage = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision with " + col.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger with " + col.gameObject.name);
        // if the thing we trigger is a package - we pick it up
        // if its a customer - we deliver
        if (col.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Picked up package");
            
            if (spriteRenderer != null)
            {
                spriteRenderer.color = hasPackageColor;
                Debug.Log($"color is now{spriteRenderer.color}");
            }  
            Destroy(col.gameObject, destroyDelay);
        }
        else
        if (col.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
            if (spriteRenderer != null)
            {
                spriteRenderer.color = noPackageColor;
            }
        }
    }
}
