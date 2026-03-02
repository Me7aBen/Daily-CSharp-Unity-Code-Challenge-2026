using NUnit.Framework;
using DailyChallenges.Day01;

public class HealthTests
{
    [Test]
    public void Health_OnTakeDamage_FiresEvent()
    {
        var health = new Health(100f);
        float received = -1f;
        health.OnHealthChanged += (val) => received = val;

        health.TakeDamage(30f);

        Assert.AreEqual(70f, received);
    }

    [Test]
    public void Health_AtZero_FiresOnDied()
    {
        var health = new Health(50f);
        bool died = false;
        health.OnDied += () => died = true;

        health.TakeDamage(50f);

        Assert.IsTrue(died);
    }
}