using Unity.Burst;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Entities;
using UnityEngine;

// add in only x movement (so that y doesn't move)
public partial struct MouseMovementSystem : ISystem
{
    public void OnUpdate( ref SystemState state ) {
        foreach ( var ( transform, properties ) in SystemAPI.Query< RefRW< LocalTransform >, RefRW< BasketProperties > > () ) {
            var pos = Input.mousePosition;
            pos.z -= Camera.main.transform.position.z;
            transform.ValueRW.Position = Camera.main.ScreenToWorldPoint( pos );
        }
    }
}
