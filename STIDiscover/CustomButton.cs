using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace STIDiscover
{
    public class CustomButton : Button
    {
        private Color _leftColor = Color.MediumSeaGreen;
        private Color _rightColor = Color.Navy;
        private int _splitPosition = 50; // Default split position (in percentage of button width)

        // Add Image property to hold the button's image
        private Image _buttonImage;

        [Category("Appearance")]
        public Image ButtonImage
        {
            get { return _buttonImage; }
            set { _buttonImage = value; Invalidate(); }
        }

        // Add ImageAlign property to control image alignment
        private ContentAlignment _imageAlign = ContentAlignment.MiddleLeft;

        [Category("Appearance")]
        public ContentAlignment ImageAlign
        {
            get { return _imageAlign; }
            set { _imageAlign = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color LeftColor
        {
            get { return _leftColor; }
            set { _leftColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color RightColor
        {
            get { return _rightColor; }
            set { _rightColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int SplitPosition
        {
            get { return _splitPosition; }
            set
            {
                _splitPosition = Math.Max(0, Math.Min(100, value)); // Clamp between 0 and 100
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics g = pevent.Graphics;

            // Calculate the split point based on the button's width and the SplitPosition percentage
            int splitPoint = (this.Width * _splitPosition) / 100;

            // Draw the left part with LeftColor
            Rectangle leftRect = new Rectangle(0, 0, splitPoint, this.Height);
            using (SolidBrush leftBrush = new SolidBrush(_leftColor))
            {
                g.FillRectangle(leftBrush, leftRect);
            }

            // Draw the right part with RightColor
            Rectangle rightRect = new Rectangle(splitPoint, 0, this.Width - splitPoint, this.Height);
            using (SolidBrush rightBrush = new SolidBrush(_rightColor))
            {
                g.FillRectangle(rightBrush, rightRect);
            }

            // Handle text alignment based on the TextAlign property
            StringFormat sf = new StringFormat();

            switch (this.TextAlign)
            {
                case ContentAlignment.TopLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                default:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
            }

            // Draw text with the specified alignment
            g.DrawString(this.Text, this.Font, Brushes.Black, this.ClientRectangle, sf);

            // Draw the image with respect to ImageAlign
            if (_buttonImage != null)
            {
                Rectangle imgRect = GetImageRectangle(_buttonImage.Size);
                g.DrawImage(_buttonImage, imgRect);
            }
        }

        // Method to calculate the image rectangle based on ImageAlign
        private Rectangle GetImageRectangle(Size imageSize)
        {
            int x = 0, y = 0;
            switch (_imageAlign)
            {
                case ContentAlignment.TopLeft:
                    x = 0;
                    y = 0;
                    break;
                case ContentAlignment.TopCenter:
                    x = (this.Width - imageSize.Width) / 2;
                    y = 0;
                    break;
                case ContentAlignment.TopRight:
                    x = this.Width - imageSize.Width;
                    y = 0;
                    break;
                case ContentAlignment.MiddleLeft:
                    x = 0;
                    y = (this.Height - imageSize.Height) / 2;
                    break;
                case ContentAlignment.MiddleCenter:
                    x = (this.Width - imageSize.Width) / 2;
                    y = (this.Height - imageSize.Height) / 2;
                    break;
                case ContentAlignment.MiddleRight:
                    x = this.Width - imageSize.Width;
                    y = (this.Height - imageSize.Height) / 2;
                    break;
                case ContentAlignment.BottomLeft:
                    x = 0;
                    y = this.Height - imageSize.Height;
                    break;
                case ContentAlignment.BottomCenter:
                    x = (this.Width - imageSize.Width) / 2;
                    y = this.Height - imageSize.Height;
                    break;
                case ContentAlignment.BottomRight:
                    x = this.Width - imageSize.Width;
                    y = this.Height - imageSize.Height;
                    break;
            }
            return new Rectangle(x, y, imageSize.Width, imageSize.Height);
        }
    }
}