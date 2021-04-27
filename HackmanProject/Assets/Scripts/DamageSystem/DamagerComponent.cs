using UnityEngine;

public class DamagerComponent : MonoBehaviour
{
    public int Damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DamagableComponent>() != null)
        {
            Evently.instance.Publish(new DamageEvent(other.GetComponent<DamagableComponent>(),this));
        }
    }
}