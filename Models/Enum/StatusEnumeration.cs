using System;
using System.ComponentModel;

namespace MyFirstProject.Models.Enum
{
	public enum StatusEnumeration
	{
        Default,
        [Description("Завешен")]
        Completed,
        [Description("Ожидающий")]
        Pending
    }
}

