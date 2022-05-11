using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGUI : MonoBehaviour
{
    private Player player;
    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void OnGUI()
    {
        var health = player.Health;
        if (health > 0)
            GUI.Box(new Rect(20, 10, 100, 50), $"HEALTH: {health}");
        else GUI.Box(new Rect(20, 10, 100, 50), "You're dead");
    }
}
