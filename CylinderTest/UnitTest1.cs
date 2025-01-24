using CylinderProject.Models;

namespace CylinderTest;

public class UnitTest1
{
    [Fact]
    public void CtorTest()
    {
        var cylinder = new Cylinder(5, 10);

        Assert.Equal(5, cylinder.Radius);
        Assert.Equal(10, cylinder.Height);
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(-1, 10)]
    [InlineData(5, 0)]
    [InlineData(5, -1)]
    public void CtorShouldFail(double radius, double height)
    {
        Assert.Throws<ArgumentException>(() => new Cylinder(radius, height));
    }

    [Theory]
    [InlineData(4.84, 100.847)]
    [InlineData(50.874, 100)]
    [InlineData(700.1, 90)]
    [InlineData(3.2, 20.84)]
    public void MethodsTest(double radius, double height)
    {
        var cylinder = new Cylinder(radius, height);
        
        Assert.Equal(Math.PI * Math.Pow(radius, 2) * height, cylinder.GetVolume(), precision:2);
        Assert.Equal(2 * Math.PI * Math.Pow(radius, 2) + 2 * Math.PI * radius * height, cylinder.GetSurfaceArea(), precision:2);
    }

    [Fact]
    public void ResizeTest1()
    {
        var cylinder = new Cylinder(5, 10);
        cylinder.Resize(6, 9);

        Assert.Equal(6, cylinder.Radius);
        Assert.Equal(9, cylinder.Height);
    }

    [Theory]
    [InlineData(0, 2)]
    [InlineData(-3, 2)]
    [InlineData(7, 0)]
    [InlineData(7, -3)]
    public void ResizeShouldFail(double radius, double height)
    {
        Assert.Throws<ArgumentException>(() => new Cylinder(2, 2).Resize(radius, height));
    }

    [Fact]
    public void NotNullTest()
    {
        Assert.NotNull(new Cylinder(5, 10));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(34)]
    [InlineData(51)]
    public void RadiusInRangeTest(double radius)
    {
        Assert.InRange(radius, 1, 100);
    }
}