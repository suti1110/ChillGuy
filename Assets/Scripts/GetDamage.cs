using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public int health = 3;
    private Color originalColor;
    private Renderer objectRenderer;

    void Start()
    {
       
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    public void ApplyDamage()
    {
        health -= 1;
        Debug.Log("Damage Applied. Remaining Health: " + health);

        objectRenderer.material.color = new Color(255, 0, 0, 0.4f);
        gameObject.layer = 7;
        StartCoroutine(WaitAction.wait(0.5f, () =>
        {
            objectRenderer.material.color = originalColor - new Color(0, 0, 0, 0.6f);
        }));
        StartCoroutine(WaitAction.wait(2f, () =>
        {
            objectRenderer.material.color = originalColor;
            gameObject.layer = 6;
        }));
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        Destroy(gameObject);
    }
}
