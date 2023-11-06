using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class AppleSpawnAuthoring : MonoBehaviour
{
    public GameObject apple;
    public GameObject rotApple;
    public GameObject poisApple;
    public float level;
    public float appleFreq;
    public float rotAppleChance;
    public float poisAppleChance;
        // need to get sceneName or difficulty somehow

    private class AppleSpawnBaker : Baker<AppleSpawnAuthoring>
    {
        public override void Bake( AppleSpawnAuthoring authoring )
        {
            var entity = GetEntity( TransformUsageFlags.Dynamic );
            var spawnPropComponent = new AppleSpawnProperties
            {
                Level = authoring.level,
                AppleFreq = authoring.appleFreq,
                RotAppleChance = authoring.rotAppleChance,
                PoisAppleChance = authoring.poisAppleChance,
                Apple = GetEntity( authoring.apple, TransformUsageFlags.Dynamic ),
                RotApple = GetEntity( authoring.rotApple, TransformUsageFlags.Dynamic ),
                PoisApple = GetEntity( authoring.poisApple, TransformUsageFlags.Dynamic ),
                RandomDrop = Random.CreateFromIndex( (uint)entity.Index )
            };

            AddComponent( entity, spawnPropComponent );
        }
    }
}

public struct AppleSpawnProperties : IComponentData
{
    public float Level;
    public float AppleFreq;
    public float RotAppleChance;
    public float PoisAppleChance;
    public Entity Apple;
    public Entity RotApple;
    public Entity PoisApple;

    public Random RandomDrop;
}