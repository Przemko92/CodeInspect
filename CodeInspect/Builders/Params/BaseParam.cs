using System;
using System.Collections.Generic;
using System.Text;
using CodeInspect.Builders.Interfaces;
using CodeInspect.Models;

namespace CodeInspect.Builders.Params
{
    abstract class BaseParam<T> : IParam<T>
        where T : class
    {
        private readonly IInspectBuilder _context;
        protected bool? _areForbidden;
        protected INameParam _nameParam;
        protected ICollection<Type> _validAttributes = new List<Type>();
        protected ICollection<Type> _forbiddenAttributes = new List<Type>();

        public BaseParam(IInspectBuilder context)
        {
            _context = context;
            _nameParam = new NameParam();
            _validAttributes = new List<Type>();
            _forbiddenAttributes = new List<Type>();
        }

        public T AreForbidden()
        {
            _areForbidden = true;
            return this as T;
        }

        public T NameIsNotLongerThan(int length)
        {
            _nameParam.IsNotLongerThan(length);
            return this as T;
        }

        public T NameIsNotShorterThan(int length)
        {
            _nameParam.IsNotShorterThan(length);
            return this as T;
        }

        public T NameStartsWith(params string[] allowedTexts)
        {
            _nameParam.StartsWith(allowedTexts);
            return this as T;
        }

        public T NameStartsWithCapitalLetter()
        {
            _nameParam.StartsWithCapitalLetter();
            return this as T;
        }

        public T NameStartsWithLowerCase()
        {
            _nameParam.StartsWithLowerCase();
            return this as T;
        }

        public T NameNotStartsWith(params string[] notAllowedTexts)
        {
            _nameParam.NotStartsWith(notAllowedTexts);
            return this as T;
        }

        public T NameNotEndsWith(params string[] notAllowedTexts)
        {
            _nameParam.NotEndsWith(notAllowedTexts);
            return this as T;
        }

        public T NameEndsWith(params string[] notAllowedTexts)
        {
            _nameParam.EndsWith(notAllowedTexts);
            return this as T;
        }

        public T NameMatchRegex(params string[] regex)
        {
            _nameParam.MatchRegex(regex);
            return this as T;
        }

        public T HasAttribute<T1>() where T1 : Attribute
        {
            return HasAttributes(typeof(T1));
        }

        public T HasAttributes(params Type[] attributes)
        {
            foreach (var attribute in attributes)
            {
                if (!typeof(Attribute).IsAssignableFrom(attribute))
                {
                    throw new ArgumentException(nameof(attribute));
                }
                _validAttributes.Add(attribute);
            }
            return this as T;
        }

        public T ForbiddenAttributes<T1>() where T1 : Attribute
        {
            return ForbiddenAttributes(typeof(T1));
        }

        public T ForbiddenAttributes(params Type[] attributes)
        {
            foreach (var attribute in attributes)
            {
                if (!typeof(Attribute).IsAssignableFrom(attribute))
                {
                    throw new ArgumentException(nameof(attribute));
                }
                _forbiddenAttributes.Add(attribute);
            }
            return this as T;
        }

        public InspectionResult Test()
        {
            return _context.Test();
        }
    }
}
