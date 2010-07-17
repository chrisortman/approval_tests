using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Text.Editor;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using EnvDTE;
namespace ApprovalTest.ApprovalPlugin
{
    [Export (typeof(IWpfTextViewCreationListener))]
    [ContentType("CSharp")]
    [TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
    class TextViewCreationListener :  IWpfTextViewCreationListener
    {
        [Import]
        private IVsEditorAdaptersFactoryService _factoryService;
        [Import]
        private SVsServiceProvider serviceProvider;
        public TextViewCreationListener()
        {

        }

        public void TextViewCreated(IWpfTextView textView)
        {
            var dt = (_DTE) serviceProvider.GetService(typeof(SDTE));
            
            var commandFilter = textView.Properties.GetOrCreateSingletonProperty(() => new CommandFilter(textView, _factoryService, dt));
        }
    }
}
