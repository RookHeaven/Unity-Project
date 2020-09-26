using UnityEngine;


public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _enemyHealth;

    public void Hurt(int damage)
    {
        _enemyHealth -= damage; ;

        if (_enemyHealth <= 0)
        {
            print("Ouch: " + damage);
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
