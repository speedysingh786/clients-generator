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
// Copyright (C) 2006-2019  Kaltura Inc.
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
	public class GeneralPartnerConfig : PartnerConfiguration
	{
		#region Constants
		public const string PARTNER_NAME = "partnerName";
		public const string MAIN_LANGUAGE = "mainLanguage";
		public const string SECONDARY_LANGUAGES = "secondaryLanguages";
		public const string DELETE_MEDIA_POLICY = "deleteMediaPolicy";
		public const string MAIN_CURRENCY = "mainCurrency";
		public const string SECONDARY_CURRENCYS = "secondaryCurrencys";
		public const string DOWNGRADE_POLICY = "downgradePolicy";
		public const string MAIL_SETTINGS = "mailSettings";
		public const string DATE_FORMAT = "dateFormat";
		public const string HOUSEHOLD_LIMITATION_MODULE = "householdLimitationModule";
		#endregion

		#region Private Fields
		private string _PartnerName = null;
		private int _MainLanguage = Int32.MinValue;
		private IList<IntegerValue> _SecondaryLanguages;
		private DeleteMediaPolicy _DeleteMediaPolicy = null;
		private int _MainCurrency = Int32.MinValue;
		private IList<IntegerValue> _SecondaryCurrencys;
		private DowngradePolicy _DowngradePolicy = null;
		private string _MailSettings = null;
		private string _DateFormat = null;
		private int _HouseholdLimitationModule = Int32.MinValue;
		#endregion

		#region Properties
		[JsonProperty]
		public string PartnerName
		{
			get { return _PartnerName; }
			set 
			{ 
				_PartnerName = value;
				OnPropertyChanged("PartnerName");
			}
		}
		[JsonProperty]
		public int MainLanguage
		{
			get { return _MainLanguage; }
			set 
			{ 
				_MainLanguage = value;
				OnPropertyChanged("MainLanguage");
			}
		}
		[JsonProperty]
		public IList<IntegerValue> SecondaryLanguages
		{
			get { return _SecondaryLanguages; }
			set 
			{ 
				_SecondaryLanguages = value;
				OnPropertyChanged("SecondaryLanguages");
			}
		}
		[JsonProperty]
		public DeleteMediaPolicy DeleteMediaPolicy
		{
			get { return _DeleteMediaPolicy; }
			set 
			{ 
				_DeleteMediaPolicy = value;
				OnPropertyChanged("DeleteMediaPolicy");
			}
		}
		[JsonProperty]
		public int MainCurrency
		{
			get { return _MainCurrency; }
			set 
			{ 
				_MainCurrency = value;
				OnPropertyChanged("MainCurrency");
			}
		}
		[JsonProperty]
		public IList<IntegerValue> SecondaryCurrencys
		{
			get { return _SecondaryCurrencys; }
			set 
			{ 
				_SecondaryCurrencys = value;
				OnPropertyChanged("SecondaryCurrencys");
			}
		}
		[JsonProperty]
		public DowngradePolicy DowngradePolicy
		{
			get { return _DowngradePolicy; }
			set 
			{ 
				_DowngradePolicy = value;
				OnPropertyChanged("DowngradePolicy");
			}
		}
		[JsonProperty]
		public string MailSettings
		{
			get { return _MailSettings; }
			set 
			{ 
				_MailSettings = value;
				OnPropertyChanged("MailSettings");
			}
		}
		[JsonProperty]
		public string DateFormat
		{
			get { return _DateFormat; }
			set 
			{ 
				_DateFormat = value;
				OnPropertyChanged("DateFormat");
			}
		}
		[JsonProperty]
		public int HouseholdLimitationModule
		{
			get { return _HouseholdLimitationModule; }
			set 
			{ 
				_HouseholdLimitationModule = value;
				OnPropertyChanged("HouseholdLimitationModule");
			}
		}
		#endregion

		#region CTor
		public GeneralPartnerConfig()
		{
		}

		public GeneralPartnerConfig(JToken node) : base(node)
		{
			if(node["partnerName"] != null)
			{
				this._PartnerName = node["partnerName"].Value<string>();
			}
			if(node["mainLanguage"] != null)
			{
				this._MainLanguage = ParseInt(node["mainLanguage"].Value<string>());
			}
			if(node["secondaryLanguages"] != null)
			{
				this._SecondaryLanguages = new List<IntegerValue>();
				foreach(var arrayNode in node["secondaryLanguages"].Children())
				{
					this._SecondaryLanguages.Add(ObjectFactory.Create<IntegerValue>(arrayNode));
				}
			}
			if(node["deleteMediaPolicy"] != null)
			{
				this._DeleteMediaPolicy = (DeleteMediaPolicy)StringEnum.Parse(typeof(DeleteMediaPolicy), node["deleteMediaPolicy"].Value<string>());
			}
			if(node["mainCurrency"] != null)
			{
				this._MainCurrency = ParseInt(node["mainCurrency"].Value<string>());
			}
			if(node["secondaryCurrencys"] != null)
			{
				this._SecondaryCurrencys = new List<IntegerValue>();
				foreach(var arrayNode in node["secondaryCurrencys"].Children())
				{
					this._SecondaryCurrencys.Add(ObjectFactory.Create<IntegerValue>(arrayNode));
				}
			}
			if(node["downgradePolicy"] != null)
			{
				this._DowngradePolicy = (DowngradePolicy)StringEnum.Parse(typeof(DowngradePolicy), node["downgradePolicy"].Value<string>());
			}
			if(node["mailSettings"] != null)
			{
				this._MailSettings = node["mailSettings"].Value<string>();
			}
			if(node["dateFormat"] != null)
			{
				this._DateFormat = node["dateFormat"].Value<string>();
			}
			if(node["householdLimitationModule"] != null)
			{
				this._HouseholdLimitationModule = ParseInt(node["householdLimitationModule"].Value<string>());
			}
		}
		#endregion

		#region Methods
		public override Params ToParams(bool includeObjectType = true)
		{
			Params kparams = base.ToParams(includeObjectType);
			if (includeObjectType)
				kparams.AddReplace("objectType", "KalturaGeneralPartnerConfig");
			kparams.AddIfNotNull("partnerName", this._PartnerName);
			kparams.AddIfNotNull("mainLanguage", this._MainLanguage);
			kparams.AddIfNotNull("secondaryLanguages", this._SecondaryLanguages);
			kparams.AddIfNotNull("deleteMediaPolicy", this._DeleteMediaPolicy);
			kparams.AddIfNotNull("mainCurrency", this._MainCurrency);
			kparams.AddIfNotNull("secondaryCurrencys", this._SecondaryCurrencys);
			kparams.AddIfNotNull("downgradePolicy", this._DowngradePolicy);
			kparams.AddIfNotNull("mailSettings", this._MailSettings);
			kparams.AddIfNotNull("dateFormat", this._DateFormat);
			kparams.AddIfNotNull("householdLimitationModule", this._HouseholdLimitationModule);
			return kparams;
		}
		protected override string getPropertyName(string apiName)
		{
			switch(apiName)
			{
				case PARTNER_NAME:
					return "PartnerName";
				case MAIN_LANGUAGE:
					return "MainLanguage";
				case SECONDARY_LANGUAGES:
					return "SecondaryLanguages";
				case DELETE_MEDIA_POLICY:
					return "DeleteMediaPolicy";
				case MAIN_CURRENCY:
					return "MainCurrency";
				case SECONDARY_CURRENCYS:
					return "SecondaryCurrencys";
				case DOWNGRADE_POLICY:
					return "DowngradePolicy";
				case MAIL_SETTINGS:
					return "MailSettings";
				case DATE_FORMAT:
					return "DateFormat";
				case HOUSEHOLD_LIMITATION_MODULE:
					return "HouseholdLimitationModule";
				default:
					return base.getPropertyName(apiName);
			}
		}
		#endregion
	}
}
