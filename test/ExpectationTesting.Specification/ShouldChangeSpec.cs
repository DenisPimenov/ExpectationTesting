using ExpectationTesting.Specification.TestsObjects;
using FluentAssertions;
using Xunit;

namespace ExpectationTesting.Specification
{
    public class ShouldChangeSpec
    {
        [Fact]
        public void Assert_Should_Be_True_If_Prop_Changed()
        {
            //arrange
            var entity = new Entity();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Id);
            //act
            entity.Id = 10;
            //assert
            var result = cfg.Assert();
            result.Should().BeTrue();
        }

        [Fact]
        public void Assert_Should_Be_True_If_Props_Changed()
        {
            //arrange
            var entity = new Entity ();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Id)
                .ShouldChange(obj => obj.Name);
            //act
            entity.Id = 10;
            entity.Name = string.Empty;
            //assert
            var result = cfg.Assert();
            result.Should().BeTrue();
        }

        [Fact]
        public void Assert_Should_Be_False_If_Prop_Not_Changed()
        {
            //arrange
            var entity = new Entity {Name = string.Empty};
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Name);
            //assert
            var result = cfg.Assert();
            result.Should().BeFalse();
        }

        [Fact]
        public void Assert_Should_Be_False_If_All_Props_Not_Changed()
        {
            //arrange
            var entity = new Entity();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Id)
                .ShouldChange(obj => obj.Name);
            //act
            entity.Id = 10;
            //assert
            var result = cfg.Assert();
            result.Should().BeFalse();
        }

        [Fact]
        public void Assert_Should_Be_True_If_Nested_Prop_Changed()
        {
            //arrange
            var entity = new Entity();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Address.Name);
            //act
            entity.Address.Name =string.Empty;
            //assert
            var result = cfg.Assert();
            result.Should().BeTrue();
        }

        [Fact]
        public void Assert_Should_Be_False_If_Nested_Prop_Not_Changed()
        {
            //arrange
            var entity = new Entity ();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Address.Name);
            //assert
            var result = cfg.Assert();
            result.Should().BeFalse();
        }
    }
}