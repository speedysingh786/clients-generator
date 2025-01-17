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
// Copyright (C) 2006-2021  Kaltura Inc.
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kaltura.Types
{
	public class PasswordPolicy : CrudObject
	{
		#region Constants
		public const string ID = "id";
		public const string NAME = "name";
		public const string USER_ROLE_IDS = "userRoleIds";
		public const string HISTORY_COUNT = "historyCount";
		public const string EXPIRATION = "expiration";
		public const string COMPLEXITIES = "complexities";
		public const string LOCKOUT_FAILURES_COUNT = "lockoutFailuresCount";
		#endregion

		#region Private Fields
		private long _Id = long.MinValue;
		private string _Name = null;
		private string _UserRoleIds = null;
		private int _HistoryCount = Int32.MinValue;
		private int _Expiration = Int32.MinValue;
		private IList<RegexExpression> _Complexities;
		private int _LockoutFailuresCount = Int32.MinValue;
		#endregion

		#region Properties
		[JsonProperty]
		public long Id
		{
			get { return _Id; }
			private set 
			{ 
				_Id = value;
				OnPropertyChanged("Id");
			}
		}
		[JsonProperty]
		public string Name
		{
			get { return _Name; }
			set 
			{ 
				_Name = value;
				OnPropertyChanged("Name");
			}
		}
		[JsonProperty]
		public string UserRoleIds
		{
			get { return _UserRoleIds; }
			set 
			{ 
				_UserRoleIds = value;
				OnPropertyChanged("UserRoleIds");
			}
		}
		[JsonProperty]
		public int HistoryCount
		{
			get { return _HistoryCount; }
			set 
			{ 
				_HistoryCount = value;
				OnPropertyChanged("HistoryCount");
			}
		}
		[JsonProperty]
		public int Expiration
		{
			get { return _Expiration; }
			set 
			{ 
				_Expiration = value;
				OnPropertyChanged("Expiration");
			}
		}
		[JsonProperty]
		public IList<RegexExpression> Complexities
		{
			get { return _Complexities; }
			set 
			{ 
				_Complexities = value;
				OnPropertyChanged("Complexities");
			}
		}
		[JsonProperty]
		public int LockoutFailuresCount
		{
			get { return _LockoutFailuresCount; }
			set 
			{ 
				_LockoutFailuresCount = value;
				OnPropertyChanged("LockoutFailuresCount");
			}
		}
		#endregion

		#region CTor
		public PasswordPolicy()
		{
		}

		public PasswordPolicy(JToken node) : base(node)
		{
			if(node["id"] != null)
			{
				this._Id = ParseLong(node["id"].Value<string>());
			}
			if(node["name"] != null)
			{
				this._Name = node["name"].Value<string>();
			}
			if(node["userRoleIds"] != null)
			{
				this._UserRoleIds = node["userRoleIds"].Value<string>();
			}
			if(node["historyCount"] != null)
			{
				this._HistoryCount = ParseInt(node["historyCount"].Value<string>());
			}
			if(node["expiration"] != null)
			{
				this._Expiration = ParseInt(node["expiration"].Value<string>());
			}
			if(node["complexities"] != null)
			{
				this._Complexities = new List<RegexExpression>();
				foreach(var arrayNode in node["complexities"].Children())
				{
					this._Complexities.Add(ObjectFactory.Create<RegexExpression>(arrayNode));
				}
			}
			if(node["lockoutFailuresCount"] != null)
			{
				this._LockoutFailuresCount = ParseInt(node["lockoutFailuresCount"].Value<string>());
			}
		}
		#endregion

		#region Methods
		public override Params ToParams(bool includeObjectType = true)
		{
			Params kparams = base.ToParams(includeObjectType);
			if (includeObjectType)
				kparams.AddReplace("objectType", "KalturaPasswordPolicy");
			kparams.AddIfNotNull("id", this._Id);
			kparams.AddIfNotNull("name", this._Name);
			kparams.AddIfNotNull("userRoleIds", this._UserRoleIds);
			kparams.AddIfNotNull("historyCount", this._HistoryCount);
			kparams.AddIfNotNull("expiration", this._Expiration);
			kparams.AddIfNotNull("complexities", this._Complexities);
			kparams.AddIfNotNull("lockoutFailuresCount", this._LockoutFailuresCount);
			return kparams;
		}
		protected override string getPropertyName(string apiName)
		{
			switch(apiName)
			{
				case ID:
					return "Id";
				case NAME:
					return "Name";
				case USER_ROLE_IDS:
					return "UserRoleIds";
				case HISTORY_COUNT:
					return "HistoryCount";
				case EXPIRATION:
					return "Expiration";
				case COMPLEXITIES:
					return "Complexities";
				case LOCKOUT_FAILURES_COUNT:
					return "LockoutFailuresCount";
				default:
					return base.getPropertyName(apiName);
			}
		}
		#endregion
	}
}

