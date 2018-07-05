public class Drone : UnitBehavior
{
	protected override void Defend(Unit other, int damage)
	{
		var realDamage = damage;
		if (other is Drone)
			realDamage *= 2;//Assault Units deals double damage to Scout Units.

		base.Defend(other, realDamage);
	}
}