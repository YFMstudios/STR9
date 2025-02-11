using UnityEngine;

public class MinionRangedProjectile : MonoBehaviour
{
    private GameObject target; // Hedef nesnesi
    private float damage;      // Zarar miktar�
    public float speed = 10f;  // H�z

    // Hedef ve sald�r� hasar� ayarlamak i�in kullan�l�r
    public void SetTarget(GameObject newTarget, float attackDamage)
    {
        target = newTarget;
        damage = attackDamage;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Hedef yoksa projeyi yok et ve fonksiyondan ��k
            return;
        }

        MoveTowardsTarget(); // Hedefe do�ru hareket et
    }

    private void MoveTowardsTarget()
    {
        Vector3 direction = target.transform.position - transform.position; // Hedefe do�ru vekt�r
        float distanceThisFrame = speed * Time.deltaTime; // Bu frame'deki hareket mesafesi

        if (direction.magnitude <= distanceThisFrame) // Hedefe ula��ld�ysa
        {
            DamageTarget(); // Hedefe zarar ver
            Destroy(gameObject); // Projeyi yok et
        }
        else
        {
            transform.Translate(direction.normalized * distanceThisFrame, Space.World); // Hedefe do�ru hareket et
        }
    }

    private void DamageTarget()
    {
        ObjectiveStats targetStats = target.GetComponent<ObjectiveStats>(); // Hedefin istatistikler bile�eni
        if (targetStats != null)
        {
            targetStats.TakeDamage(damage); // Hedefe zarar ver
        }
    }
}
