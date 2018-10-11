using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUnit : MonoBehaviour
{
    // The range to restrict friendly units to
    public float LeechingRange = 20.0f;

    // The range to heal units
    public float HealingRange = 10.0f;

    // How much healing to do per tick
    public float Healing = 0.002f;  

    // How much healing to do to itself per tick
    public float SelfHealing = 0.002f;  

    // The tag of friendly units
    public string PlayerTag = "PlayerUnit";


    Positioning _positioning;
    Health _health;

    float _healingAccum = 0.0f;
    float _selfHealingAccum = 0.0f;

    // Use this for initialization
    void Start()
    {
        _positioning = this.GetComponent<Positioning>();
        _health = this.GetComponent<Health>();
    }

    // Draw leeching and healing range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, this.LeechingRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, this.HealingRange);
    }

    // Heal at fixed rate
    void FixedUpdate()
    {
        _healingAccum += this.Healing;
        _selfHealingAccum += this.SelfHealing;

        if(_healingAccum > 1.0f)
        {
            _healingAccum -= 1.0f;
            var unitsToHeal = _positioning.FindAllTaggedByDistanceInRange(this.PlayerTag, this.HealingRange);
            foreach(var unit in unitsToHeal)
            {
                unit.GetComponent<Health>().HP += 1;
            }
        }

        if(_selfHealingAccum > 1.0f)
        {
            _selfHealingAccum -= 1.0f;
            _health.HP += 1;
        }
    }
}
