## 第十四章 Lambda表达式 ##

### 14.1 Lambda表达式简介 ###

Lambda表达式可以理解为一个匿名方法，它可以包含表达式和语句，**并且用于创建委托或转换为表达式树**。在使用Lambda表达式时，都会使用"=>"运算符(读作：goes to)，该运算符的左边是匿名方法的输入参数，右边是表达式或语句块。

#### 14.1.1 Lambda表达式的演变过程 ####


    static void Main(string[] args)
    {
        //Lambda表达式的演变过程

        //C#1.0 中创建委托的实例代码
        Func<string, int> delegatetest1 = new Func<string, int>(CallbackMethod);

        //C#2.0中使用匿名委托，此时就不需要定义回调方法
        Func<string, int> delegatetest2 = delegate (string text)
        {
            return text.Length;
        };

        //C# 3.0中使用lambda表达式创建委托实例
        Func<string, int> delegatetest3 = (string text) => text.Length;

        //可以省略参数类型 string
        Func<string, int> delegatetest4 = (text) => text.Length;

        //此时可以把圆括号省略
        Func<string, int> delegatetest5 = text => text.Length;

        //调用
        delegatetest5("调用此委托");
       
    }
    static int CallbackMethod(string text)
    {
        return text.Length;
    }


#### 14.1.2 Lambda表达式的使用 ####

	//C# 3.0之前代码
    static void Main(string[] args)
    {
        Button button1 = new Button();
        button1.Text = "点我";
        //C# 2.0中使用匿名方法来订阅事件
        button1.Click += delegate (object sender, EventArgs e)
        {
            ReportEvent("Click事件", sender, e);
        };

        button1.KeyPress += delegate (object sender, KeyPressEventArgs e)
        {
            ReportEvent("KeyPress事件", sender, e);
        };

        //C#3.0之前初始化对象使用代码
        Form form = new Form();
        form.Name = "在控制台中创建窗体";
        form.AutoSize = true;
        form.Controls.Add(button1);
        Application.Run(form);

    }
    static void ReportEvent(string title, object sender, EventArgs e)
    {
        Console.WriteLine("发生的事件为：{0}", title);
        Console.WriteLine("发生事件的对象为：{0}", sender);
        Console.WriteLine("发生事件参数为：{0}", e.GetType());
        Console.WriteLine();
        Console.WriteLine();
    }

	//C# 3.0代码
    static void Main(string[] args)
    {
        Button button1 = new Button();
        button1.Text = "点我";
        //C# 3.0中使用Lambda表达式来订阅事件
        button1.Click += (sender, e) =>
        {
            ReportEvent("Click事件", sender, e);
        };

        button1.KeyPress += (sender, e) =>
       {
           ReportEvent("KeyPress事件", sender, e);
       };

        //C#3.0 初始化对象使用代码
        Form form = new Form { Name = "在控制台中创建窗体", AutoSize = true };

        form.Controls.Add(button1);
        Application.Run(form);

    }
    static void ReportEvent(string title, object sender, EventArgs e)
    {
        Console.WriteLine("发生的事件为：{0}", title);
        Console.WriteLine("发生事件的对象为：{0}", sender);
        Console.WriteLine("发生事件参数为：{0}", e.GetType());
        Console.WriteLine();
        Console.WriteLine();
    }

### 14.2 Lambda表达式树 ###

Lambda表达式处理可以用来创建委托外，还可以转换成表达式树，表达式树(或称表达式目录树)是用来表示Lambda表达式逻辑的一种数据结构，它将代码表示成一个对象树，而非可执行代码。

#### 14.2.1 动态地构造一个表达式树 ####

构造表达式树要引入`using System.Linq.Expressions`类命名空间。



    //构造"a+b"的表达式树结构
    static void Main(string[] args)
    {
        //表达式的参数
        ParameterExpression a = Expression.Parameter(typeof(int), "a");
        ParameterExpression b = Expression.Parameter(typeof(int), "b");

        //表达式树的主体部分
        BinaryExpression be = Expression.Add(a, b);

        //构造表达式树
        Expression<Func<int, int, int>> expressionTree = Expression.Lambda<Func<int, int, int>>(be, a, b);

        //分析树结构，获取表达式主体部分
        BinaryExpression body = (BinaryExpression)expressionTree.Body;

        //左节点
        ParameterExpression left = (ParameterExpression)body.Left;

        //右节点
        ParameterExpression right = (ParameterExpression)body.Right;

        Console.WriteLine("表达式树结构为：" + expressionTree);

        Console.WriteLine("表达式树主体："+expressionTree.Body);

        Console.WriteLine("表达式树左节点为：{0}{4} 节点类型为：{1}{4} 表达式右节点为：{2}{4} 节点类型为：{3}{4}",left.Name,left.Type,right.Name,right.Type,Environment.NewLine);
        Console.ReadKey();
    }

上述代码**动态构造**表达式树结构可以用下图更形象表示。

![a+b表达式树](http://i.imgur.com/4E2q5ES.png)



#### 14.2.2 通过Lambda表达式来构造表达式树 ####

 	 //构造"a+b"的表达式树结构
    static void Main(string[] args)
    {
        //将Lambda表达式构造成表达式树
        Expression<Func<int, int, int>> expressionTree = (a, b) => a + b;

        //分析树结构，获取表达式主体部分
        BinaryExpression body = (BinaryExpression)expressionTree.Body;

        //左节点
        ParameterExpression left = (ParameterExpression)body.Left;

        //右节点
        ParameterExpression right = (ParameterExpression)body.Right;

        Console.WriteLine("表达式树结构为：" + expressionTree);

        Console.WriteLine("表达式树主体：" + expressionTree.Body);

        Console.WriteLine("表达式树左节点为：{0}{4} 节点类型为：{1}{4} 表达式右节点为：{2}{4} 节点类型为：{3}{4}", left.Name, left.Type, right.Name, right.Type, Environment.NewLine);
        Console.ReadKey();
    }

构造完一个表达式树后，由于表达式对象并不是可执行代码，它只是一个树形数据结构，所以需要在代码中再去解析树的结果，分别获得参数的左节点和右节点，然后输出。

#### 14.2.3 如何把表达式树转换成可执行代码 ####

    static void Main(string[] args)
    {
        //将Lambda表达式构造成表达式树
        Expression<Func<int, int, int>> expressionTree = (a, b) => a + b;

        //通过调用Compile方法来生成Lambda表达式的委托
        Func<int, int, int> delinstance = expressionTree.Compile();

        //调用委托实例获取结果
        int result = delinstance(2, 3);
        Console.WriteLine("2+3=" + result);
        Console.ReadKey();
    }

**以上代码通过Expression<TDelegate>**类的Complie()方法将表达式树编译成委托实例，然后通过委托调用的方式得到这两个数的和。

