using UnityEngine;

public interface IDamageable{
    public void TakeDamage(int damage, Vector3 spawnPos = default(Vector3));
    public void Death();
}