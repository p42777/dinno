using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // Animate() may get divide by zero error at Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);
        // let GameManager.Start() get executed first
        Invoke(nameof(Animate), 0f); // get called next frame
    
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        frame++;

        if (frame >= sprites.Length) {
            frame = 0;
        }

        // avoid index out of bounds error
        if (frame >= 0 && frame < sprites.Length) {
            spriteRenderer.sprite = sprites[frame];
        }

        Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);
    }

}
