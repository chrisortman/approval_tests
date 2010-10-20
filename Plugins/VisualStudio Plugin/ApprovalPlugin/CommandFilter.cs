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
using System.Diagnostics;

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
                ApproveResult();
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
                if (line.GetText().Contains("Approve") && GetMethodInfoFromActiveDocument(dte).ReceivedFileExists())
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

        private void ApproveResult()
        {
            ApproveResult(GetMethodInfoFromActiveDocument(dte));
        }

        private static MethodInfo GetMethodInfoFromActiveDocument(_DTE dte)
        {
            dynamic selection = dte.ActiveDocument.Selection;
            TextPoint point = selection.ActivePoint();
            CodeElement clazz = dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElementFromPoint(point,
                                                                                                  vsCMElement.
                                                                                                      vsCMElementClass);
            CodeElement method = dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElementFromPoint(point,
                                                                                                   vsCMElement.
                                                                                                       vsCMElementFunction);
            string fullName = dte.ActiveDocument.FullName;
            string parentPath = new DirectoryInfo(fullName).Parent.FullName;
            var info = new MethodInfo(clazz.Name, method.Name, parentPath);
            return info;
        }

        private void ApproveResult(MethodInfo info)
        {
          if (File.Exists(info.GetApprovedFile()))
          {
            File.SetAttributes(info.GetApprovedFile(), File.GetAttributes(info.GetApprovedFile()) & ~FileAttributes.ReadOnly);
          }
            File.Replace(info.GetReceivedFile(), info.GetApprovedFile(), null, true);
        }
    }

    internal class MethodInfo
    {
        public readonly string clazz;
        public readonly string method;
        public readonly string path;
        public readonly string extension;

        private static readonly string[] extensions = new string[] { "txt", "png" };

        public MethodInfo(string @class, string method, string path)
        {
            this.clazz = @class;
            this.method = method;
            this.path = path;

            // We now need to work out the extension, so let probe
            foreach (string extension in extensions)
            {
                if (File.Exists(GetApprovedFile(extension)) || File.Exists(GetReceivedFile(extension)))
                {
                    this.extension = extension;
                    break;
                }
            }

            // If we didn't find one, we'll assume .txt
            if (this.extension == null)
            {
                this.extension = "txt";
            }
        }

        public bool ReceivedFileExists()
        {
            return File.Exists(GetReceivedFile());
        }

        public string GetReceivedFile()
        {
            Debug.Assert(this.extension != null);
            return GetReceivedFile(this.extension);
        }

        public string GetReceivedFile(string extension)
        {
            return GetFileName("received", extension);
        }

        public string GetApprovedFile()
        {
            Debug.Assert(this.extension != null);
            return GetApprovedFile(this.extension);
        }

        private string GetApprovedFile(string extension)
        {
            return GetFileName("approved", extension);
        }

        private string GetFileName(string state, string extension)
        {
            return string.Format("{0}\\{1}.{2}.{3}.{4}", path, clazz, method, state, extension);
        }
    }
}