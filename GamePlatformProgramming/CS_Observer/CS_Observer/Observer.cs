using System;
using System.Collections.Generic;
using System.Text;

namespace CS_Observer
{
	class Unit
	{
		public int x;
		public int y;

		public Unit()
        {
			Console.WriteLine(this + "Unit");
		}
		
		//가상함수: 자식객체에서 해당함수를 구현하면 덮어씌울수있는 함수.
		public virtual void Attack(Unit target)
		{
			Console.WriteLine(this + ":Attack(" + target + ")");
		}
		public virtual void Move(int x, int y)
		{
			Console.WriteLine(this + ":Move(" + x + "," + y + ")");
		}
		public virtual void SkillA(Unit target)
		{
			Console.WriteLine(this + ":SkillA(" + target + ")");
		}
		public virtual void SkillB(Unit target)
		{
			Console.WriteLine(this + ":SkillB(" + target + ")");
		}
		public virtual void SkillC(Unit target)
		{
			Console.WriteLine(this + ":SkillC(" + target + ")");
		}
	};

	class Marin : Unit
	{
		public Marin()
		{
			Console.WriteLine(this + "Unit");
		}
		public override void SkillA(Unit target)
		{
			Console.WriteLine(this + ":Active StillPack(" + target + ")");
		}
	}

	class Medic : Unit
	{
		public Medic()
		{
			Console.WriteLine(this + "Unit");
		}
		public override void Attack(Unit target)
		{
			Move(target.x, target.y);
		}

		public override void SkillA(Unit target)
		{
			Console.WriteLine(this + ":Active Hill(" + target + ")");
		}
		public override void SkillB(Unit target)
		{
			Console.WriteLine(this + ":Recovery(" + target + ")");
		}
	}

	class Commader
    {
		List<Unit> group = new List<Unit>();
		public enum E_COMMAND { ATK, MOV };

		public void AddGroup(Unit unit)
        {
			group.Add(unit);
        }

		public void RemoveGroup(Unit unit)
        {
			group.Remove(unit);
        }

		public void Command(E_COMMAND command, Unit target)
		{
			switch (command)
			{
				case E_COMMAND.ATK:
					for (int i = 0; i < group.Count; i++)
						group[i].Attack(target);
					break;
				case E_COMMAND.MOV:
					for (int i = 0; i < group.Count; i++)
						group[i].Move(10, 10);
					break;
				default:
					break;
			}
		}
	}
}
