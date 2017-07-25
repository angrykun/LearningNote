## 第六章 C#中的接口 ##

电脑有拍照和播放VCD的功能，现在有一个`TakingPhoto`类，它提供拍照功能，`PlayVCD`类，它提供播放VCD功能。电脑同时具有这两个类提供的功能，定义`Computer`类，继承`TakingPhoto`和`PlayVCD`，**但是C#不支持多重继承类。**

为了解决这个问题，C#提出接口方式，来实现多重继承。

## 6.1 什么是接口 ##
接口是对一组方法声明进行的统一命名，但是这些方法没有提供任何的实现，把一组方法声明在一个接口中，然后继承该接口的类都需要实现接口中的方法。

## 6.2 如何使用接口编程 ##
C#中有面向对象编程，还有**面向接口的编程**。

### 6.2.1 接口的定义 ###
使用`interface`关键字定义一个接口，接口中所有成员默认都是`public`无法使用其它修饰符进行修饰。接口中定义的方法不能有任何的修饰符，因为接口中方法的默认修饰符为`public`。

    //接口
    public interface ICustomerCompare
    {
        //定义方法
        void CompareTo();
    }

接口中可以包含方法，属性，事件，索引器或者这4类成员类型的任意组合，但是接口中不能包含字段，运算符重载，实例构造函数，析构函数。

### 6.2.2 继承接口 ###

使用英文冒号":",即可实现继承。

    //Person类继承接口
    public class Person : ICustomerCompare
    {
        public int Age { get; set; }
        //实现接口中的方法
        public void CompareTo()
        {
           //方法体
        }
    }

### 6.2.3 调用接口中的方法 ###
实例化类，调用方法即可。

## 6.3 显示接口实现方式 ##
隐式接口实现方式：在代码中没有指定实现的是哪个接口中的方法。显示接口，它指的是在实现过程中，明确指出实现的是哪一个接口中的哪一个方法。

当多个接口包含相同方法名称，相同返回值类型，相同参数时，如果一个类同时实现了这些接口，隐式接口实现就会出现命名冲突。

	//中国人打招呼接口
    interface IChineseGreeting
    {
        void SayHello();
    }
    //美国人打招呼接口
    interface IAmericanGreeting
    {
        void SayHello();
    }
    public class Speaker : IChineseGreeting, IAmericanGreeting
    {
        public void SayHello()
        {
            Console.WriteLine("你好");
        }
    }

    //调用
    Speaker speaker = new Speaker();

    //调用中国人打招呼
    IChineseGreeting iChineseG = (IChineseGreeting)speaker;
    iChineseG.SayHello();
    //调用美国人打招呼
    IAmericanGreeting IAmercianG = (IAmericanGreeting)speaker;
    IAmercianG.SayHello();

不管调用哪个接口，程序显示的都是同一个实现方法。

    public class Speaker : IChineseGreeting, IAmericanGreeting
    {
        void IChineseGreeting.SayHello()
        {
            Console.WriteLine("你好");
        }

        void IAmericanGreeting.SayHello()
        {
            Console.WriteLine("hello");
        }
    }
使用显示调用接口，可以解决命名冲突问题。



- 显示实现接口，方法不能使用任何访问修饰符，显示实现的成员默认为私有的。
- 显示实现接口，默认是私有的，所以不能通过实例进行访问。

## 6.4 接口与抽象 ##

接口与抽象类区别

- 抽象类关键字`abstract`，接口关键字`interface`，它们都不可以被实例化。
- 抽象类中可以包含虚方法，非抽象方法和静态成员；接口中不能包含虚方法和任何静态成员，接口中方法不能有具体实现。
- 抽象类不能实现多继承，接口支持多继承。
- 抽象类是对一类对象的抽象，继承于抽象类的类与抽象类为属于的关系。而类实现接口是代表实现类具有接口中声明的方法。


## 6.5 面向对象编程应用 ##

创建一个Dog类

    public class Dog
    {
        public void Eat()
        {
            //eat some food 
        }
        public void Walk()
        {
            //walk
        }
    }
 

但是Dog类中的Eat和Walk方法可能被其他类用到，它们都是动物共同特性。使用面向对象思想，重构代码。

    //提取出基类
    public abstract class Animal
    {
        public void Eat()
        {
            //eat some food 
        }
        public void Walk()
        {
            //walk
        }
    }
	//继承基类
    public class Dog : Animal
    {

    }

以上代码实现了代码的重用，但是不能过度使用继承，否咋导致派生类的膨胀，导致增加维护管理成本。如果必须使用，可以考虑使用接口实现。

有经过训练的Dog具有特殊的表演能力，这该如何实现？

方案1：在基类中新增Show方法，然而这种设计会把Animal概念本身具有的行为方法和另外一个特殊概念“表演节目”行为混合在一起。并不是所有的Dog都具有表演行为方法。

方案2：Eat，Walk和Show 属于不同的概念，那么应该将它们放在不同的类中。定义方式有3中：两个抽象类；一个抽象类，一个接口类；两个接口类。
因为C#中不支持类多重继承，方式1不可行。方式3两个接口在程序角度是可以的，但是从现实角度考虑，Dog本身属于Animal，这并非接口表达的CAN-DO关系。

 使用方式2进行重构。



    //基类
    public abstract class Animal
    {
        public void Eat()
        {
            //eat some food 
        }
        public void Walk()
        {
            //walk
        }
    }

    //接口类 定义行为
    public interface IAnimalShow
    {
        void Show();
    }
    //普通Dog
    public class Dog : Animal
    {

    }
    //具有表演能力的Dog
    public class SpecialDog : Animal, IAnimalShow
    {
        public void Show()
        {

        }
    }