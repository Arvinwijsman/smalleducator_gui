using UnityEngine;

namespace LeafManupulator
{
    public class FlyOut : FlyIn
    {
        public FlyOut(Vector3 startPosition, float durationInSeconds) : 
            base(startPosition,
                (Random.value > 0.5) ?
                new Vector3(startPosition.x + (Random.Range(-1.0f, 1.0f) * 1000.0f), startPosition.y - 1000.0f) :
                new Vector3(startPosition.x + (Random.Range(-1.0f, 1.0f) * 1000.0f), startPosition.y + 1000.0f)
                , durationInSeconds)
        {
        }
    }
}