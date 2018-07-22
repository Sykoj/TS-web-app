using System.Drawing;
using Ts.App.TableauViews.Layout;

namespace Ts.App.TableauViews.SvgView {

    public abstract class SvgView : ILayoutable {

        public virtual uint Width { get; set; }
        public virtual uint Height { get; set; }
        public SvgView ChildView { get; set; }
        public (int X, int Y) Position { get; set; } = (0, 0);

        public abstract string ToSvg();
        public abstract string GetStyles();
    }

    public class FormulaTextSvg : SvgView {
        
        public string Text { get; private set; }
        private readonly uint _fontSize;

        public FormulaTextSvg(uint fontSize) {
            _fontSize = 14;
        }

        public void SetTextAndComputeSizes(string text) {

            Text = text;
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var font = new Font(FontFamily.GenericMonospace, _fontSize, FontStyle.Regular);
            var width = graphics.MeasureString(text, font).Width;
            var height = graphics.MeasureString(text, font).Height;

            Width = (uint) width;
            Height = (uint) height;
        }

        public override string ToSvg() {
            return $@"
                    <text x=""{Position.X}"" y=""{Position.Y + Height}"" class=""formula"" textLength=""{Width}"" >
                    {Text}
                    </text>
                   ";
        }

        public override string GetStyles() {
            return 
                $@"
                <style>
                    .formula {{
                        font-family: monospace, monospace;
	                    font-size: {_fontSize}px;
	                    font-style: regular;
                        }}
                </style>
                ";
        }
    }
}
