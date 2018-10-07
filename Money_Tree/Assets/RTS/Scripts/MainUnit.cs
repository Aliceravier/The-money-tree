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
    public int Healing = 1;  

    // How much healing to do to itself per tick
    public int SelfHealing = 1;  

    // The tag of friendly units
    public string PlayerTag = "PlayerUnit";


    Positioning _positioning;
    Health _health;

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
        var unitsToHeal = _positioning.FindAllTaggedByDistanceInRange(this.PlayerTag, this.HealingRange);
        foreach(var unit in unitsToHeal)
        {
            unit.GetComponent<Health>().HP += this.Healing;
        }

        _health.HP += this.SelfHealing;
    }
}
