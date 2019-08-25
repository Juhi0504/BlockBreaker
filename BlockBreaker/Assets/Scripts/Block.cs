using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;

    level level;

    private void Start()
    {
        level = FindObjectOfType<level>();
        level.countBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameStatus>().addToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.blockDestroyed();
        TriggerSparklVFX();
    }

    private void TriggerSparklVFX()
    {
        GameObject sparkle = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 1f);
    }
}
