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
            var entity = new Entity();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Id);
            entity.Id = 10;
            var result = cfg.Assert();
            result.Should().BeTrue();
        }

        [Fact]
        public void Assert_Should_Be_True_If_Props_Changed()
        {
            var entity = new Entity();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Id)
                .ShouldChange(obj => obj.Name);
            entity.Id = 10;
            entity.Name = string.Empty;
            var result = cfg.Assert();
            result.Should().BeTrue();
        }

        [Fact]
        public void Assert_Should_Be_False_If_Prop_Not_Changed()
        {
            var entity = new Entity {Name = string.Empty};
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Name);
            var result = cfg.Assert();
            result.Should().BeFalse();
        }

        [Fact]
        public void Assert_Should_Be_False_If_All_Props_Not_Changed()
        {
            var entity = new Entity();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Id)
                .ShouldChange(obj => obj.Name);
            entity.Id = 10;
            var result = cfg.Assert();
            result.Should().BeFalse();
        }

        [Fact]
        public void Assert_Should_Be_True_If_Nested_Prop_Changed()
        {
            var entity = new Entity();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Address.Name);
            entity.Address.Name = string.Empty;
            var result = cfg.Assert();
            result.Should().BeTrue();
        }

        [Fact]
        public void Assert_Should_Be_False_If_Nested_Prop_Not_Changed()
        {
            var entity = new Entity();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Address.Name);
            var result = cfg.Assert();
            result.Should().BeFalse();
        }

        [Fact]
        public void Assert_Should_Be_False_If_Nested_Reference_Prop_Not_Changed()
        {
            var entity = new Entity();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Address);
            entity.Address.Name = string.Empty;
            var result = cfg.Assert();
            result.Should().BeFalse();
        }

        [Fact]
        public void Assert_Should_Be_True_If_Nested_Reference_Prop_Changed()
        {
            var entity = new Entity();
            var cfg = Except.That(entity)
                .ShouldChange(obj => obj.Address);
            entity.Address = new Address();
            var result = cfg.Assert();
            result.Should().BeTrue();
        }
    }
}