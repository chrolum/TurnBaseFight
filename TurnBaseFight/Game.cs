using System;
using System.Collections;
using System.Collections.Generic;

namespace TurnBasedFight
{
	enum AttackEffect
	{
		ATkLowerThanDEF = 0,
		MISS,
		NormalHit,
		CritalHit
	}

	enum ActionType
	{
		Attack = 0,
		Skill,
		ActionEnd

	}

	class Game
	{
		public Queue<CharacterBase> turnQueue { get; }
		public CharacterBase[] characterList;
		public CharacterBase[] heros;
		public CharacterBase[] monisters;
		//TODO: Dyna queue
		public Game()
		{
			// Custom hero

			characterList = new CharacterBase[5];
			heros = new CharacterBase[2];
			monisters = new CharacterBase[3];
			CharacterBase h1 = new WitchDoctor(100, 20, 300, 20, 10);
			//GameObjectBase h2 = new Magician(50, 15, 300, 20, 10);
			CharacterBase h2 = new Warrior(200, 15, 120, 30, 10);
			characterList[0] = h1;
			characterList[1] = h2;
			//gameObjs[2] = h3;
			heros[0] = h1;
			heros[1] = h2;
			//heros[2] = h3;
			CharacterBase m1 = new Goblin("Goblin1");
			CharacterBase m2 = new Goblin("Goblin2");
			CharacterBase m3 = new GoblinKing("Goblin King1", _ATK:30, _HP:2000);
			characterList[2] = m1;
			characterList[3] = m2;
			characterList[4] = m3;
			monisters[0] = m1;
			monisters[1] = m2;
			monisters[2] = m3;
			turnQueue = new Queue<CharacterBase>();
			turnQueue.Enqueue(h1);
			turnQueue.Enqueue(m1);
			turnQueue.Enqueue(h2);
			turnQueue.Enqueue(m2);
			//turnQueue.Enqueue(h3);
			turnQueue.Enqueue(m3);

			// GameObject m1 = new;
		}

		public CharacterBase[] SelectTarget(SkillType sType = SkillType.EnumBaseSkill)
		{
			//TODO multarget select
			CharacterBase[] tar = new CharacterBase[1];
			Dictionary<int, int> showIdxToRealIdaxMap = new Dictionary<int, int>();
			Console.WriteLine("Select target:");
			int s_idx = 0;
			for (int i = 0; i < characterList.Length; i++)
			{
				// TODO: 在技能类增加一个字段，指示该技能指向自己人还是敌人
				if (sType == SkillType.EnumNormalHealth || sType == SkillType.EnumMoonWellPower)
				{
					// only can select hero
					if (!characterList[i].isDead && !characterList[i].isMoniter)
					{
						showIdxToRealIdaxMap[s_idx] = i;
						Console.Write("{0} : {1}       ", s_idx++, characterList[i].name);
					}
				}
				else
				{
					if ((!characterList[i].isDead && characterList[i].isMoniter))
					{
						showIdxToRealIdaxMap[s_idx] = i;
						Console.WriteLine("{0} : {1}", s_idx++, characterList[i].name);
					}
				}
			}
			//TODO: vaild input check
			int n = Utills.GetUserIntInput();
			tar[0] = this.characterList[showIdxToRealIdaxMap[n]];
			return tar;
		}

		public SkillType SelectSkillType(CharacterBase h)
		{
			Dictionary<int, SkillType> selToSTypeMap = new Dictionary<int, SkillType>();
			int idx = 0;
			int t;
			// map the selection to skill
			
			foreach (var s in h.onwSkill)
			{
				selToSTypeMap[idx] = s.Value.type;
				Console.WriteLine("{0}: {1} {2}", idx++, s.Value.name, s.Value.ToString());
			}
			
			REGET:
			Console.WriteLine("Select a skill");
			t = Utills.GetUserIntInput();
			if (!selToSTypeMap.ContainsKey(t))
			{
				Console.WriteLine("No this skill!");
				goto REGET;
			}
			
			return selToSTypeMap[t];
		}

		public bool isWin()
		{
			for (int i = 0; i < monisters.Length; i++)
			{
				if (!monisters[i].isDead)
					return false;
			}
			return true;
		}

		public bool isFailed()
		{
			for (int i = 0; i < heros.Length; i++)
			{
				if (!heros[i].isDead)
				{
					return false;
				}
			}
			return true;
		}
	}
}
