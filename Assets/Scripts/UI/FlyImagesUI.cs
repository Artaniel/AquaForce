using System.Collections;
using DG.Tweening;
using UnityEngine;

public class FlyImagesUI : MonoBehaviour
{
    public Canvas targetCanvas;
    public RectTransform spawnParent;
    public RectTransform imagePrefab;
    public Transform startPoint;
    public Transform endPoint;

    public int itemCount = 10;
    public float spawnInterval = 0.1f;
    public float flyDuration = 0.5f;
    public Ease flyEase = Ease.InOutQuad;
    public bool ignoreTimeScale = true;

    private Coroutine playRoutine;

    public void Play(int сount) {        
        itemCount = сount;
        Debug.Log(itemCount);
        if (playRoutine != null)
            StopCoroutine(playRoutine);

        playRoutine = StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine() {
        for (int i = 0; i < itemCount; i++) {
            SpawnAndAnimateOne();
            if (spawnInterval <=0) continue;
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

        Vector2 startAnchoredPos = WorldToCanvasPosition(startPoint.position);
        Vector2 endAnchoredPos = WorldToCanvasPosition(endPoint.position);

        instance.anchoredPosition = startAnchoredPos;

        instance
            .DOAnchorPos(endAnchoredPos, flyDuration)
            .SetEase(flyEase)
            .SetUpdate(ignoreTimeScale)
            .OnComplete(() =>
            {
                if (instance != null)
                    Destroy(instance.gameObject);
            });
    }

    private Vector2 WorldToCanvasPosition(Vector3 worldPosition) {
        Camera cam = targetCanvas.renderMode == RenderMode.ScreenSpaceOverlay
            ? null
            : targetCanvas.worldCamera;

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(cam, worldPosition);

        RectTransform canvasRect = targetCanvas.transform as RectTransform;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            screenPoint,
            cam,
            out Vector2 localPoint
        );

        return localPoint;
    }

    private void OnDisable() {
        if (playRoutine != null) {
            StopCoroutine(playRoutine);
            playRoutine = null;
        }
    }
}
