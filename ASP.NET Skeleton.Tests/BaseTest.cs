namespace ASP.NET_Skeleton.Tests
{
    public class BaseTest
    {
        protected Fixture _fixture = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _fixture.RepeatCount = default;
        }
    }
}
