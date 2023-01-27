using System.Collections;
using UnityEngine;

public class DamageFlash2D : MonoBehaviour
{
    public float flashDuration = 0.1f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.5f);

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool flashing;

    void Awake()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (flashing)
        {
            spriteRenderer.color = flashColor;
        }
        else
        {
            spriteRenderer.color = originalColor;
        }
    }

    public void TakeDamage()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        flashing = true;
        yield return new WaitForSeconds(flashDuration);
        flashing = false;
    }
}
