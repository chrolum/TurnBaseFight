using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedFight
{
	class Monister
	{
		public static CharacterBase CreateGoblin(string _name, int _HP = 100, int _DEF = 10, int _MP = 30, int _ATK = 10, int _DEX = 10)
		{
			CharacterBase goblin = new CharacterBase(_HP, _DEF, _MP, _ATK, _DEX);
			goblin.name = _name;
			goblin.isAuto = true;
			goblin.isMoniter = true;
			goblin.chaType = CharacterType.goblin;
			goblin.onwSkill[SkillType.EnumBaseSkill] = GlobalSkillPool.RegisterSkill(SkillType.EnumBaseSkill);

			return goblin;
		}

		public static CharacterBase CreateGoblinKing(string _name, int _HP = 100, int _DEF = 10, int _MP = 30, int _ATK = 10, int _DEX = 10)
		{
			CharacterBase m = new CharacterBase(_HP: 100, _DEF: 10, _MP: 30, _ATK: 10, _DEX: 10);
			m.name = _name;
			m.isAuto = true;
			m.isMoniter = true;
			m.chaType = CharacterType.goblinKing;
			m.onwSkill[SkillType.EnumBaseSkill] = GlobalSkillPool.RegisterSkill(SkillType.EnumBaseSkill);
			m.onwSkill[SkillType.EnumArcaneMissile] = GlobalSkillPool.RegisterSkill(SkillType.EnumArcaneMissile);
			m.onwSkill[SkillType.EnumNormalHealth] = GlobalSkillPool.RegisterSkill(SkillType.EnumNormalHealth);
			m.onwSkill[SkillType.EnumCriticalHit] = GlobalSkillPool.RegisterSkill(SkillType.EnumCriticalHit);

			return m;
		}
	}

	class Goblin : CharacterBase
	{
		public Goblin(string _name = "Goblin", int _HP = 100, int _DEF = 10, int _MP = 30, int _ATK = 10, int _DEX = 10)
			: base(_HP, _DEF, _MP, _ATK, _DEX)
		{
			name = _name;
			onwSkill[SkillType.EnumBaseSkill] = GlobalSkillPool.RegisterSkill(SkillType.EnumBaseSkill);
			isAuto = true;
			isMoniter = true;
		}
	}
	class GoblinKing : CharacterBase
	{
		public GoblinKing(string _name = "Goblin King", int _HP = 300, int _DEF = 10, int _MP = 300, int _ATK = 10, int _DEX = 10)
			: base(_HP, _DEF, _MP, _ATK, _DEX)
		{
			name = _name;
			onwSkill[SkillType.EnumBaseSkill] = GlobalSkillPool.RegisterSkill(SkillType.EnumBaseSkill);
			onwSkill[SkillType.EnumArcaneMissile] = GlobalSkillPool.RegisterSkill(SkillType.EnumArcaneMissile);
			onwSkill[SkillType.EnumNormalHealth] = GlobalSkillPool.RegisterSkill(SkillType.EnumNormalHealth);
			onwSkill[SkillType.EnumCriticalHit] = GlobalSkillPool.RegisterSkill(SkillType.EnumCriticalHit);
			isAuto = true;
			isMoniter = true;
		}
	}
}
