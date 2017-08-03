using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test.DesignPattern
{
    class PriceSingletion
    {
        public static int SetNumber { get; set; }

        private static List<PriceSingletion> listSingleton = null;

        private PriceSingletion() { }

        public static void SetSingletonNumber(int number)
        {
            SetNumber = number;
        }

        //public static PriceSingletion GetInstance()
        //{
        //    listSingleton.Count > SetNumber
        //}

        private static Random random = new Random();
        private static PriceSingletion GetInstanceOne()
        {
            return listSingleton[random.Next(0, SetNumber)];
        }
    }







    //IoDH 饿汉式与懒汉式结合
    class IoDHSingleton
    {
        //私有构造函数
        private IoDHSingleton() { }
        //静态类
        private static class HolderClass
        {
            public static readonly IoDHSingleton instance = new IoDHSingleton();
        }
        //公有方法，返回静态类的静态字段
        public static IoDHSingleton getInstance()
        {
            return HolderClass.instance;
        }
    }


    //饿汉式单例
    class EagerSingleton
    {
        private static readonly EagerSingleton instance = new EagerSingleton();
        private EagerSingleton() { }
        public static EagerSingleton getInstance()
        {
            return instance;
        }
    }

    //懒汉式单例
    class LazySingleton
    {
        private static LazySingleton instance = null;
        //同步锁
        private static object locker = new object();
        private LazySingleton() { }

        public static LazySingleton getInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new LazySingleton();
                    }
                }
            }
            return instance;
        }
    }



    class LoadBalancer
    {
        //私有静态成员变量，存储唯一实例
        private static LoadBalancer instance = null;
        //服务器集合
        private List<string> serverList = null;
        //私有构造函数
        private LoadBalancer()
        {
            serverList = new List<string>();
        }
        //公有静态成员方法，返回唯一实例
        public static LoadBalancer getLoadBalancer()
        {
            if (instance == null)
            {
                instance = new LoadBalancer();
            }
            return instance;
        }
        //增加服务器
        public void addServer(string server)
        {
            serverList.Add(server);
        }
        //删除服务器
        public void removeServer(string server)
        {
            serverList.Remove(server);
        }

        //使用Random随机获取服务器 
        private Random random = new Random();
        //获取服务器
        public string getServer()
        {
            int i = random.Next(0, serverList.Count);
            return serverList[i];
        }
    }
    public class TaskManager
    {
        //保存TaskManager的唯一实例，同时为了
        //让外界可以访问这个唯一实例
        private static TaskManager tm = null;
        public static int x = 0;
        //确保TaskManager实例的唯一性，需要禁止
        //类的外部直接使用new关键字创建对象，因此
        //将TaskManager构造函数的可见性改为Private
        private TaskManager() { }
        public void displayProcess() { }
        public void displayServices() { }
        //为了保证成员变量的封装性，将TaskManager类型
        //可见性设置为Private，通过公有静态方法创建实例
        public static TaskManager getInstance()
        {
            if (tm == null)
            {
                tm = new TaskManager();
                x++;
            }
            return tm;
        }

    }



    public class Singleton
    {
        //定义一个静态变量来保存类的实例
        private static Singleton uniqueInstance;
        public static int x = 0;
        private static object locker = new object();
        //定义私有构造函数，使外界不能创建该类的实例
        private Singleton() { }

        //定义公有方法提供一个全局访问点，同时你也可以定义公有属性提供全局访问点
        public static Singleton getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    if (uniqueInstance == null)
                    {
                        x++;
                        uniqueInstance = new Singleton();
                    }
                }
            }
            return uniqueInstance;
        }
    }
}
