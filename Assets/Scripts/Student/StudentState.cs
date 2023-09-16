
using UnityEngine;

namespace SState
{
    public class StudentState
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
            //ĳ���� �⺻ ����
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
            //ĳ���� źȯ����
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

    public class ShieldState : StudentState // �������溮���� �ǵ����
    {
        public override void OnEnter(Student student)
        {
            base.OnEnter(student);
        }

        public override void MainLoop()
        {
            base.MainLoop();
        }
    }
}