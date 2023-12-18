using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTrap : MonoBehaviour
{
    protected virtual void KillPlayer(IPlayer player)
    {
        player.Damage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IPlayer>() is IPlayer player)
        {
            KillPlayer(player);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IPlayer>() is IPlayer player)
        {
            KillPlayer(player);
        }
    }
}
