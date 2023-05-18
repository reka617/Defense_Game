
using UnityEngine;

namespace SState
{
    public class StudentState : MonoBehaviour
    {
        protected Student _student;

        public virtual void OnEnter(Student student)
        {
            _student = student;
        }

        public virtual void MainLoop()
        {

        }
    }

    public class IdleState : StudentState
    {
        public override void OnEnter(Student student)
        {
            base.OnEnter(student);
        }

        public override void MainLoop()
        {
            //캐릭터 기본 상태
        }
    }

    public class ReloadState : StudentState
    {
        public override void OnEnter(Student student)
        {
            base.OnEnter(student);
        }

        public override void MainLoop()
        {
            //캐릭터 탄환장전
        }
    }

    public class HittedStudentState : StudentState
    {

    }

    public class AttackState : StudentState
    {


        public override void OnEnter(Student student)
        {
            base.OnEnter(student);
        }

        public override void MainLoop()
        {
            
        }
    }
}