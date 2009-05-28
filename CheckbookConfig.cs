using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using System.Reflection;

namespace Checkbook
{
	public class CheckbookConfig
	{
		private static CheckbookConfig _instance = null;

		private XmlDocument _configDoc;
		private Hashtable _transTypes;
		private string _path;

		private CheckbookConfig()
		{
			Assembly a = Assembly.GetExecutingAssembly();
			_path = a.Location.Replace("Checkbook.exe", "Checkbook.config");
			
			_configDoc = new XmlDocument();
			_configDoc.Load(_path);
		}

		public static CheckbookConfig GetInstance()
		{
			if (_instance == null)
			{
				_instance = new CheckbookConfig();
			}

			return _instance;
		}

		public void Save()
		{
			_configDoc.Save(_path);
		}

		#region Database

		public bool TestMode 
		{
			get
			{
				XmlElement elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Database/add[@key='TestMode']") as XmlElement;
				return (elem.GetAttribute("value") == "1");
			}
			set
			{
				XmlElement elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Database/add[@key='TestMode']") as XmlElement;
				
				string val = value ? "1" : "0";

				elem.SetAttribute("value", val);
			}
		}

		public string ConnectString 
		{
			get
			{
				XmlElement elem;

				if (TestMode)
				{
					elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Database/add[@key='TestModeConnectString']") as XmlElement;
				}
				else
				{
					elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Database/add[@key='ConnectString']") as XmlElement;
				}

				return elem.GetAttribute("value");
			}

			set
			{
				XmlElement elem;

				if (TestMode)
				{
					elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Database/add[@key='TestModeConnectString']") as XmlElement;
				}
				else
				{
					elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Database/add[@key='ConnectString']") as XmlElement;
				}

				elem.SetAttribute("value", value);
			}
		}

		public string DB
		{
			get
			{
				XmlElement elem;

				if (TestMode)
				{
					elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Database/add[@key='TestModeDB']") as XmlElement;
				}
				else
				{
					elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Database/add[@key='DB']") as XmlElement;
				}

				return elem.GetAttribute("value");
			}

			set
			{
				XmlElement elem;

				if (TestMode)
				{
					elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Database/add[@key='TestModeDB']") as XmlElement;
				}
				else
				{
					elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Database/add[@key='DB']") as XmlElement;
				}

				elem.SetAttribute("value", value);
			}
		}

		#endregion	

		#region Data

		public string StartFolder
		{
			get
			{
				XmlElement elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Data/add[@key='StartFolder']") as XmlElement;
				return elem.GetAttribute("value");
			}

			set
			{
				XmlElement elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/Data/add[@key='StartFolder']") as XmlElement;
				elem.SetAttribute("value", value);
			}
		}

		#endregion

		#region TransactionTypes

		public string GetTransactionCategory(string transType)
		{
			if (_transTypes == null)
			{
				_transTypes = new Hashtable();

				string[] debitTypes = DebitTypes;
				string[] creditTypes = CreditTypes;

				foreach (string debit in debitTypes)
				{
					_transTypes[debit] = "debit";
				}

				foreach (string credit in creditTypes)
				{
					_transTypes[credit] = "credit";
				}
			}

			return _transTypes[transType] as string;
		}

		public string[] DebitTypes
		{
			get
			{
				XmlElement elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/TransactionTypes/add[@key='DebitTypes']") as XmlElement;
				return elem.GetAttribute("value").Split(new char[] {'|'});
			}
		}

		public string[] CreditTypes
		{
			get
			{
				XmlElement elem = _configDoc.DocumentElement.SelectSingleNode("appSettings/TransactionTypes/add[@key='CreditTypes']") as XmlElement;
				return elem.GetAttribute("value").Split(new char[] { '|' });
			}
		}

		#endregion

		#region ReconcileTypes

		public string GetReconileType(string reconcileType)
		{
			string xpath = string.Format("appSettings/ReconcileTypes/add[@key='{0}']", reconcileType);
			XmlElement elem = _configDoc.DocumentElement.SelectSingleNode(xpath) as XmlElement;
			return elem.GetAttribute("value");
		}

		#endregion
	}
}
