// ===================================================================================================
//                           _  __     _ _
//                          | |/ /__ _| | |_ _  _ _ _ __ _
//                          | ' </ _` | |  _| || | '_/ _` |
//                          |_|\_\__,_|_|\__|\_,_|_| \__,_|
//
// This file is part of the Kaltura Collaborative Media Suite which allows users
// to do with audio, video, and animation what Wiki platfroms allow them to do with
// text.
//
// Copyright (C) 2006-2018  Kaltura Inc.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// @ignore
// ===================================================================================================
using System;
using System.Xml;
using System.Collections.Generic;
using Kaltura.Enums;
using Kaltura.Request;

namespace Kaltura.Types
{
	public class OTTUserDynamicData : ObjectBase
	{
		#region Constants
		public const string USER_ID = "userId";
		public const string KEY = "key";
		public const string VALUE = "value";
		#endregion

		#region Private Fields
		private string _UserId = null;
		private string _Key = null;
		private StringValue _Value;
		#endregion

		#region Properties
		public string UserId
		{
			get { return _UserId; }
		}
		public string Key
		{
			get { return _Key; }
			set 
			{ 
				_Key = value;
				OnPropertyChanged("Key");
			}
		}
		public StringValue Value
		{
			get { return _Value; }
			set 
			{ 
				_Value = value;
				OnPropertyChanged("Value");
			}
		}
		#endregion

		#region CTor
		public OTTUserDynamicData()
		{
		}

		public OTTUserDynamicData(XmlElement node) : base(node)
		{
			foreach (XmlElement propertyNode in node.ChildNodes)
			{
				switch (propertyNode.Name)
				{
					case "userId":
						this._UserId = propertyNode.InnerText;
						continue;
					case "key":
						this._Key = propertyNode.InnerText;
						continue;
					case "value":
						this._Value = ObjectFactory.Create<StringValue>(propertyNode);
						continue;
				}
			}
		}
		#endregion

		#region Methods
		public override Params ToParams(bool includeObjectType = true)
		{
			Params kparams = base.ToParams(includeObjectType);
			if (includeObjectType)
				kparams.AddReplace("objectType", "KalturaOTTUserDynamicData");
			kparams.AddIfNotNull("userId", this._UserId);
			kparams.AddIfNotNull("key", this._Key);
			kparams.AddIfNotNull("value", this._Value);
			return kparams;
		}
		protected override string getPropertyName(string apiName)
		{
			switch(apiName)
			{
				case USER_ID:
					return "UserId";
				case KEY:
					return "Key";
				case VALUE:
					return "Value";
				default:
					return base.getPropertyName(apiName);
			}
		}
		#endregion
	}
}
