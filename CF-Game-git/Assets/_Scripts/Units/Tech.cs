public class Tech : UnitBehavior
{
	protected override void Defend(Unit other, int damage)
	{
		var realDamage = damage;
		if (other is Scout)
			realDamage *= 2;//Scout Units deals double damage to Heavy Units.

		base.Defend(other, realDamage);
	}
}
