
using UnityEngine;
using SState;

public class Student : MonoBehaviour
{
    StudentState _state;
    StudentBase _SB;
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

    public void init(StudentBase SB)
    {
        _SB = SB;
    }

    public void ChangeUnitState(StudentState state)
    {
        _state = state;
        if (_state != null) _state.OnEnter(this);
    }

}
