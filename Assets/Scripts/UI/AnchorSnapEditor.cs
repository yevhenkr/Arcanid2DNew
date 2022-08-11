﻿using UnityEditor;
using UnityEngine;

public class AnchorSnapEditor : Editor
{
    [MenuItem("Anchor Snap/parent and children", false, 0)]
    private static void SnapParentAndChildrenMenuItem()
    {
        SnapAnchorsMultiple(Selection.activeGameObject);
    }

    [MenuItem("Anchor Snap/just parent", false, 0)]
    private static void SnapParentMenuItem()
    {
        SnapAnchors(Selection.activeGameObject);
    }

    [MenuItem("GameObject/Anchor Snap/parent and children %[", false, 0)]
    private static void SnapParentAndChildrenGameObject()
    {
        SnapAnchorsMultiple(Selection.activeGameObject);
    }

    [MenuItem("GameObject/Anchor Snap/just parent %]", false, 0)]
    private static void SnapParentGameObject()
    {
        SnapAnchors(Selection.activeGameObject);
    }

    private static void SnapAnchors(GameObject gameObject)
    {
        RectTransform recTransform = null;
        RectTransform parentTransform = null;
        if (gameObject.transform.parent != null)
        {
            if (gameObject.GetComponent<RectTransform>() != null)
            {
                recTransform = gameObject.GetComponent<RectTransform>();
            }
            else
            {
                return;
            }

            if (parentTransform == null)
            {
                parentTransform = gameObject.transform.parent.GetComponent<RectTransform>();
            }

            Undo.RecordObject(recTransform, "Snap Anchors");
            Vector2 offsetMin = recTransform.offsetMin;
            Vector2 offsetMax = recTransform.offsetMax;
            Vector2 anchorMin = recTransform.anchorMin;
            Vector2 anchorMax = recTransform.anchorMax;
            Vector2 parent_scale = new Vector2(parentTransform.rect.width, parentTransform.rect.height);
            recTransform.anchorMin = new Vector2(anchorMin.x + (offsetMin.x / parent_scale.x),
                anchorMin.y + (offsetMin.y / parent_scale.y));
            recTransform.anchorMax = new Vector2(anchorMax.x + (offsetMax.x / parent_scale.x),
                anchorMax.y + (offsetMax.y / parent_scale.y));
            recTransform.offsetMin = Vector2.zero;
            recTransform.offsetMax = Vector2.zero;
        }
    }

    private static void SnapAnchorsMultiple(GameObject gameObject)
    {
        SnapAnchors(gameObject);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            SnapAnchorsMultiple(gameObject.transform.GetChild(i).gameObject);
        }
    }
}