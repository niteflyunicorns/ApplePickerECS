using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;
using UnityEngine.UI;

public class BasketAuthoring : MonoBehaviour
{
    // public Text scoreGT;
    public float delay;
    
    private class BasketBaker : Baker<BasketAuthoring>
    {
        public override void Bake( BasketAuthoring authoring )
        {
            var entity = GetEntity( TransformUsageFlags.Dynamic );
            // var basketPropComponent = new BasketProperties
            // {
            //     // ScoreGT = int.Parse( GameObject.Find( "ScoreCounter" ).GetComponent<Text>().text ),
            //     Delay = authoring.delay,
            // };

            var mouseMoveComponent = new MoveWithMouse {
                move = true
            };

            // AddComponent( entity, basketPropComponent );
            AddComponent( entity, mouseMoveComponent );
        }
    }
}

public struct BasketProperties : IComponentData
{
    public int ScoreGT;
    public bool PoisonSlowFlag;
    public float Delay;
    float Timer;
    public int NumBaskets;
}

public struct MoveWithMouse: IComponentData {
    public bool move;
}