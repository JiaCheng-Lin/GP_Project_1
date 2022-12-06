using System.Collections;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public GameObject item;
    public Sprite emptyBlock;
    public int maxHits = -1;
    private bool animating;

    public bool cloudControl = false;

    private GameObject block_1;
    private GameObject block_2;
    private GameObject switch_block;

    public Sprite OnImage;
    public switchBlockHit switchBlock;

    public GameObject[] bricks;

    private void Start()
    {
        block_1 = GameObject.Find("MysteryBlock_good_1");
        block_2 = GameObject.Find("MysteryBlock_good_2");
        switch_block = GameObject.Find("switch_block");
        bricks = GameObject.FindGameObjectsWithTag("FirstBricks");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.up)) {
                Hit();
            }
        }
    }

    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true; // show if hidden

        maxHits--;

        if (maxHits == 0) {
            spriteRenderer.sprite = emptyBlock;
            cloudControl = true;

            if (this.name == "MysteryBlock_NG")
            {
                /*spriteRenderer.color = (Color)(new Color32(255, 255, 255, 125));
                this.GetComponent<Collider2D>().enabled = false;*/

                foreach (GameObject brick in bricks)
                {
                    brick.GetComponent<SpriteRenderer>().color = (Color)(new Color32(255, 255, 255, 125));
                    brick.GetComponent<Collider2D>().enabled = false;
                }

                
                /*block_1.GetComponent<SpriteRenderer>().color = (Color)(new Color32(255, 255, 255, 125));
                block_2.GetComponent<SpriteRenderer>().color = (Color)(new Color32(255, 255, 255, 125));

                this.GetComponent<Collider2D>().enabled = false;
                block_1.GetComponent<Collider2D>().enabled = false;
                block_2.GetComponent<Collider2D>().enabled = false;*/

                switch_block.GetComponent<SpriteRenderer>().sprite = OnImage;
                switchBlock.hitCnt += 1;
            }
            
        }

        if (item != null) {
            Instantiate(item, transform.position, Quaternion.identity);
        }

        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        animating = false;
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }

}
