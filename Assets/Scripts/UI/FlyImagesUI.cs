using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FlyImagesUI : MonoBehaviour
{
    private EndGameScreenUI _endGameScreenUI;
    [Header("UI")]
    public Canvas targetCanvas;
    public RectTransform spawnParent;
    public RectTransform imagePrefab;

    [Header("Path: [0] start, [1..] waypoints, last = end")]
    public Transform[] pathPoints;

    [Header("Animation")]
    public int itemCount = 10;
    public float spawnInterval = 0.1f;
    public float flyDuration = 0.5f;
    public Ease flyEase = Ease.InOutSine;
    public PathType pathType = PathType.CatmullRom;
    public bool ignoreTimeScale = true;

    private Coroutine playRoutine;

    public void Init(EndGameScreenUI endGameScreenUI) {
        _endGameScreenUI = endGameScreenUI;
    }

    public void Play(int count) {
        itemCount = count;

        if (playRoutine != null)
            StopCoroutine(playRoutine);

        playRoutine = StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine() {
        for (int i = 0; i < itemCount; i++)
        {
            SpawnAndAnimateOne();

            if (spawnInterval <= 0f)
                continue;

            if (ignoreTimeScale)
                yield return new WaitForSecondsRealtime(spawnInterval);
            else
                yield return new WaitForSeconds(spawnInterval);
        }

        playRoutine = null;
    }

    private void SpawnAndAnimateOne() {
        RectTransform instance = Instantiate(imagePrefab, spawnParent);
        instance.gameObject.SetActive(true);

        Vector2 startLocal2D = WorldToSpawnParentPoint(pathPoints[0].position);
        instance.anchoredPosition = startLocal2D;

        Vector3[] localPath = BuildLocalPathFromTransforms(pathPoints, 1);

        instance
            .DOLocalPath(localPath, flyDuration, pathType)
            .SetEase(flyEase)
            .SetUpdate(ignoreTimeScale)
            .OnComplete(() =>
            {
                if (instance != null)
                    Destroy(instance.gameObject);
                _endGameScreenUI.OnGemCompletedPath();
            });
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

    private void OnDisable() {
        if (playRoutine != null)
        {
            StopCoroutine(playRoutine);
            playRoutine = null;
        }
    }
}