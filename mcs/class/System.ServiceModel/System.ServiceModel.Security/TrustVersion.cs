//
// TrustVersion.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2010 Novell, Inc.  http://www.novell.com
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System.Xml;

namespace System.ServiceModel.Security
{
	public abstract class TrustVersion
	{
		static TrustVersion ()
		{
			var dic = new XmlDictionary ();
			WSTrust13 = new TrustVersionImpl () { Prefix = dic.Add ("wst"), Namespace = dic.Add ("http://docs.oasis-open.org/ws-sx/ws-trust/200512") };
			WSTrustFeb2005 = new TrustVersionImpl () { Prefix = dic.Add ("wsse"), Namespace = dic.Add ("http://schemas.xmlsoap.org/ws/2002/12/secext") };
			Default = WSTrust13;
		}

		public static TrustVersion Default { get; private set; }
		public static TrustVersion WSTrust13 { get; private set; }
		public static TrustVersion WSTrustFeb2005 { get; private set; }

		public XmlDictionaryString Namespace { get; internal set; }
		public XmlDictionaryString Prefix { get; internal set; }
	}

	class TrustVersionImpl : TrustVersion
	{
	}
}
