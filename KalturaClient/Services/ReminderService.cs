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
	public class ReminderAddRequestBuilder : RequestBuilder<Reminder>
	{
		#region Constants
		public const string REMINDER = "reminder";
		#endregion

		public Reminder Reminder
		{
			set;
			get;
		}

		public ReminderAddRequestBuilder()
			: base("reminder", "add")
		{
		}

		public ReminderAddRequestBuilder(Reminder reminder)
			: this()
		{
			this.Reminder = reminder;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("reminder"))
				kparams.AddIfNotNull("reminder", Reminder);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			return ObjectFactory.Create<Reminder>(result);
		}
	}

	public class ReminderDeleteRequestBuilder : RequestBuilder<bool>
	{
		#region Constants
		public const string ID = "id";
		public const string TYPE = "type";
		#endregion

		public long Id
		{
			set;
			get;
		}
		public ReminderType Type
		{
			set;
			get;
		}

		public ReminderDeleteRequestBuilder()
			: base("reminder", "delete")
		{
		}

		public ReminderDeleteRequestBuilder(long id, ReminderType type)
			: this()
		{
			this.Id = id;
			this.Type = type;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("id"))
				kparams.AddIfNotNull("id", Id);
			if (!isMapped("type"))
				kparams.AddIfNotNull("type", Type);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			if (result.InnerText.Equals("1") || result.InnerText.ToLower().Equals("true"))
				return true;
			return false;
		}
	}

	public class ReminderDeleteWithTokenRequestBuilder : RequestBuilder<object>
	{
		#region Constants
		public const string ID = "id";
		public const string TYPE = "type";
		public const string TOKEN = "token";
		public new const string PARTNER_ID = "partnerId";
		#endregion

		public long Id
		{
			set;
			get;
		}
		public ReminderType Type
		{
			set;
			get;
		}
		public string Token
		{
			set;
			get;
		}
		public new int PartnerId
		{
			set;
			get;
		}

		public ReminderDeleteWithTokenRequestBuilder()
			: base("reminder", "deleteWithToken")
		{
		}

		public ReminderDeleteWithTokenRequestBuilder(long id, ReminderType type, string token, int partnerId)
			: this()
		{
			this.Id = id;
			this.Type = type;
			this.Token = token;
			this.PartnerId = partnerId;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("id"))
				kparams.AddIfNotNull("id", Id);
			if (!isMapped("type"))
				kparams.AddIfNotNull("type", Type);
			if (!isMapped("token"))
				kparams.AddIfNotNull("token", Token);
			if (!isMapped("partnerId"))
				kparams.AddIfNotNull("partnerId", PartnerId);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			return null;
		}
	}

	public class ReminderListRequestBuilder : StandaloneRequestBuilder<ListResponse<Reminder>>
	{
		#region Constants
		public const string FILTER = "filter";
		public const string PAGER = "pager";
		#endregion

		public ReminderFilter Filter
		{
			set;
			get;
		}
		public FilterPager Pager
		{
			set;
			get;
		}

		public ReminderListRequestBuilder()
			: base("reminder", "list")
		{
		}

		public ReminderListRequestBuilder(ReminderFilter filter, FilterPager pager)
			: this()
		{
			this.Filter = filter;
			this.Pager = pager;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("filter"))
				kparams.AddIfNotNull("filter", Filter);
			if (!isMapped("pager"))
				kparams.AddIfNotNull("pager", Pager);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			return ObjectFactory.Create<ListResponse<Reminder>>(result);
		}
	}


	public class ReminderService
	{
		private ReminderService()
		{
		}

		public static ReminderAddRequestBuilder Add(Reminder reminder)
		{
			return new ReminderAddRequestBuilder(reminder);
		}

		public static ReminderDeleteRequestBuilder Delete(long id, ReminderType type)
		{
			return new ReminderDeleteRequestBuilder(id, type);
		}

		public static ReminderDeleteWithTokenRequestBuilder DeleteWithToken(long id, ReminderType type, string token, int partnerId)
		{
			return new ReminderDeleteWithTokenRequestBuilder(id, type, token, partnerId);
		}

		public static ReminderListRequestBuilder List(ReminderFilter filter, FilterPager pager = null)
		{
			return new ReminderListRequestBuilder(filter, pager);
		}
	}
}