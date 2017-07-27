## 第十六章 数据操作 LINQ ##

### 16.1 LINQ是什么 ###

LINQ是Language Integrated Query的缩写，即"语言集成查询"。LINQ的提出就是为了提供一种跨越各种数据源的统一的查询方式，它主要包括4个组件：Linq to Objects、Linq to XML、Linq to DataSet和Linq to Sql。

![LINQ组成](http://i.imgur.com/1KHsy2j.png)

LINQ4个组件：

- Linq to Sql组件：它可以查询基于关系数据库的数据。
- Linq to DataSet组件：它可以查询DataSet对象中的数据，并对数据进行增删改查等操作。
- Linq to XML组件：该组件可以查询XML文件。
- Linq  to Objects组件：这个组件可以查询集合数据，如数组或List等。

### 16.2 LINQ好在哪里 ###

Linq对这些数据源进行的操作变得简单。

#### 16.2.1 查询表达式 ####

查询表达式必须以from子句开头，并且必须以select 或group 子句结尾，在第一个from子句和最后一个select或group子句直接，可以包含一个或多个where子句，orderby，join子句。

 	 //查询表达式
    var queryExp = from s in collection
                   select c;
    //查询函数，点标记法
    queryExp = collection.Select(s=>s);

点标记法适合查询条件较少的情况，查询表达式则更加注重结构化思维方式。

#### 16.2.2 ####

在Linq之前，我们查询集合中的数据，需要使用for或foreach语句，但是这种方式没有Linq to Objects整洁。


    List<int> inputArray = new List<int>();
    for (int i = 0; i < 10; i++)
    {
        inputArray.Add(1);
    }

    //Linq之前查询集合中偶数   
    foreach (int item in inputArray)
    {
        if (item % 2 == 0)
        {
            Console.WriteLine(item);
        }
    }

    //Linq  
    var list = from item in inputArray
               where item % 2 == 0
               select item;


### 16.3 理解LINQ的本质 ###





MSDN中对Linq to Entities描述：
> 可以通过两种不同的语法编写LINQ to Entities查询：查询表达式语法和基于方法的查询语法。不过.Net Framework公共语言运行库(CLR)无法读取查询表达式语法本身。因此编译时，查询表达式将转换为CLR能理解的形式，即方法调用，这些方法称为 标准查询运算符