using System.ComponentModel;

namespace RSoft.Person.Infra.Enum
{

    /// <summary>
    /// Phone type enumeration
    /// </summary>
    public enum PhoneType
    {

        //TODO: Move this enumeration to BE-Lib

        [Description("Landline telephone at home or place of residence")]
        Residential = 1,

        [Description("Cell Phone")]
        CellPhone,

        [Description("Business or company phone")]
        Business,

        [Description("Workplace or service delivery")]
        Workplace,

        [Description("Phone to leave a message")]
        MessagePhone,

    }

}
