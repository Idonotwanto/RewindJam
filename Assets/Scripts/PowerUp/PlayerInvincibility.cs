using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    private bool invincible = false;

    public void ActivateInvincibility(float duration)
    {
        invincible = true;
        Collider2D playerCollider = GetComponent<Collider2D>();
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }
        StartCoroutine(DeactivateInvincibilityAfterDuration(duration));
    }

    public void DeactivateInvincibility()
    {
        invincible = false;
        Collider2D playerCollider = GetComponent<Collider2D>();
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }
    }

    private IEnumerator DeactivateInvincibilityAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        DeactivateInvincibility();
    }
}

