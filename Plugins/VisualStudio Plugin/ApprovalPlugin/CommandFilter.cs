using System;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using Process = System.Diagnostics.Process;

namespace ApprovalTest.ApprovalPlugin
{
    internal class CommandFilter : IOleCommandTarget
    {
        private readonly _DTE dte;
        private readonly IVsEditorAdaptersFactoryService factoryService;
        private readonly IWpfTextView textView;
        private IOleCommandTarget next;

        public CommandFilter(IWpfTextView textView, IVsEditorAdaptersFactoryService factoryService, _DTE dt)
        {
            this.textView = textView;
            this.factoryService = factoryService;
            dte = dt;
            textView.GotAggregateFocus += textView_GotAggregateFocus;
        }

        #region IOleCommandTarget Members

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            if (pguidCmdGroup == GuidList.guidApprovalPluginCmdSet && nCmdID == 0x0100)
            {
                DoStuff();
                return VSConstants.S_OK;
            }
            return next.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            if (pguidCmdGroup == GuidList.guidApprovalPluginCmdSet && prgCmds[0].cmdID == 0x0100)
            {
                ITextSnapshotLine line =
                    textView.TextBuffer.CurrentSnapshot.GetLineFromPosition(
                        textView.Caret.Position.BufferPosition.Position);
                if (line.GetText().Contains("Approve"))
                {
                    prgCmds[0].cmdf = (uint) (OLECMDF.OLECMDF_ENABLED | OLECMDF.OLECMDF_SUPPORTED);
                }

                return VSConstants.S_OK;
            }
            return next.QueryStatus(pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        #endregion

        private void textView_GotAggregateFocus(object sender, EventArgs e)
        {
            IVsTextView vsText = factoryService.GetViewAdapter(textView);
            vsText.AddCommandFilter(this, out next);
            textView.GotAggregateFocus -= textView_GotAggregateFocus;
        }

        private void DoStuff()
        {
            dynamic selection = dte.ActiveDocument.Selection;
            TextPoint point = selection.ActivePoint();
            CodeElement clazz = dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElementFromPoint(point,
                                                                                                  vsCMElement.
                                                                                                      vsCMElementClass);
            CodeElement method = dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElementFromPoint(point,
                                                                                                   vsCMElement.
                                                                                                       vsCMElementFunction);
            string contents = dte.ActiveDocument.FullName + "\r\n" + clazz.Name + "\r\n" + method.Name;
            File.WriteAllText("D:\\out.txt", contents);
            Process.Start("d:\\out.txt");
        }
    }
}