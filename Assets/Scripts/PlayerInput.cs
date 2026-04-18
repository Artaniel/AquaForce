using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput: MonoBehaviour
{
    private Game _game;

    public Vector2 cursorWorldPosition;
    public bool cursorIsPressed;
    public bool cursorWasPressedThisFrame;
    public bool cursorWasReleasedThisFrame;
    public Action OnCursorPress;
    public Action OnCursorRelease;

    public void Init(Game game) {
        _game = game;
    }

    public void ManualUpdate() {
        DesktopUpdate();
    }

    private void DesktopUpdate() {
        cursorIsPressed = Mouse.current.leftButton.isPressed;
        cursorWasPressedThisFrame = Mouse.current.leftButton.wasPressedThisFrame;
        cursorWasReleasedThisFrame = Mouse.current.leftButton.wasReleasedThisFrame;
        if (cursorWasPressedThisFrame) OnCursorPress?.Invoke();
        if (cursorWasReleasedThisFrame) OnCursorRelease?.Invoke();

        cursorWorldPosition = _game.mainCamera.ScreenToWorldPoint(Mouse.current.position.value);
    }

}