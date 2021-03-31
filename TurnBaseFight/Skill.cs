using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedFight
{
	enum SkillType
	{
		EnumNormalHealth = 0,
		EnumArcaneMissile,
		EnumCriticalHit,
		EnumLearnVital,
		EnumMoonWellPower,
		EnumBaseSkill,

	}

	//TODO: Skill status context notification
	enum SkillStatus
	{
		NoEnoughMP = 0,
		NoEnoughHP,
		NoEnoughUseTime,
		ActionSuccess
	}
	class SkillBase
	{
		public SkillBase(SkillType sType = SkillType.EnumBaseSkill, string name = "default skill", int MPCost = 0)
		{
			this.MPCost = MPCost;
			this.type = sType;
			this.name = name;
		}
		public int MPCost { get; protected set; }
		public string name { get; protected set; }
		public SkillType type { get; protected set; }

		virtual public SkillStatus GeneralAction(CharacterBase org, CharacterBase[] target)
		{
			if (!hasEnoughMp(org))
			{
				return SkillStatus.NoEnoughMP;
			}

			//asset must succ！
			org.MP -= MPCost;
			return RealAction(org, target);
		}

		virtual public SkillStatus RealAction(CharacterBase org, CharacterBase[] target)
		{
			Console.WriteLine("{0} is Zzzzzzzzzzzzzzz, nothing happend", org.name);
			return SkillStatus.ActionSuccess;
		}

		public bool hasEnoughMp(CharacterBase h)
		{
			return h.MP >= MPCost;
		}
	}

	class NormalHealth : SkillBase
	{
		int heal_num = 100;

		public NormalHealth()
		{
			this.type = SkillType.EnumNormalHealth;
			this.name = "NormalHealth";
			this.MPCost = 10;
		}

		override public SkillStatus RealAction(CharacterBase org, CharacterBase[] target)
		{
			foreach (var t in target)
			{
				t.HP += heal_num;
				Console.WriteLine("Healing {0} {1} HP! {2}'s current Hp is {3}", t.name, heal_num, t.name, t.HP);
			}
			return SkillStatus.ActionSuccess;
		}

		public override string ToString()
		{
			return "效果：消耗 " + this.MPCost + " 点Mp, 恢复选择目标 " + this.heal_num + " 点生命值";
		}
	}

	class ArcaneMissile : SkillBase
	{
		private int MDMG = 30;

		public ArcaneMissile()
		{
			this.type = SkillType.EnumArcaneMissile;
			this.name = "ArcaneMissile";
			this.MPCost = 10;
		}
		public override SkillStatus RealAction(CharacterBase org, CharacterBase[] target)
		{
			foreach (var t in target)
			{
				t.HP -= MDMG;
				Console.WriteLine("ArcaneMissile damge hero {0} {1} HP", t.name, MDMG);
			}
			return SkillStatus.ActionSuccess;
		}

		public override string ToString()
		{
			return "效果: 耗费 " + this.MPCost + " 点Mp，造成 " + this.MDMG + " 点伤害";
		}
	}

	class CriticalHit : SkillBase
	{
		public CriticalHit()
		{
			this.type = SkillType.EnumCriticalHit;
			this.name = "CriticalHit";
			this.MPCost = 5;
		}
		public override SkillStatus RealAction(CharacterBase org, CharacterBase[] target)
		{
			org.ATK *= 2;
			if (org.Attack(target) == AttackEffect.NormalHit)
				Console.WriteLine("CriticalHit!");
			org.ATK /= 2;
			return SkillStatus.ActionSuccess;
		}

		public override string ToString()
		{
			return "效果: 双倍基础伤害， 消耗 " + this.MPCost + " 点MP";
		}
	}

	class LearnVital : SkillBase
	{
		private Dictionary<CharacterBase, int> HitCnt;
		private int baseDmg = 30;
		public LearnVital()
		{
			this.type = SkillType.EnumLearnVital;
			this.name = "LearnVital";
			this.MPCost = 7;
			this.HitCnt = new Dictionary<CharacterBase, int>();
		}
		public override SkillStatus RealAction(CharacterBase org, CharacterBase[] target)
		{
			//TODO: only support single target now
			CharacterBase t = target[0];
			if (!HitCnt.ContainsKey(t))
			{
				HitCnt[t] = 1;
			}
			else
			{
				HitCnt[t] += 1;
			}

			
			int realDMG = (this.baseDmg + (HitCnt[t] - 1) * baseDmg) * (1 + (HitCnt[t] / 2));
			t.HP -= realDMG;
			Console.WriteLine("Damged {0} {1} Hp!", t.name, realDMG);

			return SkillStatus.ActionSuccess;
		}
		public override string ToString()
		{
			return "效果: 重复攻击同一个敌人会造成更高的伤害。在不断的战斗中知悉了敌人的要害";
		}
	}

	class MoonWellPower : SkillBase
	{
		private int recoverNum = 70;
		private int totalUseTimes = 3;
		private int remianUseTimes = 3;
		public MoonWellPower()
		{
			this.type = SkillType.EnumMoonWellPower;
			this.name = "MoonWellPower";
			this.MPCost = 0;
		}
		public override SkillStatus RealAction(CharacterBase org, CharacterBase[] target)
		{
			var t = target[0];
			if (this.remianUseTimes <= 0)
				return SkillStatus.NoEnoughUseTime;

			
			remianUseTimes--;
			if (t.MP + recoverNum > t.MaxMp)
			{
				t.MP = t.MaxMp;
			}
			else
			{
				t.MP += this.recoverNum;
			}

			return SkillStatus.ActionSuccess;
		}
		public override string ToString()
		{
			return "效果: 恢复被选中目标 " + this.recoverNum + " MP" + "剩余使用次数: " + this.remianUseTimes +  "/" + this.totalUseTimes;
		}
	}
}
