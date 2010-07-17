using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;

namespace ApprovalTest.ApprovalPlugin
{
    [Export(typeof(ITaggerProvider))]
    [ContentType("CSharp")]
    [TagType(typeof(ITextMarkerTag))]
    class TaggerProvider:ITaggerProvider
    {
        public ITagger<T> CreateTagger<T>(Microsoft.VisualStudio.Text.ITextBuffer buffer) where T : ITag
        {
            var tagger = buffer.Properties.GetOrCreateSingletonProperty(() => new Tagger(buffer));
            return tagger as ITagger<T>;
        }
    }
}
