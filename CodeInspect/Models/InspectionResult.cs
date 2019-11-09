using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace CodeInspect.Models
{
    public class InspectionResult
    {
        public bool IsOk => Items.All(x => x.IsOk);
        public IList<InspectionItem> Items { get; }
        public IEnumerable<InspectionItem> InValidItems => Items.Where(x => !x.IsOk);
        public IEnumerable<InspectionItem> ValidItems => Items.Where(x => x.IsOk);

        public InspectionResult()
        {
            Items = new List<InspectionItem>();
        }

        internal void AddResult(InspectionItem item)
        {
            Items.Add(item);
        }

        public void Merge(InspectionResult item)
        {
            foreach (var validItem in item.Items)
            {
                AddResult(validItem);
            }
        }

        public string GetErrorMessage()
        {
            StringBuilder sb = new StringBuilder("Wrong items:");
            foreach (var inspectionItem in InValidItems)
            {
                sb.AppendLine($"[{inspectionItem.Caller}] [Member:{inspectionItem.Member.Name}] {inspectionItem.Message}");
            }

            return sb.ToString();
        }
    }

    public class InspectionItem
    {
        public bool IsOk { get; }
        public MemberInfo Member { get; }
        public string Message { get; }
        public string Caller { get; }

        private InspectionItem(bool isOk, MemberInfo member, string message = null, string caller = null)
        {
            IsOk = isOk;
            Member = member;
            Message = message;
            Caller = caller;
        }

        public static InspectionItem Ok(MemberInfo member, [CallerFilePath] string caller = null)
        {
            return new InspectionItem(true, member, null, Path.GetFileNameWithoutExtension(caller));
        }

        public static InspectionItem Create(MemberInfo member, bool isOk, string message = null, [CallerFilePath]string caller = null)
        {
            return new InspectionItem(isOk, member, message, Path.GetFileNameWithoutExtension(caller));
        }
    }
}
