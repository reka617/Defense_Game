
using UnityEngine;
using SState;

public class Student : MonoBehaviour
{
    StudentState _state;

    public Transform StudentPosition { get { return transform; } }
    private void Start()
    {
        Init();
    }
    void Update()
    {
        if (_state == null)
        {
            _state = new IdleState();
            _state.OnEnter(this);
        }
        if (_state != null) _state.MainLoop();
        Debug.Log("현재 상태 :" + _state);
    }

    public void Init()
    {
        transform.position = new Vector3(0, 0, 0); 
    }


    public void ChangeUnitState(StudentState state)
    {
        _state = state;
        if (_state != null) _state.OnEnter(this);
    }
}
