
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 简单工厂
/// </summary>
namespace Test.DesignPattern.FactorySimple
{
    #region 简单工厂模式
    abstract class Product
    {
        //所有产品类的公共业务方法
        public void methodSame()
        {
            Console.WriteLine("我是公共方法");
        }

        //抽象业务方法
        public abstract void methodDiff();
    }
    //具体产品类
    class ConcreteProductA : Product
    {
        //实现业务方法
        public override void methodDiff()
        {
            Console.WriteLine("我是ConcreteProductA方法");
        }
    }
    //具体产品类
    class ConcreteProductB : Product
    {
        //实现业务方法
        public override void methodDiff()
        {
            Console.WriteLine("我是ConcreteProductB方法");
        }
    }
    class Factory
    {
        public static Product getProduct(string arg)
        {
            Product product = null;
            if (arg.Equals("A"))
            {
                product = new ConcreteProductA();
            }
            else if (arg.Equals("B"))
            {
                product = new ConcreteProductB();
            }
            return product;
        }
    }
    #endregion

    #region 简化简单工厂模式
    /// <summary>
    /// 有时为了简化简单工厂模式，
    /// 可以将抽象产品类和工程类合并，
    /// 将静态工厂方法移至抽象产品类中。
    /// </summary>
    abstract class ProductNew
    {
        public abstract void Display();

        public static ProductNew GetInstance(string type)
        {
            ProductNew product = null;
            if (type.Equals("Product1"))
            {
                product = new Product1();
            }
            else if (type.Equals("Product2"))
            {
                product = new Product2();
            }
            return product;
        }
    }
    class Product1 : ProductNew
    {
        public Product1()
        {
            Console.WriteLine("创建Product1");
        }
        public override void Display()
        {
            Console.WriteLine("显示Product1");
        }
    }
    class Product2 : ProductNew
    {
        public Product2()
        {
            Console.WriteLine("创建Product2");
        }
        public override void Display()
        {
            Console.WriteLine("显示Product2");
        }
    }
    #endregion

    #region Chart 图表重构

    abstract class Chart
    {
        public abstract void display();
    }

    class HistogramChart : Chart
    {
        public HistogramChart()
        {
            Console.WriteLine("创建柱状图");
        }
        public override void display()
        {
            Console.WriteLine("显示柱状图");
        }
    }
    class lineChart : Chart
    {
        public lineChart()
        {
            Console.WriteLine("创建折线图");
        }
        public override void display()
        {
            Console.WriteLine("显示折线图");
        }
    }
    class PineChart : Chart
    {
        public PineChart()
        {
            Console.WriteLine("创建饼状图");
        }
        public override void display()
        {
            Console.WriteLine("显示饼状图");
        }
    }

    class ChartFactory
    {
        public static Chart getChart(string type)
        {
            Chart chart = null;
            if (type.Equals("histogram"))
            {
                chart = new HistogramChart();
            }
            else if (type.Equals("pine"))
            {
                chart = new PineChart();
            }
            else if (type.Equals("line"))
            {
                chart = new lineChart();
            }
            return chart;
        }
    }
    #endregion
}
