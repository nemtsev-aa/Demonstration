using UnityEditor;
using UnityEngine;

public class Striker : MonoBehaviour {

    [Tooltip("��������� �����")]
    [SerializeField] private float _distanceToAttack = 4f;
    [Tooltip("������")]
    [SerializeField] private GameObject _markerToAttack;
    [Tooltip("���������� ���� ��� ��������� ����")]
    [SerializeField] private LayerMask _layerMask;
    [Tooltip("��������")]
    [SerializeField] private Animator _animator;
    [Tooltip("������ ����������� ������")]
    [SerializeField] private RigidbodyMove _rigidBodyMove;


    private void FixedUpdate() {
        switch (_rigidBodyMove.CurrentMoveStatus) {
            case MoveStatus.Stop:

                break;
            case MoveStatus.Active:

                break;

            default:
                break;
        }
    }

    //public void Attack(EnemyAnimal[] targetList) {
    //    EnemyAnimal targetToStrike = targetList[0]; // ������� ���� ��� �����
    //    transform.LookAt(new Vector3(targetToStrike.transform.position.x, 0f, targetToStrike.transform.position.z));
    //    StrikeToEnemy(targetToStrike);
    //}

    //public void StrikeToEnemy(EnemyAnimal animal)
    //{
    //    if (!animal.transform.GetComponentInChildren<ShowTargetMark>())
    //    {
    //        _markerToAttack.GetComponent<ShowTargetMark>().SetTarget(animal.transform);
    //        _animator.SetBool("Attack", true);
    //    }
    //}

#if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, _distanceToAttack);
    }
#endif
}
