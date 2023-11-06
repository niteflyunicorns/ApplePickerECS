using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine.SceneManagement;

public partial struct AppleDropSystem : ISystem
{
    [ BurstCompile ]
    public void OnCreate( ref SystemState state )
    {

    }

    [ BurstCompile ]
    public void OnUpdate( ref SystemState state )
    {
        // instantiate apple if drop delay time is reached by system
        // "Tanks" Unity ECS tutorial @ 7:44 (line 27)
        
        // only spawn if drop delay time is reached by system
        foreach ( var ( transform, properties, spawner ) in
                SystemAPI.Query<RefRW<LocalTransform>, RefRW<AppleProperties>, RefRW<AppleSpawnProperties>>() )
        {
            Entity appleInstance = state.EntityManager.Instantiate( spawner.ValueRO.Apple );
            Entity tree = SystemAPI.GetSingletonEntity<AppleTreeProperties>();
            // var initPos = SystemAPI.GetComponent<AppleTreeProperties>( tree ).SpawnLocation;

            state.EntityManager.SetComponentData( appleInstance, new LocalTransform
            {
                Position = SystemAPI.GetComponent<AppleTreeProperties>( tree ).SpawnLocation
                // Rotation = SystemAPI.GetComponent<LocalTransform>(appleInstance).Rotation,
                // Scale = SystemAPI.GetComponent<LocalTransform>(appleInstance).Scale
            } );
            
            state.EntityManager.SetComponentData( appleInstance, new AppleSpawnProperties
            {
                Level = 1,
                AppleFreq = 1f,
                RotAppleChance = 0f,
                PoisAppleChance = 0f,
            } );

            // movement
            var pos = transform.ValueRO.Position;
            var speed = properties.ValueRO.Speed;

            pos.y -= speed * SystemAPI.Time.DeltaTime;
            transform.ValueRW.Position = pos;

            if ( pos.y < properties.ValueRO.BottomY )
            {
                // state.EntityManager.DestroyEntity( appleInstance );
            }
        }
    }
}