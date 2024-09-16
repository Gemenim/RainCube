using System.Collections;
using UnityEngine;

public class BombGenerator : Generator
{
    public void Creat(Vector3 position)
    {
        Drop drop = Spawn();
        SetPosition(drop, position);
        drop.Remove();
    }
}
