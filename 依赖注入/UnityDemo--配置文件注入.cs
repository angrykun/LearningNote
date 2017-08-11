using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DependencyDemo.Aterth
{
    public interface IA { }
    public interface IB { }
    public interface IC { }
    public interface ID { }

    public class A : IA
    {
        public IB B { get; set; }

        //属性方式注入
        //如果需要使用到被依赖对象的某个属性，
        //在被依赖对象创建后(也就是在A对象创建后)，
        //IoC容器会自动初始化该属性
        [Dependency]
        public IC C { get; set; }

        public ID D { get; set; }

        public A(IB b)
        {
            //构造函数注入
            //IoC容器会智能选择和调用合适的构造函数以创建依赖的对象
            //如果被选择的构造函数具有相应的参数，IoC容器在调用构造函数之前
            //解析注册的依赖关系并自行获得相应参数对象
            
            B = b;
        }

        //方法注入
        // 如果被依赖的对象需要调用某个方法进行相应的初始化
        //在该对象创建后，IoC容器会自动调用该方法
        //在A对象被IoC容器创建时，会自动调用
        [InjectionMethod]
        public void Initialize(ID d)
        {
            D = d;
        }
    }

    public class B : IB { }
    public class C : IC { }
    public class D : ID { }
}

//配置文件

  <configSections>
        <!--操作配置文件节点，configSections节点必须作为configuration的第一个子节点-->
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, 
              Microsoft.Practices.Unity.Configuration" />
    </configSections>
    <!--unity节点-->
    <unity>
        <containers>
            <!--name容器的名称-->
            <container name="defaultContainer">
                <!--type：映射接口的命名空间加接口名，命名空间   mapTo:需要映射的具体实现类命名空间加类名，命名空间-->
                <register type="DependencyDemo.Aterth.IA,DependencyDemo" mapTo="DependencyDemo.Aterth.A,DependencyDemo"></register>
                <register type="DependencyDemo.Aterth.IB,DependencyDemo" mapTo="DependencyDemo.Aterth.B,DependencyDemo"></register>
                <register type="DependencyDemo.Aterth.IC,DependencyDemo" mapTo="DependencyDemo.Aterth.C,DependencyDemo"></register>
                <register type="DependencyDemo.Aterth.ID,DependencyDemo" mapTo="DependencyDemo.Aterth.D,DependencyDemo"></register>
            </container>
        </containers>
    </unity>
	
	
//调用
//需要引用的命名空间
//using Microsoft.Practices.Unity.Configuration;
//using System.Configuration;

IUnityContainer container = new UnityContainer();
//读取配置节点
UnityConfigurationSection configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
//注入点
configuration.Configure(container, "defaultContainer");
//解析注入对象
A a = container.Resolve<IA>() as A;
if (a != null)
{
    Console.WriteLine("a.B == null ? {0}", a.B == null ? "Yes" : "No");
    Console.WriteLine("a.C == null ? {0}", a.C == null ? "Yes" : "No");
    Console.WriteLine("a.D == null ? {0}", a.D == null ? "Yes" : "No");
}	
	

