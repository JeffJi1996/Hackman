using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DamageSystem : MonoBehaviour
{
    private void OnEnable()
    {
        Evently.instance.Subscribe<DamageEvent>(OnDamageEvent);
    }

    private void OnDisable()
    {
        Evently.instance.Unsubscribe<DamageEvent>(OnDamageEvent);
    }

    private void OnDamageEvent(DamageEvent evt)
    {
        evt.Damagable.HP -= evt.Damager.Damage;

        if (evt.Damagable.HP == 0)
        {
            Destroy(evt.Damagable.gameObject);
        }

        Debug.Log("Destroy the damagable!");
    }
}


public class DamageEvent
{
    public DamagableComponent Damagable;
    public DamagerComponent Damager;

    public DamageEvent(DamagableComponent _damagable, DamagerComponent _damager)
    {
        Damagable = _damagable;
        Damager = _damager;
    }
}