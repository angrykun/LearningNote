using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//原型模式
namespace Test.DesignPattern.Prototype
{
    #region 原型模式
    /**
     * 原型模式(Prototype Pattern):使用原型实例指定创建对象的种类，
     * 并且通过克隆这些原型创建新的对象。原型模式是一种创建型模式。
     * 
     * 通过克隆方法创建的对象是全新的对象，它们在内存中拥有新的地址；
     * 通常对克隆产生的对象进行的修改不会对原型对象造成任何影响，每一个
     * 克隆对象都是相互独立的；
    **/
    #endregion

    #region 孙悟空原型
    //抽象：孙悟空原型
    public abstract class MonkeyKingPrototype
    {
        public string Id { get; set; }
        public MonkeyKingPrototype(string id)
        {
            Id = id;
        }
        public abstract MonkeyKingPrototype Clone();
    }
    //创建具体原型
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id) : base(id)
        { }
        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        public override MonkeyKingPrototype Clone()
        {
            //调用MemberwiseClone方法实现浅拷贝
            return (MonkeyKingPrototype)MemberwiseClone();
        }

        #region 浅拷贝
        /*浅拷贝：在浅拷贝中，如果原型对象的成员变量是值类型，将复制一份给克隆对象；
         * 如果原型对象的成员变量是引用类型，则将引用对象的地址复制一份给克隆对象，
         * 也就是说原型对象和克隆对象的成员变量指向相同的内存地址。
         * 
         * 深拷贝：无论原型对象的成员变量是值类型还是引用类型，都将复制一份给克隆对象，
         * 将原型对象的所有引用对象也复制一份给克隆对象。(通过序列化实现)
         * 
         * **/
        #endregion
    }
    #endregion

    #region 原型管理器
    //抽象公文接口，也可定义为抽象类
    interface OfficialDocument
    {
        OfficialDocument clone();
        void display();
    }

    class FAR : OfficialDocument
    {
        public OfficialDocument clone()
        {
            OfficialDocument far = null;
            try
            {
                far = (OfficialDocument)MemberwiseClone();
            }
            catch (Exception e)
            {
                Console.WriteLine("不支持复制");
            }
            return far;
        }

        public void display()
        {
            Console.WriteLine("可行性分析报告");
        }
    }

    class SRS : OfficialDocument
    {
        public OfficialDocument clone()
        {
            OfficialDocument srs = null;
            try
            {
                srs = (OfficialDocument)MemberwiseClone();
            }
            catch (Exception e)
            {
                Console.WriteLine("不可复制");
            }
            return srs;
        }

        public void display()
        {
            Console.WriteLine("《软件需求规格说明书》");
        }
    }


    class PrototypeManager
    {
        //存储原型对象
        private Hashtable ht = new Hashtable();

        private static PrototypeManager pm = new PrototypeManager();

        //增加公文对象
        private PrototypeManager()
        {
            ht.Add("far", new FAR());
            ht.Add("srs", new SRS());
        }
        //通过浅克隆获取公文对象
        public OfficialDocument getOfficeDocument(string key)
        {
            return ((OfficialDocument)ht[key]).clone();
        }
        public void addOfficeDocument(string key, OfficialDocument doc)
        {
            ht.Add(key, doc);
        }
        public static PrototypeManager getPrototypeManager()
        {
            return pm;
        }
    }
    #endregion

}
