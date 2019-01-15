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
	public class ContentScoreCondition : BaseSegmentCondition
	{
		#region Constants
		public const string MIN_SCORE = "minScore";
		public const string MAX_SCORE = "maxScore";
		public const string DAYS = "days";
		public const string FIELD = "field";
		public const string VALUES = "values";
		public const string ACTIONS = "actions";
		#endregion

		#region Private Fields
		private int _MinScore = Int32.MinValue;
		private int _MaxScore = Int32.MinValue;
		private int _Days = Int32.MinValue;
		private string _Field = null;
		private IList<StringValue> _Values;
		private IList<ContentActionCondition> _Actions;
		#endregion

		#region Properties
		public int MinScore
		{
			get { return _MinScore; }
			set 
			{ 
				_MinScore = value;
				OnPropertyChanged("MinScore");
			}
		}
		public int MaxScore
		{
			get { return _MaxScore; }
			set 
			{ 
				_MaxScore = value;
				OnPropertyChanged("MaxScore");
			}
		}
		public int Days
		{
			get { return _Days; }
			set 
			{ 
				_Days = value;
				OnPropertyChanged("Days");
			}
		}
		public string Field
		{
			get { return _Field; }
			set 
			{ 
				_Field = value;
				OnPropertyChanged("Field");
			}
		}
		public IList<StringValue> Values
		{
			get { return _Values; }
			set 
			{ 
				_Values = value;
				OnPropertyChanged("Values");
			}
		}
		public IList<ContentActionCondition> Actions
		{
			get { return _Actions; }
			set 
			{ 
				_Actions = value;
				OnPropertyChanged("Actions");
			}
		}
		#endregion

		#region CTor
		public ContentScoreCondition()
		{
		}

		public ContentScoreCondition(XmlElement node) : base(node)
		{
			foreach (XmlElement propertyNode in node.ChildNodes)
			{
				switch (propertyNode.Name)
				{
					case "minScore":
						this._MinScore = ParseInt(propertyNode.InnerText);
						continue;
					case "maxScore":
						this._MaxScore = ParseInt(propertyNode.InnerText);
						continue;
					case "days":
						this._Days = ParseInt(propertyNode.InnerText);
						continue;
					case "field":
						this._Field = propertyNode.InnerText;
						continue;
					case "values":
						this._Values = new List<StringValue>();
						foreach(XmlElement arrayNode in propertyNode.ChildNodes)
						{
							this._Values.Add(ObjectFactory.Create<StringValue>(arrayNode));
						}
						continue;
					case "actions":
						this._Actions = new List<ContentActionCondition>();
						foreach(XmlElement arrayNode in propertyNode.ChildNodes)
						{
							this._Actions.Add(ObjectFactory.Create<ContentActionCondition>(arrayNode));
						}
						continue;
				}
			}
		}

		public ContentScoreCondition(IDictionary<string,object> data) : base(data)
		{
			    this._MinScore = data.TryGetValueSafe<int>("minScore");
			    this._MaxScore = data.TryGetValueSafe<int>("maxScore");
			    this._Days = data.TryGetValueSafe<int>("days");
			    this._Field = data.TryGetValueSafe<string>("field");
			    this._Values = new List<StringValue>();
			    foreach(var dataDictionary in data.TryGetValueSafe<IEnumerable<object>>("values", new List<object>()))
			    {
			        if (dataDictionary == null) { continue; }
			        this._Values.Add(ObjectFactory.Create<StringValue>((IDictionary<string,object>)dataDictionary));
			    }
			    this._Actions = new List<ContentActionCondition>();
			    foreach(var dataDictionary in data.TryGetValueSafe<IEnumerable<object>>("actions", new List<object>()))
			    {
			        if (dataDictionary == null) { continue; }
			        this._Actions.Add(ObjectFactory.Create<ContentActionCondition>((IDictionary<string,object>)dataDictionary));
			    }
		}
		#endregion

		#region Methods
		public override Params ToParams(bool includeObjectType = true)
		{
			Params kparams = base.ToParams(includeObjectType);
			if (includeObjectType)
				kparams.AddReplace("objectType", "KalturaContentScoreCondition");
			kparams.AddIfNotNull("minScore", this._MinScore);
			kparams.AddIfNotNull("maxScore", this._MaxScore);
			kparams.AddIfNotNull("days", this._Days);
			kparams.AddIfNotNull("field", this._Field);
			kparams.AddIfNotNull("values", this._Values);
			kparams.AddIfNotNull("actions", this._Actions);
			return kparams;
		}
		protected override string getPropertyName(string apiName)
		{
			switch(apiName)
			{
				case MIN_SCORE:
					return "MinScore";
				case MAX_SCORE:
					return "MaxScore";
				case DAYS:
					return "Days";
				case FIELD:
					return "Field";
				case VALUES:
					return "Values";
				case ACTIONS:
					return "Actions";
				default:
					return base.getPropertyName(apiName);
			}
		}
		#endregion
	}
}

