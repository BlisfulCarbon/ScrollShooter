using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    public float timeLife = 0;
    private float timeLifeSecond;

    private void Start()
    {
        timeLifeSecond = timeLife;
    }

    void Update()
    {
        if (timeLifeSecond < 0)
        {
            Destroy(this.gameObject);
        }
        timeLifeSecond -= Time.deltaTime;
    }
}
