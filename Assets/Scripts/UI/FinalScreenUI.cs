using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class FinalScreenUI : MonoBehaviour
{
    private Game _game;
    private UI _ui;
    public TextMeshProUGUI freezeText;
    public TextMeshProUGUI waveText;

    public List<LevelButtonUI> levelButtons;
    public FlyImagesUI flyImages;
    public TextMeshProUGUI scoreText;
    private int score;

    public void Init(Game game, UI ui) {
        _game = game;
        _ui = ui;
        flyImages?.Init(this, game);

        for (int i = 0; i < levelButtons.Count; i++) {
            levelButtons[i].Init(_game, this, i);
        }
    }

    public void Open() {
        score = 0;
        gameObject.SetActive(true);

        freezeText.text = _game.abilityFactory.inventory[_game.abilityFactory.freezeAbility].ToString();
        waveText.text = _game.abilityFactory.inventory[_game.abilityFactory.waterBoostAbility].ToString();

        PlayGemFlyAnimation();
    }
    
    public void OnOneFlyImage() {
        score++;
        scoreText.text = (score * 100).ToString();
    }

    public void OnFlyImagesOver() {
        Debug.Log(_game.session.alreadyFinished);
        if (_game.session.alreadyFinished) return;
        _game.abilityFactory.inventory[_game.abilityFactory.freezeAbility] += 5;
        freezeText.text = _game.abilityFactory.inventory[_game.abilityFactory.freezeAbility].ToString();
        _game.abilityFactory.inventory[_game.abilityFactory.waterBoostAbility] += 5;
        waveText.text = _game.abilityFactory.inventory[_game.abilityFactory.waterBoostAbility].ToString();
        _ui.abilityUi.RefreshNumbers();
        _game.session.alreadyFinished = true;
    }

    private void PlayGemFlyAnimation() {
        if (flyImages == null || levelButtons.Count == 0)
            return;

        Transform[] buttonTransforms = new Transform[levelButtons.Count];
        int[] levelsScore = _game.session.GetLevelsScore();
        int[] gemsPerButton = new int[levelButtons.Count];

        for (int i = 0; i < levelButtons.Count; i++) {
            buttonTransforms[i] = levelButtons[i].transform;
            gemsPerButton[i] = levelsScore[i];
        }

        flyImages.Play(buttonTransforms, gemsPerButton);
    }
}
