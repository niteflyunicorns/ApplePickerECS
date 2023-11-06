using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;
using UnityEngine.UI;

public class SceneAuthoring : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets;
    public float basketBottomY;
    public float basketSpacingY;
    // public List<GameObject> basketList;
    public string sceneName;
    
    private class SceneBaker : Baker<SceneAuthoring>
    {
        public override void Bake( SceneAuthoring authoring )
        {
            var entity = GetEntity( TransformUsageFlags.Dynamic );
            var scenePropComponent = new SceneProperties
            {
                BasketPrefab = GetEntity( authoring.basketPrefab, TransformUsageFlags.Dynamic ),
                NumBaskets = authoring.numBaskets,
                BasketBottomY = authoring.basketBottomY,
                BasketSpacingY = authoring.basketSpacingY,
                // 
            };

            AddComponent( entity, scenePropComponent );
        }
    }
}

public struct SceneProperties : IComponentData
{
    public Entity BasketPrefab;
    public int NumBaskets;
    public float BasketBottomY;
    public float BasketSpacingY;
    // public NativeArray( Entity ) basketList;
    public int BasketNumber;
    public int Level;
}