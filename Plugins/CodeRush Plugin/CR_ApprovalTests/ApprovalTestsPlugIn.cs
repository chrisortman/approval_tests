using System.Drawing;
using CR_ApprovalTests.CodeProviders;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CR_ApprovalTests
{
	public partial class ApprovalTestsPlugIn : StandardPlugIn
	{
		public ApprovalToolsSettings Settings { get; set; }

		public override void InitializePlugIn()
		{
			base.InitializePlugIn();

			DecoupledStorage storage = Options.Storage;
			Settings = ApprovalToolsSettings.LoadFrom(storage);
		}

		private void PlugIn1_EditorPaintLanguageElement(EditorPaintLanguageElementEventArgs ea)
		{
			LanguageElement element = ea.LanguageElement;

			if (IsApproveCall(element) && element.ElementType == LanguageElementType.MethodCall)
			{
				var approvalFiles = new ApprovalArtifacts(element, CodeRush.Documents.ActiveTextDocument.FullName);
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

		private static bool IsApproveCall(LanguageElement element)
		{
			if (element.ElementType == LanguageElementType.MethodCall && element.Name == "Approve")
				return true;

			if (element.Parent != null)
				return IsApproveCall(element.Parent);

			return false;
		}

		private void codeProviderApprovals_CheckAvailability(object sender, CheckContentAvailabilityEventArgs ea)
		{
			if (!IsApproveCall(ea.Element))
				return;

			LanguageElement element = CodeRush.Documents.ActiveTextDocument.FileNode.GetNodeAt(CodeRush.Caret.SourcePoint);

			var files = new ApprovalArtifacts(element, CodeRush.Documents.ActiveTextDocument.FullName);
			if (files.HasReceivedFile)
			{
				ea.AddSubMenuItem("Approve").SetProvider(new ApproveProvider(Settings.UnitTestCommand, files));
				if (files.HasApprovedFile)
					ea.AddSubMenuItem("Diff").SetProvider(new DiffProvider(Settings.DiffTextTool, Settings.DiffTextToolArgs, Settings.DiffImageTool, Settings.DiffImageToolArgs));
				ea.AddSubMenuItem("View Received").SetProvider(new ViewReceivedProvider());
			}

			if (files.HasApprovedFile)
				ea.AddSubMenuItem("View Approved").SetProvider(new ViewApprovedProvider());

			ea.Available = true;
		}
	}

}