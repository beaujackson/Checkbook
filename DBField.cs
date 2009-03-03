using System;

namespace Checkbook
{
	public enum FieldType
	{
		Text,
		Numeric,
		Date
	}

	/// <summary>
	/// Provides a definition for a database field, and its value
	/// </summary>
	[Serializable]
	public class DBField
	{
		private string m_fieldName;
		private FieldType m_fieldType;
		private object m_fieldValue;
		private bool m_primaryKey = false;
		private bool m_identity = false;

		/// <summary>
		/// DBField Constructor
		/// </summary>
		/// <param name="name">The name of the field</param>
		/// <param name="type">The data type of the field</param>
		/// <param name="primaryKey">true if this field is part of a primary key, false otherwise</param>
		/// <param name="identity">true if this field is an identity, false otherwise</param>
		public DBField(string name, FieldType type, bool primaryKey, bool identity)
		{
			m_fieldName = name;
			m_fieldType = type;
			m_primaryKey = primaryKey;
			m_identity = identity;
		}

		/// <summary>
		/// The name of the field
		/// </summary>
		public string Name
		{
			get { return m_fieldName; }
		}

		/// <summary>
		/// The type of the field - Date, Numeric, or Text
		/// </summary>
		public FieldType Type
		{
			get { return m_fieldType; }
		}

		/// <summary>
		/// The value of the field.  Must be cast to the appropriate data type.  May be null.
		/// </summary>
		public object Value
		{
			get { return m_fieldValue; }
			set { m_fieldValue = value; }
		}

		/// <summary>
		/// Flag indicating that this field is part of a primary key
		/// </summary>
		public bool PrimaryKey
		{
			get { return m_primaryKey; }
		}

		/// <summary>
		/// flag indicating that this field is an identity field
		/// </summary>
		public bool Identity
		{
			get { return m_identity; }
		}
	}
}
