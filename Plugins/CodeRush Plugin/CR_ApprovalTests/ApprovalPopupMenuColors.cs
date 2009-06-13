using System.Drawing;
using DevExpress.CodeRush.Core;

namespace CR_ApprovalTests
{
	public class ApprovalPopupMenuColors : SmartTagPopupMenuColors
	{
		public override Color BackgroundColor
		{
			get { return Color.FromArgb(249, 249, 247); }
		}

		public override Color TextColor
		{
			get { return Color.FromArgb(84, 123, 60); }
		}

		public override Color SelectedTextColor
		{
			get { return Color.FromArgb(255, 255, 255); }
		}

		public override Color SelectedBorderColor
		{
			get { return Color.FromArgb(84, 123, 60); }
		}

		public override Color SelectedBackgroundColor
		{
			get { return Color.FromArgb(140, 191, 112); }
		}

		public override Color BorderLeftOuterColor
		{
			get { return Color.FromArgb(209, 245, 201); }
		}

		public override Color BorderLeftInnerColor
		{
			get { return Color.FromArgb(213, 240, 197); }
		}

		public override Color BorderRightOuterColor
		{
			get { return Color.FromArgb(189, 229, 156); }
		}

		public override Color BorderRightInnerColor
		{
			get { return Color.FromArgb(198, 237, 184); }
		}

		public override Color BorderTopColor
		{
			get { return Color.FromArgb(187, 234, 162); }
		}

		public override Color BorderBottomColor
		{
			get { return Color.FromArgb(187, 234, 162); }
		}

		public override Color TitleTextColor
		{
			get { return Color.FromArgb(173, 206, 163); }
		}

		public override Color TitleActiveTextColor
		{
			get { return Color.FromArgb(150, 191, 133); }
		}

		public override Color TitleBackgroundColor
		{
			get { return Color.FromArgb(243, 255, 233); }
		}

		public override Color TitleActiveBackgroundColor
		{
			get { return Color.FromArgb(248, 254, 240); }
		}
	}
}