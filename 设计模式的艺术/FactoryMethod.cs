using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 工厂模式
/// </summary>
namespace Test.DesignPattern.FactoryMethod
{
    #region 工厂模式
    abstract class Product
    {
        public abstract void Display();
    }

    class ConcreteProductA : Product
    {
        public ConcreteProductA()
        {
            Console.WriteLine("创建ConcreteProductA");
        }
        public override void Display()
        {
            Console.WriteLine("显示我是ConcreteProductA");
        }
    }
    class ConcreteProductB : Product
    {
        public ConcreteProductB()
        {
            Console.WriteLine("创建ConcreteProductB");
        }
        public override void Display()
        {
            Console.WriteLine("显示我是ConcreteProductB");
        }
    }
    //抽象工厂
    interface Factory
    {
        Product factoryMethod();
    }
    class ConcreteFactoryA : Factory
    {
        public Product factoryMethod()
        {
            return new ConcreteProductA();
        }
    }
    class ConcreteFactoryB : Factory
    {
        public Product factoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    #endregion

    #region 日志记录器

    //日志记录器接口：抽象产品
    interface Logger
    {
        void writeLog();
    }

    class DatabaseLogger : Logger
    {
        public void writeLog()
        {
            Console.WriteLine("数据库日志");
        }
    }
    class FileLogger : Logger
    {
        public void writeLog()
        {
            Console.WriteLine("文件日志");
        }
    }
    //日志记录工厂接口：抽象工厂
    interface LoggerFactory
    {
        Logger createLogger();
    }
    class DatabaseLoggerFactory : LoggerFactory
    {
        public Logger createLogger()
        {
            Logger logger = new DatabaseLogger();
            //其它代码
            return logger;
        }
    }

    class FileLoggerFactory : LoggerFactory
    {
        public Logger createLogger()
        {
            Logger logger = new FileLogger();
            //其它代码
            return logger;
        }
    }
    #endregion
}
