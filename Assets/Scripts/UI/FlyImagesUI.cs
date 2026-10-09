using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FlyImagesUI : MonoBehaviour
{
    public enum PlayMode
    {
        SingleSource,
        MultipleSources
    }

    private Game _game;
    private EndGameScreenUI _endGameScreenUI;
    private FinalScreenUI _finalScreenUI;
    public Canvas targetCanvas;
    public RectTransform spawnParent;
    public RectTransform[] imagePrefabs;

    public Transform[] pathPoints;

    public int itemCount = 10;
    public float spawnInterval = 0.1f;
    public float flyDuration = 0.5f;
    public Ease flyEase = Ease.InOutSine;
    public PathType pathType = PathType.Linear;
    public bool ignoreTimeScale = true;

    private Coroutine playRoutine;
    private readonly List<RectTransform> activeInstances = new List<RectTransform>();
    private int notLaunchedCount;
    private int completedFlyCount = 0;

    private PlayMode currentMode = PlayMode.SingleSource;
    private Transform[] sourcePoints;
    private int[] gemsPerSource;

    public void Init(EndGameScreenUI endGameScreenUI, Game game) {
        _endGameScreenUI = endGameScreenUI;
        _game = game;
    }

    public void Init(FinalScreenUI finalScreenUI, Game game) {
        _finalScreenUI = finalScreenUI;
        _game = game;
    }

    public void Play(int count) {
        currentMode = PlayMode.SingleSource;
        itemCount = count;

        if (playRoutine != null)
            StopCoroutine(playRoutine);

        playRoutine = StartCoroutine(PlayRoutine());
    }

    public void Play(Transform[] buttonTransforms, int[] gemsPerButton) {
        currentMode = PlayMode.MultipleSources;
        sourcePoints = buttonTransforms;
        gemsPerSource = gemsPerButton;

        if (playRoutine != null)
            StopCoroutine(playRoutine);

        playRoutine = StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine() {
        if (currentMode == PlayMode.SingleSource) {
            yield return StartCoroutine(SingleSourceRoutine());
        } else {
            yield return StartCoroutine(MultipleSourcesRoutine());
        }

        playRoutine = null;
    }

    private IEnumerator SingleSourceRoutine() {
        notLaunchedCount = _game.session.GetSavelGemsCount();
        completedFlyCount = 0;
        for (int i = 0; i < itemCount; i++)
        {
            SpawnAndAnimateOne(0);

            if (spawnInterval <= 0f)
                continue;

            if (ignoreTimeScale)
                yield return new WaitForSecondsRealtime(spawnInterval);
            else
                yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator MultipleSourcesRoutine() {
        int totalGems = 0;
        foreach (int count in gemsPerSource)
            totalGems += count;

        notLaunchedCount = totalGems;
        completedFlyCount = 0;

        for (int sourceIndex = 0; sourceIndex < sourcePoints.Length; sourceIndex++) {
            int gemsFromThisSource = gemsPerSource[sourceIndex];

            for (int i = 0; i < gemsFromThisSource; i++) {
                SpawnAndAnimateOne(sourceIndex);

                if (spawnInterval <= 0f)
                    continue;

                yield return new WaitForSecondsRealtime(spawnInterval);
            }
        }
    }

    private void SpawnAndAnimateOne(int sourceIndex) {
        RectTransform instance = Instantiate(imagePrefabs[UnityEngine.Random.Range(0, 4)], spawnParent);
        activeInstances.Add(instance);
        instance.gameObject.SetActive(true);

        Transform startPoint = currentMode == PlayMode.SingleSource
            ? pathPoints[0]
            : sourcePoints[sourceIndex];

        Vector2 startLocal2D = WorldToSpawnParentPoint(startPoint.position);
        instance.anchoredPosition = startLocal2D;

        OnFlyStart();

        if (pathPoints.Length > 1) {
            Vector3[] localPath = BuildLocalPathFromTransforms(pathPoints, 1);
            instance
                .DOLocalPath(localPath, flyDuration, pathType)
                .SetEase(flyEase)
                .SetUpdate(ignoreTimeScale)
                .OnComplete(() =>
                {
                    activeInstances.Remove(instance);
                    OnFlyEnd();
                    if (instance != null)
                        Destroy(instance.gameObject);
                });
        } else {
            Vector2 endLocal2D = WorldToSpawnParentPoint(pathPoints[0].position);
            instance
                .DOAnchorPos(endLocal2D, flyDuration)
                .SetEase(flyEase)
                .SetUpdate(ignoreTimeScale)
                .OnComplete(() =>
                {
                    activeInstances.Remove(instance);
                    OnFlyEnd();
                    if (instance != null)
                        Destroy(instance.gameObject);
                });
        }
    }

    private Vector3[] BuildLocalPathFromTransforms(Transform[] points, int startIndex) {
        List<Vector3> result = new List<Vector3>(points.Length - startIndex);

        for (int i = startIndex; i < points.Length; i++) {
            Vector2 p2 = WorldToSpawnParentPoint(points[i].position);
            result.Add(new Vector3(p2.x, p2.y, 0f));
        }

        return result.ToArray();
    }

    private Vector2 WorldToSpawnParentPoint(Vector3 worldPosition) {
        Camera cam = targetCanvas.renderMode == RenderMode.ScreenSpaceOverlay
            ? null
            : targetCanvas.worldCamera;

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(cam, worldPosition);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            spawnParent,
            screenPoint,
            cam,
            out Vector2 localPoint
        );

        return localPoint;
    }

    private void OnFlyStart() {
        notLaunchedCount--;
        if (currentMode == PlayMode.SingleSource && _game.ui.savedGemsText != null) {
            _game.ui.savedGemsText.text = notLaunchedCount.ToString();
        }
    }

    private void OnFlyEnd() {
        completedFlyCount++;
        if (currentMode == PlayMode.SingleSource && _endGameScreenUI != null) {
            _endGameScreenUI.scoreText.text = (completedFlyCount * 10).ToString();
        }
    }

    private void OnDisable() {
        if (playRoutine != null)
        {
            StopCoroutine(playRoutine);
            playRoutine = null;
        }

        foreach (RectTransform instance in activeInstances)
        {
            if (instance != null)
            {
                instance.DOKill();
                Destroy(instance.gameObject);
            }
        }

        activeInstances.Clear();
    }
}