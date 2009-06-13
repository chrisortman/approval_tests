using System;
using System.Drawing;
using System.IO;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CR_ApprovalTests
{
	public partial class ApprovalTestsPlugin : StandardPlugIn
	{
		#region InitializePlugIn

		public override void InitializePlugIn()
		{
			base.InitializePlugIn();

			//
			// TODO: Add your initialization code here.
			//
		}

		#endregion

		#region FinalizePlugIn

		public override void FinalizePlugIn()
		{
			//
			// TODO: Add your finalization code here.
			//

			base.FinalizePlugIn();
		}

		#endregion
		private void ApprovalTestsPlugin_EditorPaintLanguageElement(EditorPaintLanguageElementEventArgs ea)
		{
			LanguageElement element = ea.LanguageElement;

			if (IsApproveCall(element) && element.ElementType == LanguageElementType.MethodCall)
			{
				var approvalFiles = new ApprovalArtifacts(element.GetMethod());
				Color lineColor = getColorForApproval(approvalFiles.TestStatus);

				SourceRange range = element.Range;
				ea.PaintArgs.DrawLine(range.Start.Line, range.Start.Offset, range.End.Offset - range.Start.Offset, lineColor, LineStyle.SolidUnderline);
			}
		}


		public static Color getColorForApproval(TestStatus status)
		{
			switch (status)
			{
				case TestStatus.NeverRun: return Color.LightBlue;
				case TestStatus.NeverApproved: return Color.Yellow;
				case TestStatus.Approved: return Color.Green;
				case TestStatus.Failed: return Color.Red;
			}

			return Color.White;
		}

		private bool ApprovalTestsProvider_CheckSmartTagAvailability(object sender, EventArgs ea)
		{
			return IsApproveCall(CodeRush.Source.Active);
		}

		private static bool IsApproveCall(LanguageElement element)
		{
			if (element.ElementType == LanguageElementType.MethodCall && element.Name == "Approve")
				return true;

			if (element.Parent != null)
				return IsApproveCall(element.Parent);

			return false;
		}

		private void ApprovalTestsProvider_GetSmartTagItems(object sender, GetSmartTagItemsEventArgs ea)
		{
			ConstructMenu(ea);
		}

		public void ConstructMenu(GetSmartTagItemsEventArgs ea)
		{
			var artifacts = new ApprovalArtifacts(CodeRush.Source.ActiveMethod);

			if (artifacts.HasReceivedFile())
			{
				var received = new SmartTagItem("Received File");
				received.AddItem(new OpenFileSmartTagItem("View", artifacts.Received));
				received.AddItem(new CopyPathSmartTagItem("Copy File Path", artifacts.Received));
				received.AddItem(new OpenInExplorerSmartTagItem("Show in Explorer", artifacts.Received));
				ea.Add(received);
			}

			var approved = new SmartTagItem("Approved File");
			approved.AddItem(new OpenFileSmartTagItem("View", artifacts.Approved));
			approved.AddItem(new CopyPathSmartTagItem("Copy File Path", artifacts.Approved));
			approved.AddItem(new OpenInExplorerSmartTagItem("Show in Explorer", artifacts.Approved));
			approved.AddItem(new SetApprovalSmartTagItem("Set Approval", artifacts.Approved));
			ea.Add(approved);

			if (artifacts.HasReceivedFile() && artifacts.HasApprovalFile())
				ea.Add(new DiffSmartTagItem("Diff", artifacts.Received, artifacts.Approved));
			
			if (artifacts.HasReceivedFile())
				ea.Add(new ApproveSmartTagItem("Approve", artifacts.Received, artifacts.Approved));
		}

		private void ApprovalTestsProvider_GetSmartTagItemColors(object sender, GetSmartTagItemColorsEventArgs ea)
		{
			ea.PopupMenuColors = new ApprovalPopupMenuColors();
		}
	}
}