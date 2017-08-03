using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test.DesignPattern.FactoryAbstract
{
    #region 抽象工厂

    //按钮接口：抽象产品
    interface Button
    {
        void display();
    }
    class SpringButton : Button
    {
        public void display()
        {
            Console.WriteLine("显示绿色按钮");
        }
    }
    class SummerButton : Button
    {
        public void display()
        {
            Console.WriteLine("显示蓝色按钮");
        }
    }

    //文本框接口:抽象产品
    interface TextField
    {
        void display();
    }

    class SpringTextField : TextField
    {
        public void display()
        {
            Console.WriteLine("显示绿色文本框");
        }
    }

    class SummerTextField : TextField
    {
        public void display()
        {
            Console.WriteLine("显示蓝色文本框");
        }
    }

    //组合框
    interface ComboBox
    {
        void display();
    }
    class SpringCombox : ComboBox
    {
        public void display()
        {
            Console.WriteLine("显示绿色组合框");
        }
    }
    class SummerCombox : ComboBox
    {
        public void display()
        {
            Console.WriteLine("显示蓝色组合框");
        }
    }

    //界面皮肤工厂接口：抽象工厂
    interface SkinFactory
    {
        Button createButton();
        TextField createTextField();
        ComboBox createComboBox();
    }
    //Sping 皮肤工厂：具体工厂
    class SpringSkinFactory : SkinFactory
    {
        public Button createButton()
        {
            return new SpringButton();
        }
        public TextField createTextField()
        {
            return new SpringTextField();
        }
        public ComboBox createComboBox()
        {
            return new SpringCombox();
        }
    }

    //Summer 皮肤工厂：具体工厂
    class SummerSkinFactory : SkinFactory
    {
        public Button createButton()
        {
            return new SummerButton();
        }
        public TextField createTextField()
        {
            return new SummerTextField();
        }
        public ComboBox createComboBox()
        {
            return new SummerCombox();
        }
    }
    #endregion


    #region 抽象工厂练习
    //游戏控制类
    abstract class OperationController
    {
        public abstract void operation();
    }

    class SymbianOperation : OperationController
    {
        public override void operation()
        {
            Console.WriteLine("Symbian 手机操控游戏");
        }
    }
    class AndroidOperation : OperationController
    {
        public override void operation()
        {
            Console.WriteLine("Android 手机操控游戏");
        }
    }
    class WinPhoneOperation : OperationController
    {
        public override void operation()
        {
            Console.WriteLine("WinPhone 手机操控游戏");
        }
    }
    //扩展 新增
    class IOSOperation : OperationController
    {
        public override void operation()
        {
            Console.WriteLine("IOS 手机操控游戏");
        }
    }

    //游戏界面类
    abstract class InterfaceController
    {
        public abstract void interfaceUI();
    }

    class SymbianInterface : InterfaceController
    {
        public override void interfaceUI()
        {
            Console.WriteLine("Symbian 手机显示游戏界面");
        }
    }

    class AndroidInterface : InterfaceController
    {
        public override void interfaceUI()
        {
            Console.WriteLine("Android 手机显示游戏界面");
        }
    }

    class WinPhoneInterface : InterfaceController
    {
        public override void interfaceUI()
        {
            Console.WriteLine("WinPhone 手机显示游戏界面");
        }
    }
    //扩展 新增
    class IOSInterface : InterfaceController
    {
        public override void interfaceUI()
        {
            Console.WriteLine("IOS 手机显示游戏界面");
        }
    }

    //抽象工厂
    abstract class GameFactory
    {
        public abstract OperationController createOperation();
        public abstract InterfaceController createInterfaceUI();
    }
    //具体工厂
    class SymbainGameFactory : GameFactory
    {
        public override OperationController createOperation()
        {
            return new SymbianOperation();
        }
        public override InterfaceController createInterfaceUI()
        {
            return new SymbianInterface();
        }
    }

    class AndroidGameFactory : GameFactory
    {
        public override OperationController createOperation()
        {
            return new AndroidOperation();
        }
        public override InterfaceController createInterfaceUI()
        {
            return new AndroidInterface();
        }
    }
    class WinPhoneGameFactory : GameFactory
    {

        public override OperationController createOperation()
        {
            return new WinPhoneOperation();
        }
        public override InterfaceController createInterfaceUI()
        {
            return new WinPhoneInterface();
        }
    }
    //扩展 新增
    class IOSGameFactory : GameFactory
    {
        public override OperationController createOperation()
        {
            return new IOSOperation();
        }
        public override InterfaceController createInterfaceUI()
        {
            return new IOSInterface();
        }
    }

    #endregion

}
