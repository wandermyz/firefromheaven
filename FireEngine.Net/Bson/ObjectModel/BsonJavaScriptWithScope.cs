﻿/* Copyright 2010-2011 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Bson {
    /// <summary>
    /// Represents a BSON JavaScript value with a scope.
    /// </summary>
    [Serializable]
    public class BsonJavaScriptWithScope : BsonJavaScript, IComparable<BsonJavaScriptWithScope>, IEquatable<BsonJavaScriptWithScope> {
        #region private fields
        private BsonDocument scope;
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the BsonJavaScriptWithScope class.
        /// </summary>
        /// <param name="code">The JavaScript code.</param>
        /// <param name="scope">A scope (a set of variables with values).</param>
        public BsonJavaScriptWithScope(
            string code,
            BsonDocument scope
        )  
            : base(code, BsonType.JavaScriptWithScope) {
            this.scope = scope;
        }
        #endregion

        #region public properties
        /// <summary>
        /// Gets the scope (a set of variables with values).
        /// </summary>
        public BsonDocument Scope {
            get { return scope; }
        }
        #endregion

        #region public static methods
        /// <summary>
        /// Creates a new BsonJavaScriptWithScope.
        /// </summary>
        /// <param name="value">An object to be mapped to a BsonJavaScriptWithScope.</param>
        /// <returns>A BsonJavaScriptWithScope or null.</returns>
        public new static BsonJavaScriptWithScope Create(
            object value
        ) {
            if (value != null) {
                return (BsonJavaScriptWithScope) BsonTypeMapper.MapToBsonValue(value, BsonType.JavaScriptWithScope);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Creates a new instance of the BsonJavaScript class.
        /// </summary>
        /// <param name="code">A string containing JavaScript code.</param>
        /// <param name="scope">A scope (a set of variable with values).</param>
        /// <returns>A BsonJavaScript.</returns>
        public static BsonJavaScriptWithScope Create(
            string code,
            BsonDocument scope
        ) {
            if (code != null) {
                return new BsonJavaScriptWithScope(code, scope);
            } else {
                return null;
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Creates a shallow clone of the BsonJavaScriptWithScope (see also DeepClone).
        /// </summary>
        /// <returns>A shallow clone of the BsonJavaScriptWithScope.</returns>
        public override BsonValue Clone() {
            return new BsonJavaScriptWithScope(code, (BsonDocument) scope.Clone());
        }

        /// <summary>
        /// Creates a deep clone of the BsonJavaScriptWithScope (see also Clone).
        /// </summary>
        /// <returns>A deep clone of the BsonJavaScriptWithScope.</returns>
        public override BsonValue DeepClone() {
            BsonJavaScriptWithScope clone = new BsonJavaScriptWithScope(code, new BsonDocument());
            foreach (BsonElement element in scope) {
                clone.scope.Add(element.DeepClone());
            }
            return clone;
        }

        /// <summary>
        /// Compares this BsonJavaScriptWithScope to another BsonJavaScriptWithScope.
        /// </summary>
        /// <param name="other">The other BsonJavaScriptWithScope.</param>
        /// <returns>A 32-bit signed integer that indicates whether this BsonJavaScriptWithScope is less than, equal to, or greather than the other.</returns>
        public int CompareTo(
            BsonJavaScriptWithScope other
        ) {
            if (other == null) { return 1; }
            int r = code.CompareTo(other.code);
            if (r != 0) { return r; }
            return scope.CompareTo(other.scope);
        }

        /// <summary>
        /// Compares the BsonJavaScriptWithScope to another BsonValue.
        /// </summary>
        /// <param name="other">The other BsonValue.</param>
        /// <returns>A 32-bit signed integer that indicates whether this BsonJavaScriptWithScope is less than, equal to, or greather than the other BsonValue.</returns>
        public override int CompareTo(
            BsonValue other
        ) {
            if (other == null) { return 1; }
            var otherJavaScriptWithScope = other as BsonJavaScriptWithScope;
            if (otherJavaScriptWithScope != null) {
                return CompareTo(otherJavaScriptWithScope);
            }
            return CompareTypeTo(other);
        }

        /// <summary>
        /// Compares this BsonJavaScriptWithScope to another BsonJavaScriptWithScope.
        /// </summary>
        /// <param name="rhs">The other BsonJavaScriptWithScope.</param>
        /// <returns>True if the two BsonJavaScriptWithScope values are equal.</returns>
        public bool Equals(
            BsonJavaScriptWithScope rhs
        ) {
            if (rhs == null) { return false; }
            return this.code == rhs.code && this.scope == rhs.scope;
        }

        /// <summary>
        /// Compares this BsonJavaScriptWithScope to another object.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True if the other object is a BsonJavaScriptWithScope and equal to this one.</returns>
        public override bool Equals(
            object obj
        ) {
            return Equals(obj as BsonJavaScriptWithScope); // works even if obj is null
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() {
            // see Effective Java by Joshua Bloch
            int hash = 17;
            hash = 37 * hash + base.GetHashCode();
            hash = 37 * hash + scope.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Returns a string representation of the value.
        /// </summary>
        /// <returns>A string representation of the value.</returns>
        public override string ToString() {
            return string.Format("{0}, scope : {1}", code, scope.ToJson());
        }
        #endregion
    }
}
