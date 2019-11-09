using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace CodeInspect.Models
{
    public class InspectionResult
    {
        public bool IsOk => InValidItems.Count == 0;
        public IList<InspectionItem> ValidItems { get; }
        public IList<InspectionItem> InValidItems { get; }

        public InspectionResult()
        {
            ValidItems = new List<InspectionItem>();
            InValidItems = new List<InspectionItem>();
        }

        internal void AddResult(InspectionItem item)
        {
            if (item.IsOk)
            {
                ValidItems.Add(item);
            }
            else
            {
                InValidItems.Add(item);
            }
        }

        public void Merge(InspectionResult item)
        {
            foreach (var validItem in item.ValidItems)
            {
                AddResult(validItem);
            }

            foreach (var inValidItem in item.InValidItems)
            {
                AddResult(inValidItem);
            }
        }

        public string GetErrorMessage()
        {
            StringBuilder sb = new StringBuilder("Wrong items:");
            foreach (var inspectionItem in InValidItems)
            {
                sb.AppendLine($"[{inspectionItem.Caller}] {inspectionItem.Message}");
            }

            return sb.ToString();
        }
    }

    public class InspectionItem
    {
        public bool IsOk { get; }
        public string Message { get; }
        public string Caller { get; }

        private InspectionItem(bool isOk, string message = null, string caller = null)
        {
            IsOk = isOk;
            Message = message;
            Caller = caller;
        }

        public static InspectionItem Ok = new InspectionItem(true);

        public static InspectionItem Create(bool isOk, string message = null, [CallerFilePath]string caller = null)
        {
            if (isOk && string.IsNullOrEmpty(message))
            {
                return Ok;
            }
            return new InspectionItem(isOk, message, Path.GetFileNameWithoutExtension(caller));
        }
    }
}
