using System.Collections.Generic;
using System.Linq;
using Enemy.Base;
using UnityEngine;

namespace Enemy.State_Machine.ConcreteStates
{
	public class EnemyIdleState : EnemyState
	{
		private List<Transform> points;
		private Vector3 _targetPos;
		private Vector3 _direction;
		private int _currentPoint;

		public EnemyIdleState(EnemyBase enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
		{
		}

		public override void EnterState()
		{
			base.EnterState();

			points = Enemy.points.ToList();

			_targetPos = points[_currentPoint].position;
		}

		public override void ExitState()
		{
			base.ExitState();
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();

			_direction = (_targetPos - Enemy.transform.position).normalized;

			Enemy.SetVelocity(_direction * 3);

			if ((points[_currentPoint].position - Enemy.transform.position).sqrMagnitude < 0.01f)
			{
				_targetPos = GetNextPoint();
			}
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}

		private Vector3 GetNextPoint()
		{
			if (_currentPoint < points.Count)
			{
				_currentPoint++;
			}
			else if (_currentPoint >= points.Count)
			{
				_currentPoint = 0;
			}

			return points[_currentPoint].position;
		}
	}
}
