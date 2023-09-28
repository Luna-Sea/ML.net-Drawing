using System;
using System.Drawing;
//需要额外安装System.Drawing.Common包
using System.Drawing.Imaging;
class Program
    {
    static void Main()
        {
        // 创建一个位图，这个图要比实际坐标系面积大，否则坐标轴会被截断无法显示。
        using (Bitmap bitmap = new Bitmap(500, 500))
            {
            // 创建一个绘图对象
            using (Graphics g = Graphics.FromImage(bitmap))
                {
                // 设置绘图的颜色
                using (Pen pen = new Pen(Color.Red))
                    {
                    // 绘制x轴，长度400。y轴绘制是从上往下，留出400的y轴长度
                    g.DrawLine(pen, 0, 400, 400, 400);

                    // 绘制y轴，向上增长
                    g.DrawLine(pen, 0, 400, 0, 0);

                    // 定义一组点
                    Point[] points = new Point[]
                    {
                        new (50, 50),
                        new (100, 100),
                        new (150, 50),
                        new (200, 150),
                        // 添加更多点...
                    };
                    // 绘制每个点，仅绘制第一象限的部分
                    foreach (Point point in points)
                        {
                            // 将点坐标映射到绘图区域
                            int x = point.X;
                            int y = 400 - point.Y;
                        //图像绘制是从左上角往右下角绘制。
                        //所以真实x轴与【显示x轴】相同，但真实y轴与【显示y轴】相反，
                        //所以此处要用长度400减去真实y轴坐标

                        // 绘制椭圆，以实际坐标绘制一个半径大小为2的圆
                        g.DrawEllipse(pen, x - 2, y - 2, 4, 4);
                        }
                    }
                }
            // 保存绘制的图像
            bitmap.Save(@"G:\VSstudio2022项目\C#项目\绘图\绘图\output.png", ImageFormat.Png);
            }
        }
    }
