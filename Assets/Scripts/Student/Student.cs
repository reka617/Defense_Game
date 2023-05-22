
using UnityEngine;
using SState;

public class Student : MonoBehaviour
{
    StudentState _state;
   
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

    public void init()
    {
        transform.position = new Vector3(0, 1, -1); 
    }

    public void ChangeUnitState(StudentState state)
    {
        _state = state;
        if (_state != null) _state.OnEnter(this);
    }

}
