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
using System.IO;
using Kaltura.Request;
using Kaltura.Types;
using Kaltura.Enums;

namespace Kaltura.Services
{
	public class AssetUserRuleAddRequestBuilder : RequestBuilder<AssetUserRule>
	{
		#region Constants
		public const string ASSET_USER_RULE = "assetUserRule";
		#endregion

		public AssetUserRule AssetUserRule
		{
			set;
			get;
		}

		public AssetUserRuleAddRequestBuilder()
			: base("assetuserrule", "add")
		{
		}

		public AssetUserRuleAddRequestBuilder(AssetUserRule assetUserRule)
			: this()
		{
			this.AssetUserRule = assetUserRule;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("assetUserRule"))
				kparams.AddIfNotNull("assetUserRule", AssetUserRule);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			return ObjectFactory.Create<AssetUserRule>(result);
		}
	}


	public class AssetUserRuleService
	{
		private AssetUserRuleService()
		{
		}

		public static AssetUserRuleAddRequestBuilder Add(AssetUserRule assetUserRule)
		{
			return new AssetUserRuleAddRequestBuilder(assetUserRule);
		}
	}
}
