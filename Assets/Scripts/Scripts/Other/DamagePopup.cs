using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public float damage;
    public float lifetime = 1f;  // How long the damage display stays on screen
    public Vector3 offset = new Vector3(0, 2, 0);  // Offset of the damage display from the enemy's position
    private float spawnTime;
    private TextMeshPro damageText;

    private void Awake()
    {
        damageText = GetComponentInChildren<TextMeshPro>();

    }
    private void Start()
    {
        damageText.text = damage.ToString();
        spawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time >= spawnTime + lifetime)
        {
            // destroy the object after it's lifetime
            Destroy(gameObject);
        }
    }

    public void setDamage(float damage, Transform target)
    {
        this.damage = damage;
        transform.position = target.position + offset;
    }
}