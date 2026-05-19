using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class FloorGenerator : MonoBehaviour {
    [SerializeField] private GameObject floorTilePrefab;
    [SerializeField] private int tilesX = 20;
    [SerializeField] private int tilesY = 5;
    [SerializeField] private float zValue = 1f;
    [SerializeField] private float tileSize = 0.5f;

#if UNITY_EDITOR
    [ContextMenu("Generate Floor")]
    public void GenerateFloor() {
        // Remove old Floor object if it exists
        Transform existing = transform.Find("Floor");
        if (existing != null)
            DestroyImmediate(existing.gameObject);

        // Create the Floor parent
        GameObject floorParent = new GameObject("Floor");
        floorParent.transform.SetParent(transform);
        floorParent.transform.localPosition = Vector3.zero;

        for (int x = 0; x < tilesX; x++) {
            for (int y = 0; y < tilesY; y++) {
                Vector3 pos = new Vector3(x * tileSize, y * tileSize, zValue);
                GameObject tile = (GameObject)PrefabUtility.InstantiatePrefab(floorTilePrefab, floorParent.transform);
                tile.transform.position = pos;
            }
        }
    }
#endif
}