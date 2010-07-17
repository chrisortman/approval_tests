using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;

namespace ApprovalTest.ApprovalPlugin
{
    internal class Tagger : ITagger<ITextMarkerTag>
    {
        private ITextBuffer buffer;

        public Tagger(ITextBuffer buffer)
        {
            this.buffer = buffer;
        }

        #region ITagger<ITextMarkerTag> Members

        public IEnumerable<ITagSpan<ITextMarkerTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            foreach (SnapshotSpan span in spans)
            {
                int start = span.Start.GetContainingLine().LineNumber;
                int end = span.End.GetContainingLine().LineNumber;
                for (int i = start; i <= end; i++)
                {
                    ITextSnapshotLine line = span.Snapshot.GetLineFromLineNumber(i);
                    if (line.GetText().Contains(".Approve"))
                    {
                        SnapshotSpan s = TrimWhiteSpace(line.Extent);
                        yield return new TagSpan<ITextMarkerTag>(s, new TextMarkerTag("red"));
                    }
                }
            }
        }


        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        #endregion

        private SnapshotSpan TrimWhiteSpace(SnapshotSpan snapshotSpan)
        {
            string text = snapshotSpan.GetText();
            int start = 0;
            int last = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (last == 0 && char.IsWhiteSpace(text[i]))
                {
                    start = i;
                }
                else if (!char.IsWhiteSpace(text[i]))
                {
                    last = i;
                }
            }
            return new SnapshotSpan(snapshotSpan.Snapshot, start + snapshotSpan.Start + 1, last - start);
        }
    }
}