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
// Copyright (C) 2006-2017  Kaltura Inc.
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
	public class SubscriptionSetFilter : Filter
	{
		#region Constants
		public const string ID_IN = "idIn";
		public const string SUBSCRIPTION_ID_CONTAINS = "subscriptionIdContains";
		public const string TYPE_EQUAL = "typeEqual";
		public new const string ORDER_BY = "orderBy";
		#endregion

		#region Private Fields
		private string _IdIn = null;
		private string _SubscriptionIdContains = null;
		private SubscriptionSetType _TypeEqual = null;
		private SubscriptionSetOrderBy _OrderBy = null;
		#endregion

		#region Properties
		public string IdIn
		{
			get { return _IdIn; }
			set 
			{ 
				_IdIn = value;
				OnPropertyChanged("IdIn");
			}
		}
		public string SubscriptionIdContains
		{
			get { return _SubscriptionIdContains; }
			set 
			{ 
				_SubscriptionIdContains = value;
				OnPropertyChanged("SubscriptionIdContains");
			}
		}
		public SubscriptionSetType TypeEqual
		{
			get { return _TypeEqual; }
			set 
			{ 
				_TypeEqual = value;
				OnPropertyChanged("TypeEqual");
			}
		}
		public new SubscriptionSetOrderBy OrderBy
		{
			get { return _OrderBy; }
			set 
			{ 
				_OrderBy = value;
				OnPropertyChanged("OrderBy");
			}
		}
		#endregion

		#region CTor
		public SubscriptionSetFilter()
		{
		}

		public SubscriptionSetFilter(XmlElement node) : base(node)
		{
			foreach (XmlElement propertyNode in node.ChildNodes)
			{
				switch (propertyNode.Name)
				{
					case "idIn":
						this._IdIn = propertyNode.InnerText;
						continue;
					case "subscriptionIdContains":
						this._SubscriptionIdContains = propertyNode.InnerText;
						continue;
					case "typeEqual":
						this._TypeEqual = (SubscriptionSetType)StringEnum.Parse(typeof(SubscriptionSetType), propertyNode.InnerText);
						continue;
					case "orderBy":
						this._OrderBy = (SubscriptionSetOrderBy)StringEnum.Parse(typeof(SubscriptionSetOrderBy), propertyNode.InnerText);
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
				kparams.AddReplace("objectType", "KalturaSubscriptionSetFilter");
			kparams.AddIfNotNull("idIn", this._IdIn);
			kparams.AddIfNotNull("subscriptionIdContains", this._SubscriptionIdContains);
			kparams.AddIfNotNull("typeEqual", this._TypeEqual);
			kparams.AddIfNotNull("orderBy", this._OrderBy);
			return kparams;
		}
		protected override string getPropertyName(string apiName)
		{
			switch(apiName)
			{
				case ID_IN:
					return "IdIn";
				case SUBSCRIPTION_ID_CONTAINS:
					return "SubscriptionIdContains";
				case TYPE_EQUAL:
					return "TypeEqual";
				case ORDER_BY:
					return "OrderBy";
				default:
					return base.getPropertyName(apiName);
			}
		}
		#endregion
	}
}
