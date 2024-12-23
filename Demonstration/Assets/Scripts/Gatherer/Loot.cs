using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Loot : MonoBehaviour {

    [SerializeField] private float _timeToCollector;
    
    private Collider _collider;

    private void Awake() {
        _collider ??= GetComponentInChildren<Collider>();
    }



    public void Collect(Collector collector) {
        _collider.enabled = false;

        transform.DOJump(collector.transform.position, 3f, 1, _timeToCollector)
                 .SetEase(Ease.Flash)
                 .OnComplete(() => Take());

        //StartCoroutine(MoveToCollector(collector)); 
    }

    private IEnumerator MoveToCollector(Collector collector) {
        Vector3 a = transform.position; 
        Vector3 b = a + Vector3.up * 2f; 


        for (float t = 0; t < 1f; t += Time.deltaTime / _timeToCollector) {
            Vector3 d = collector.transform.position; 
            Vector3 c = d + Vector3.up * 2f; 

            Vector3 position = Bezier.GetPoint(a, b, c, d, t);
            transform.position = position; 

            yield return null;
        }

        Take();
    }

    public virtual void Take() {
        Destroy(gameObject); 
    }
}
