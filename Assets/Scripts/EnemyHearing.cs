using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHearing : MonoBehaviour
{
    public static EnemyHearing hearing;

    public PlayerInteraction interaction;
    public GameObject Player;

    public float hearingRange;

    void Start()
    {
        if(hearing == null) {
            hearing = this;
        }
        else
        {
            Destroy(gameObject);
        }
        interaction = Player.GetComponent<PlayerInteraction>();
    }

    void Update()
    {
        if(hearingRange < interaction.TaskValues.NoiseRange)
        {
            EnemyNavigation.EnemyNav.eAgnt.destination = interaction.TaskValues.gameObject.transform.position;
        }
    }
}
