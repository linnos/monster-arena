using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField]
    public List<IDamageable> damageables = new List<IDamageable>();
    public int damage = 10;

    void OnDisable()
    {
        damageables = new List<IDamageable>();
    }

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log(other.gameObject.name);
        Entity damageable = other.gameObject.GetComponent<Entity>();
        
        if(damageable == null){
            return;
        }
        if(damageables.Contains(damageable)){
            return;
        }

        damageable.TakeDamage(damage);
        damageables.Add(damageable);
        
    }
}
