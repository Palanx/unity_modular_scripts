using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace Die4Games.ModularScript
{
    public static class Utility
    {
        public class GenericOperator<T>
        {
            // Params operator
            private ParameterExpression paramA, paramB;

            // Add func
            private BinaryExpression bodyAdd;
            private Func<T, T, T> addFunc;

            // Div func
            private BinaryExpression bodyDiv;
            private Func<T, T, T> divFunc;

            // Mult func
            private BinaryExpression bodyMult;
            private Func<T, T, T> multFunc;

            public GenericOperator()
            {
                paramA = Expression.Parameter(typeof(T), "a");
                paramB = Expression.Parameter(typeof(T), "b");

                bodyAdd = Expression.Add(paramA, paramB);
                addFunc = Expression.Lambda<Func<T, T, T>>(bodyAdd, paramA, paramB).Compile();

                bodyDiv = Expression.Divide(paramA, paramB);
                divFunc = Expression.Lambda<Func<T, T, T>>(bodyDiv, paramA, paramB).Compile();

                bodyMult = Expression.Multiply(paramA, paramB);
                multFunc = Expression.Lambda<Func<T, T, T>>(bodyMult, paramA, paramB).Compile();
            }

            /// <summary>
            /// Generic Addition.
            /// Source: https://jonskeet.uk/csharp/genericoperators.html
            /// </summary>
            /// <typeparam name="T">Operators type</typeparam>
            /// <param name="a">Left operator</param>
            /// <param name="b">Right operator</param>
            /// <returns></returns>
            public T Add(T a, T b)
            {
                return addFunc(a, b);
            }

            /// <summary>
            /// Generic divition.
            /// Source: https://jonskeet.uk/csharp/genericoperators.html
            /// </summary>
            /// <typeparam name="T">Operators type</typeparam>
            /// <param name="a">Left operator</param>
            /// <param name="b">Right operator</param>
            /// <returns></returns>
            public T Divide(T a, T b)
            {
                return divFunc(a, b);
            }

            /// <summary>
            /// Generic multiplication.
            /// Source: https://jonskeet.uk/csharp/genericoperators.html
            /// </summary>
            /// <typeparam name="T">Operators type</typeparam>
            /// <param name="a">Left operator</param>
            /// <param name="b">Right operator</param>
            /// <returns></returns>
            public T Multiply(T a, T b)
            {
                return multFunc(a, b);
            }
        }
    }
}


