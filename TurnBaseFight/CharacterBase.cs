using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace TurnBasedFight
{
	enum CharacterType
	{
		monister = 0,
		goblin,
		goblinKing,
		hero,

	}
	class CharacterBase
	{
		public int HP { get; set; }
		public int MaxHp { get; set; }
		public int DEF { get; set; }
		public int MP { get; set; }
		public int MaxMp { get; set; }
		public int ATK;
		public int DEX;
		public string name = "Default name";

		public bool isAuto = false; //for AI
		public bool isDead {get; set;} = false;
		public bool isMoniter = false;
		public CharacterType chaType;
		//TODO：Dynamic speed for turn
		public CharacterBase(int _HP = 100, int _DEF = 10, int _MP = 30, int _ATK = 10, int _DEX = 10)
		{
			MaxHp = _HP;
			HP = _HP;
			MaxMp = _MP;
			DEF = _DEF;
			MP = _MP;
			ATK = _ATK;
			DEX = _DEX;
		}

		public Dictionary<SkillType, SkillBase> onwSkill = new Dictionary<SkillType, SkillBase>();

		public void ShowStatus()
		{
			Console.WriteLine("Name: {0} HP: {1} MP: {2} ", name, HP, MP);
		}

		public AttackEffect Attack(CharacterBase[] hList)
		{
			//TODO: Mul target
			CharacterBase h = hList[0];
			if (this.ATK <= h.DEF)
			{
				Console.WriteLine("{0}'s attack is so weak that can not hurt other!", this.name);
				return AttackEffect.ATkLowerThanDEF;
			}

			// TODO: miss check

			// TODO: crital hit

			// normal hit
			int dmg = this.ATK - h.DEF;
			h.HP -= dmg;
			Console.WriteLine("Dameged {0} {1} HP!", h.name, dmg);

			return AttackEffect.NormalHit;
		}

		virtual public SkillStatus UseSkill(SkillType sType, CharacterBase org, CharacterBase[] target)
		{
			return org.onwSkill[sType].GeneralAction(this, target);
		}

	}
}
