using UnityEngine;
using DG.Tweening;

public class EnemyEmotions : MonoBehaviour
{
    private Game _game;
    private Enemy _enemy;

    public SpriteRenderer spriteEye;
    public SpriteRenderer spriteSmile;
    public SpriteRenderer spriteStar;
    public SpriteRenderer spriteDazed;
    public SpriteRenderer spriteSkull;

    public float popupLifetime = 1.5f;
    public float fadeDuration = 0.3f;

    public void Init(Game game, Enemy enemy) {
        _game = game;
        _enemy = enemy;
    }

    public void ShowEye() {
        Show(spriteEye);
    }

    public void ShowSmile() {
        Show(spriteSmile);
    }

    public void ShowStar() {
        Show(spriteStar);
    }

    public void ShowDazed() {
        Show(spriteDazed);
    }

    public void ShowSkull() {
        Show(spriteSkull);
    }

    private void Show(SpriteRenderer sprite) {
        sprite.gameObject.SetActive(true);
        sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f), fadeDuration)
              .SetDelay(popupLifetime - fadeDuration)
              .OnComplete(() => sprite.gameObject.SetActive(false));
    }

    public void ManualUpdate(float deltaTime) {}
}
