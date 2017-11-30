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
	public class HouseholdDeviceFilter : Filter
	{
		#region Constants
		public const string HOUSEHOLD_ID_EQUAL = "householdIdEqual";
		public const string DEVICE_FAMILY_ID_IN = "deviceFamilyIdIn";
		public new const string ORDER_BY = "orderBy";
		#endregion

		#region Private Fields
		private int _HouseholdIdEqual = Int32.MinValue;
		private string _DeviceFamilyIdIn = null;
		private HouseholdDeviceOrderBy _OrderBy = null;
		#endregion

		#region Properties
		public int HouseholdIdEqual
		{
			get { return _HouseholdIdEqual; }
			set 
			{ 
				_HouseholdIdEqual = value;
				OnPropertyChanged("HouseholdIdEqual");
			}
		}
		public string DeviceFamilyIdIn
		{
			get { return _DeviceFamilyIdIn; }
			set 
			{ 
				_DeviceFamilyIdIn = value;
				OnPropertyChanged("DeviceFamilyIdIn");
			}
		}
		public new HouseholdDeviceOrderBy OrderBy
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
		public HouseholdDeviceFilter()
		{
		}

		public HouseholdDeviceFilter(XmlElement node) : base(node)
		{
			foreach (XmlElement propertyNode in node.ChildNodes)
			{
				switch (propertyNode.Name)
				{
					case "householdIdEqual":
						this._HouseholdIdEqual = ParseInt(propertyNode.InnerText);
						continue;
					case "deviceFamilyIdIn":
						this._DeviceFamilyIdIn = propertyNode.InnerText;
						continue;
					case "orderBy":
						this._OrderBy = (HouseholdDeviceOrderBy)StringEnum.Parse(typeof(HouseholdDeviceOrderBy), propertyNode.InnerText);
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
				kparams.AddReplace("objectType", "KalturaHouseholdDeviceFilter");
			kparams.AddIfNotNull("householdIdEqual", this._HouseholdIdEqual);
			kparams.AddIfNotNull("deviceFamilyIdIn", this._DeviceFamilyIdIn);
			kparams.AddIfNotNull("orderBy", this._OrderBy);
			return kparams;
		}
		protected override string getPropertyName(string apiName)
		{
			switch(apiName)
			{
				case HOUSEHOLD_ID_EQUAL:
					return "HouseholdIdEqual";
				case DEVICE_FAMILY_ID_IN:
					return "DeviceFamilyIdIn";
				case ORDER_BY:
					return "OrderBy";
				default:
					return base.getPropertyName(apiName);
			}
		}
		#endregion
	}
}
