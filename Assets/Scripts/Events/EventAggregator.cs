using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAggregator: MonoBehaviour
{
    public static EnemyDiedEvent enemyDied = new EnemyDiedEvent();
}
