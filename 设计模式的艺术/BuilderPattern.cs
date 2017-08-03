using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//建造者模式
namespace Test.DesignPattern.BuilderPattern
{
    /* 建造者模式是较为复杂的创建型模式，它将客户端与包含
     * 多个组成部分的复杂对象的创建过程分离，客户端无须知道
     * 复杂对象的内部组成部分与装配方式，只需要知道所需要
     * 的建造者类型即可。
     * 
     * 建造者模式(Builder Pattern)：将一个复杂对象的构建与它的表示分离，
     * 使得同样的构建过程可以创建不同的表示。建造者模式是一种对象创建型模式。
     * 
     * **/
    #region 游戏开发
    //Actor角色类:复杂产品
    class Actor
    {
        //角色类型
        public string Type;
        //性别
        public string Sex;
        //脸蛋
        public string Face;
        //服装
        public string Constume;
        //发型
        public string Hairstyle;
    }
    //角色建造器：抽象建造者
    abstract class ActorBuilder
    {
        protected Actor actor = new Actor();

        public abstract void buildType();
        public abstract void buildSex();
        public abstract void buildFace();
        public abstract void buildCostume();
        public abstract void buildHairstyle();
        //工厂方法，返回一个完整的游戏角色对象
        public Actor createActor()
        {
            return actor;
        }
        //钩子方法
        //更加精细地控制产品的创建过程
        public virtual bool isBareheaded()
        {
            return false;
        }
    }
    //具体建造者
    class HeroBuilder : ActorBuilder
    {
        public override void buildType()
        {
            actor.Type = "英雄";
        }
        public override void buildFace()
        {
            actor.Face = "英俊";
        }
        public override void buildCostume()
        {
            actor.Constume = "盔甲";
        }
        public override void buildHairstyle()
        {
            actor.Hairstyle = "飘逸";
        }
        public override void buildSex()
        {
            actor.Sex = "男";
        }
    }

    class AngleBuilder : ActorBuilder
    {

        public override void buildType()
        {
            actor.Type = "天使";
        }
        public override void buildFace()
        {
            actor.Face = "漂亮";
        }
        public override void buildCostume()
        {
            actor.Constume = "白裙";
        }
        public override void buildHairstyle()
        {
            actor.Hairstyle = "披肩长发";
        }
        public override void buildSex()
        {
            actor.Sex = "女";
        }
    }

    class DevilBuilder : ActorBuilder
    {
        public override void buildType()
        {
            actor.Type = "恶魔";
        }
        public override void buildFace()
        {
            actor.Face = "丑陋";
        }
        public override void buildCostume()
        {
            actor.Constume = "黑衣";
        }
        public override void buildHairstyle()
        {
            actor.Hairstyle = "光头";
        }
        public override void buildSex()
        {
            actor.Sex = "妖";
        }
        //重写虚方法
        public override bool isBareheaded()
        {
            return true;
        }
    }
    //游戏角色创建控制器:指挥者
    class ActorController
    {
        public Actor constructor(ActorBuilder ab)
        {
            Actor actor;
            ab.buildType();
            ab.buildSex();
            ab.buildFace();
            ab.buildCostume();
            if (!ab.isBareheaded())
            {
                ab.buildHairstyle();
            }
            actor = ab.createActor();
            return actor;
        }
    }

    #endregion


    #region  Director变化形式
    /// <summary>
    /// 这两种方式都简化了系统结构，但是加重了抽象建造者类的职责
    /// 如果construct()方法较为复杂，待构建产品组成部分较多，还是将
    /// construct() 方法单独封装在Director中，这样更符合单一职责原则。
    /// </summary>
    abstract class ActorBuilderOne
    {

        protected static Actor actor = new Actor();
        public abstract void buildType();
        public abstract void buildSex();
        public abstract void buildFace();
        public abstract void buildCostume();
        public abstract void buildHairstyle();
        /// <summary>
        /// 省略Director，直接在内部调用
        /// </summary>
        public static Actor constructor(ActorBuilder ab)
        {
            ab.buildType();
            ab.buildSex();
            ab.buildFace();
            ab.buildCostume();
            ab.buildHairstyle();
            return actor;
        }
    }

    abstract class ActorBuilderTwo
    {

        protected static Actor actor = new Actor();
        public abstract void buildType();
        public abstract void buildSex();
        public abstract void buildFace();
        public abstract void buildCostume();
        public abstract void buildHairstyle();

        /// <summary>
        /// 去掉construct()方法参数
        /// </summary>
        public Actor constructor()
        {
            buildType();
            buildSex();
            buildFace();
            buildCostume();
            buildHairstyle();
            return actor;
        }
    }
    #endregion

    #region BuilderPrice
    class VideoPalyer
    {
        /// <summary>
        /// 菜单
        /// </summary>
        public string Menu { get; set; }
        /// <summary>
        /// 播放列表
        /// </summary>
        public string PlayList { get; set; }
        /// <summary>
        /// 主窗口
        /// </summary>
        public string MainWindow { get; set; }
        /// <summary>
        /// 控制条
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// 收藏列表
        /// </summary>
        public string ColllectionList { get; set; }
    }

    //建造者
    abstract class VideoPlayerBuilder
    {
        private VideoPalyer videoPlayer = new VideoPalyer();
        public void DisplayMenu()
        {
            Console.WriteLine("显示菜单");
        }
        public void DisplayPlayList()
        {
            Console.WriteLine("显示播放列表");
        }
        public void DisplayMainWindow()
        {

            Console.WriteLine("显示主窗口");
        }
        public void DisplayController()
        {
            Console.WriteLine("显示控制条");
        }
        public void DisplayColllectionList()
        {
            Console.WriteLine("显示收藏列表");
        }

        public virtual bool isDisplayMenu()
        {
            return true;
        }
        public virtual bool isDisplayPlayList()
        {
            return true;
        }
        public virtual bool isDisplayController()
        {
            return true;
        }
        public virtual bool isDisplayColllectionList()
        {
            return true;
        }

        public VideoPalyer construct()
        {
            return videoPlayer;
        }
    }

    //完整模式
    class FullModel : VideoPlayerBuilder
    {
    }
    //精简模式
    class SimpleModel : VideoPlayerBuilder
    {
        public override bool isDisplayColllectionList()
        {
            return false;
        }
        public override bool isDisplayMenu()
        {
            return false;
        }
        public override bool isDisplayPlayList()
        {
            return false;
        }
    }

    class MerroryModel : VideoPlayerBuilder
    {
        public override bool isDisplayMenu()
        {
            return false;
        }
    }

    class VideoPlayerDirector
    {
        public VideoPalyer construct(VideoPlayerBuilder vp)
        {
            VideoPalyer videoPlayer = null;
            vp.DisplayMainWindow();
            if (vp.isDisplayMenu())
            {
                vp.DisplayMenu();
            }
            if (vp.isDisplayPlayList())
            {
                vp.DisplayPlayList();
            }
            if (vp.isDisplayController())
            {
                vp.DisplayController();
            }
            if (vp.isDisplayColllectionList())
            {
                vp.DisplayColllectionList();
            }
            videoPlayer = vp.construct();
            return videoPlayer;
        }
    }

    //------调用------
    //VideoPlayerBuilder videoPlayerBuilder = new FullModel();
    //VideoPlayerDirector videoPlayerDirector = new VideoPlayerDirector();

    //Console.WriteLine("完整模式\n----------------------------------------");
    //VideoPalyer videoPlayer = videoPlayerDirector.construct(videoPlayerBuilder);
    //Console.WriteLine("\n\n");

    //Console.WriteLine("精简模式\n----------------------------------------");
    //videoPlayerBuilder = new SimpleModel();
    //videoPlayer = videoPlayerDirector.construct(videoPlayerBuilder);
    //Console.WriteLine("\n\n");

    //Console.WriteLine("记忆模式\n----------------------------------------");
    //videoPlayerBuilder = new MerroryModel();
    //videoPlayer = videoPlayerDirector.construct(videoPlayerBuilder);  

    #endregion




    /*
     * 建造者的核心在于如何一步一步构建一个包含多个组成部件的完成对象，
     * 使用相同的构建过程构建不同产品。
     * 
     * 优点：
     * 1)在建造者模式中，客户端不必知道产品内部组成细节，将产品本身与产品的创建过程解耦，
     * 使得相同的创建过程可以创建不同的产品对象。
     * 2)每一个具体建造者都相对独立，而与其他具体建造者无关。因此可以很方便替换具体建造者或
     * 增加新的具体建造者，用户使用不同的具体建造者即可得到不同的产品对象。由于指挥类针对抽象
     * 建造者编程，增加新的具体建造者无需修改原有类库代码，系统扩展方法，符合开闭原则。
     * 3)可以更加精细地控制产品的创建过程。奖复杂产品的创建步骤分解在不同的方法中，使得创建过程
     * 更加清晰，也更方便使用程序来控制过程。
     * 
     * 缺点：
     * 1) 建造者模式所创建的产品一般具有较多的共同点，其组成部分相似，如果产品之间的差异性很大，
     * 例如很多组成部分不相同，就不适合使用建造者模式，因此使用范围受到一定限制。
     * 2) 如果产品的内部结构复杂多变，可能会需要定义很多具体建造者类来实现这种变化，导致系统变得很庞大
     * 增加系统的理解难度和运行成本。
     *  
     *  使用场景：
     *  1) 需要生产的产品对象有复杂的内部结构，这些产品对象通常包含多个成员变量
     *  2) 需要生产的产品对象的属性相互依赖，需要指定生成顺序
     *  3) 对象的创建过程独立于创建该对象的类。在建造者模式中，通过引入指挥者类，
     *  创建过程封装在指挥者类中，而不再建造者类和客户类中。
     *  4) 隔离复杂对象的创建和使用，并使得相同的创建过程可以创建不同的产品。
     * **/
}
