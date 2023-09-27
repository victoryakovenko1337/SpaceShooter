using UnityEngine;

public class PointsForDestroy : MonoBehaviour
{
    [SerializeField, Min(0)] private int _points;

    private void Start()
    {
        ScoreCounter scoreCounter = FindObjectOfType<ScoreView>().Counter;
        Counter killsCounter = FindObjectOfType<KillsView>().Counter;
        Unit spaceObject = GetComponent<Unit>();

        spaceObject.OnDieEvent.AddListener(() => { 
            scoreCounter.AddPoints(_points); 
            if (spaceObject.GetType() == typeof(Enemy))
                killsCounter.AddPoints();
        });
    }
}
