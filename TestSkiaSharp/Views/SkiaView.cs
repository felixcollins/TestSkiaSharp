using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestSkiaSharp.Views
{
    public class SkiaView : SKGLView
    {
        readonly SKPaint _circlePaint;

        public SkiaView()
        {
            Console.WriteLine("Constructing SkiaView");
            _circlePaint = new SKPaint();
            _circlePaint.Style = SKPaintStyle.StrokeAndFill;
            _circlePaint.Color = SKColors.PaleGreen;
            _circlePaint.IsAntialias = true;
        }

        public static readonly BindableProperty TestColorProperty =
        BindableProperty.Create(
         propertyName: nameof(TestColor),
         returnType: typeof(Color),
         declaringType: typeof(SkiaView),
         defaultValue: null,
         defaultBindingMode: BindingMode.TwoWay,
         propertyChanged: (bindable, oldValue, newValue) =>
         {
             Console.WriteLine($"Color prop changed {newValue.ToString()}");
             ((SkiaView)bindable).TestColor = (Color)newValue;
         }
        );

        Color _testColor;

        public Color TestColor
        {
            get
            {
                return _testColor;
            }
            set
            {
                _testColor = value;
                InvalidateSurface();
            }
        }


        protected override void OnPaintSurface(SKPaintGLSurfaceEventArgs e)
        {
            Console.WriteLine("Painting SkiaView");
            base.OnPaintSurface(e);
            var canvas = e.Surface.Canvas;
            canvas.DrawColor(TestColor.ToSKColor());
            canvas.DrawCircle(1,1,20,_circlePaint);
        }

    }
}
